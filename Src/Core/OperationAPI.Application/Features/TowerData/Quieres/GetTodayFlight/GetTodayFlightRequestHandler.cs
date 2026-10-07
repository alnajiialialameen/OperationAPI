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
            // 1. جلب البيانات المحلية (سواء كانت لشركة واحدة أو لكل الشركات)
            var localData = await service.GetTodayFilghtLocal(request.AirLineId);

            // 2. جلب الرحلات من FIDS API
            var flightsList = await FidsAPIService.GetToDayFlights();

            // فلترة حسب الشركة فقط إذا تم تمرير AirLineId
            if (request.AirLineId.HasValue)
            {
                flightsList = flightsList.Where(x => x.AirlineId == request.AirLineId.Value).ToList();
            }

            if (!flightsList.Any())
            {
                return new List<FlightDomain>();
            }

            // 3. تحويل البيانات المحلية إلى Dictionary للبحث المباشر O(1)
            var localFlightMap = localData
                .Where(x => x.FidsFlightId.HasValue)
                .ToDictionary(x => x.FidsFlightId.Value, x => x);

            // 4. مطابقة رحلات FIDS مع الرحلات المحلية
            flightsList = flightsList.Select(e =>
            {
                var isFound = localFlightMap.TryGetValue(e.Id, out var localFlight);

                e.IsConsumed = isFound;
                e.IsOpen = e.FlightStatusId >= 1;

                if (isFound && localFlight != null)
                {
                    e.TowerDataId = localFlight.Id;
                }

                return e;
            }).ToList();

            return flightsList;
        }



    }
}
