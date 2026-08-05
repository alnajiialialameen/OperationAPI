using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Quieres.GetAllAirLineAgent
{
    public class GetAllAirLineAgentRequestHandler :IRequestHandler<GetAllAirLineAgentRequest, List<AirLineAgentDomain>>
    {
        private readonly IAirLineAgentService service;
        public GetAllAirLineAgentRequestHandler(IAirLineAgentService service)
        {
            this.service = service;
        }

        public async Task<List<AirLineAgentDomain>> Handle(GetAllAirLineAgentRequest request, CancellationToken cancellationToken)
        {
           
           var data = await service.GetAsync();
            if (!data.Any()) 
            {
                data = new List<AirLineAgentDomain>();
            }
            return data;

        }
    }
}
