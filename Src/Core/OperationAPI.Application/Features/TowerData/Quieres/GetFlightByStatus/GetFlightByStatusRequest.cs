using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Quieres.GetFlightByStatus
{

    public record GetFlightByStatusRequest(int? AirlineId,  List<int> Statuses) : IRequest<List<TowerDataViewDomain>>;
}
