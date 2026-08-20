using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAircraftRegisterationById;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Quieres.GetAirLineAgentById
{
  

    class GetAirLineAgentByIdRequestHandler : IRequestHandler<GetAirLineAgentByIdRequest, AirLineAgentDomain>
    {
        private readonly IAirlineAgentService service;

        public GetAirLineAgentByIdRequestHandler(IAirlineAgentService service)
        {
            this.service = service;
        }

        public async Task<AirLineAgentDomain> Handle(GetAirLineAgentByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetByIdAsync(request.Id);
            if (data == null)
            {
                // throw new Exception
                data = new AirLineAgentDomain();  //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }

}
