using MediatR;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.AirLineAgent.Quieres.GetAirLineAgentByAirlineId
{

    public record GetAirLineAgentByAirlineIdRequest(int? AirlineId) : IRequest<List<AirLineAgentDomain>>
    {
    }
}
