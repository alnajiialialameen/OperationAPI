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
            // Get flights from local database
            var data = await service.GetTodayFilghtLocal(request.AirLineId);

            // Get all flights from FIDS API
            var flightsList = await FidsAPIService.GetToDayFlights();

            if (!flightsList.Any())
            {
                return new List<FlightDomain>();
            }

            // IDs of flights already consumed locally
            var clientIds = data
                .Select(x => x.FidsFlightId)
                .ToHashSet();

            // Compare all FIDS flights with local flights
            flightsList = flightsList.Select(e =>
            {
                e.IsConsumed = clientIds.Contains(e.Id);
                e.IsOpen = e.FlightStatusId >= 1;


                return e;
            }).ToList();




            // Return ALL FIDS flights
            return flightsList;
        }



    }
}
