using MediatR;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.TowerData.Quieres.GetFilghtLocalNotComplate
{
    public record GetFilghtLocalNotComplateRequest(int? AirLineId) : IRequest<List<TowerDataViewDomain>>;

   
}
