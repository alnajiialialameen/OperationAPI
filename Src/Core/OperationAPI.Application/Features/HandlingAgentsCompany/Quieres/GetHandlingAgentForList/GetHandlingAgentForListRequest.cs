using MediatR;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.HandlingAgentsCompany.Quieres.GetHandlingAgentForList
{

    public record GetHandlingAgentForListRequest : IRequest<List<ListDomain>>
    {
    }
}
