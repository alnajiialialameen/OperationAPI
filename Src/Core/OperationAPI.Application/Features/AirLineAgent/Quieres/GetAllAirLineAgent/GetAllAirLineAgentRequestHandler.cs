using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAllAircraftRegisteration;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Quieres.GetAllAirLineAgent
{
   

    public class GetAllAirLineAgentRequestHandler : IRequestHandler<GetAllAirLineAgentRequest, List<AirLineAgentDomain>>
    {
        private readonly IAirlineAgentService service;
        public GetAllAirLineAgentRequestHandler(IAirlineAgentService service)
        {
            this.service = service;
        }

        public async Task<List<AirLineAgentDomain>> Handle(GetAllAirLineAgentRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetAsync();
            if (data == null)
            {
                // throw new Exception
                data = new List<AirLineAgentDomain>();   //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }

}
