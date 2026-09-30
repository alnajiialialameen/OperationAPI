using MediatR;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.TowerData.Quieres.GetOfficerDataById
{

    public record GetOfficerDataByIdRequest(int Id) : IRequest<OfficerDataDomain>
    {

    }
}
