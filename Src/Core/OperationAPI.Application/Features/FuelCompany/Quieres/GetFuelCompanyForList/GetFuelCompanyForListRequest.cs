using MediatR;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.FuelCompany.Quieres.GetFuelCompanyForList
{

    public record GetFuelCompanyForListRequest : IRequest<List<ListDomain>>
    {
    }
}
