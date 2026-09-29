using MediatR;
using OperationAPI.Domain;
using OperationAPI.Domain.FidsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Quieres.GetTodayFlight
{
    public record GetTodayFlightRequest(int? AirLineId) : IRequest<List<FlightDomain>>;

   
}
