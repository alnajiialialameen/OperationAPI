using MediatR;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.TowerData.Quieres.GetTowerDataById
{
  
    public record GetTowerDataByIdRequest(int Id) : IRequest<TowerDataDomain>
    {

    }
}
