using MediatR;
using OperationAPI.Application.Contracts.FidsAPIServices;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;
using OperationAPI.Domain.FidsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Quieres.GetTodayFlight
{
   
    public class GetTodayFlightRequestHandler : IRequestHandler<GetTodayFlightRequest, List<FlightDomain>>
    {
        private readonly ITowerDataService service;
        private readonly IConsumeFidsAPIService FidsAPIService;

        public GetTodayFlightRequestHandler(ITowerDataService service, IConsumeFidsAPIService FidsAPIService)
        {
            this.service = service;
            this.FidsAPIService = FidsAPIService;
        }
        //public async Task<List<FlightDomain>> Handle(GetTodayFlightRequest request, CancellationToken cancellationToken)
        //{
        //    // get data
        //    var data = await service.GetTodayFilghtLocal(request.AirLineId);

        //    // validation
        //    //if (!data.Any())
        //    //{
        //    //    // throw new Exception
        //    //    throw new NotFoundException(nameof(TowerDataDomain), "");
        //    //}

        //    // get data from hrAPI
        //    var FlightsList = await FidsAPIService.GetToDayFlights();

        //    // validation
        //    if (!FlightsList.Any())
        //    {
        //        // throw new Exception
        //        throw new NotFoundException(nameof(TowerDataDomain), "");
        //    }


        //    // compare data
        //    var clientIds = data.Select(x => x.FidsFlightId).ToHashSet();
        //    FlightsList = FlightsList.Where(e => !clientIds.Contains(e.Id)).ToList();

        //    FlightsList = FlightsList.Select(e =>
        //    {
        //        e.IsConsumed = clientIds.Contains(e.Id);
        //        return e;
        //    }).ToList();

        //    //EmployeesList.RemoveAll(e =>data.Any(d => d.ClientId == e.Id));


        //    // return data
        //    return FlightsList;
        //}

        public async Task<List<FlightDomain>> Handle(
      GetTodayFlightRequest request,
      CancellationToken cancellationToken)
        {
            // 1. جلب البيانات المحلية
            var localData = await service.GetTodayFilghtLocal(request.AirLineId);

            // 2. جلب الرحلات من FIDS API
            List<FlightDomain> flightsList;
            try
            {
                flightsList = await FidsAPIService.GetToDayFlights();
            }
            catch (Exception)
            {
                // في حال فشل الاتصال بالـ API أو حدوث خطأ في السيرفر
                return new List<FlightDomain>();
            }

            // فلترة حسب الشركة
            if (request.AirLineId.HasValue)
            {
                flightsList = flightsList
                    .Where(x => x.AirlineId == request.AirLineId.Value)
                    .ToList();
            }

            if (!flightsList.Any())
            {
                return new List<FlightDomain>();
            }

            // 3. تحويل البيانات المحلية إلى Dictionary
            var localFlightMap = localData
                .Where(x => x.FidsFlightId.HasValue)
                .ToDictionary(
                    x => x.FidsFlightId.Value,
                    x => x
                );

            // 4. مطابقة FIDS مع البيانات المحلية
            flightsList = flightsList.Select(e =>
            {
                var isFound = localFlightMap.TryGetValue(
                    e.Id,
                    out var localFlight
                );

                e.IsConsumed = isFound;
                e.IsOpen = e.FlightStatusId >= 1;

                if (isFound && localFlight != null)
                {
                    e.TowerDataId = localFlight.Id;

                    // جلب Status من localData
                    e.Status = localFlight.Status;
                    e.IsOfficerConfirmed = localFlight.IsOfficerConfirmed;
                }

                return e;
            }).ToList();

            return flightsList;
        }



    }
}
