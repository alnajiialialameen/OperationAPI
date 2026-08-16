using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.HandlingAgentsCompany.Quieres.GetAllHandlingAgentsCompany
{
    internal class GetAllHandlingAgentsCompanyRequestHandler : IRequestHandler<GetAllHandlingAgentsCompanyRequest, List<HandlingAgentsCompanyDomain>>
    {
        private readonly IHandlingAgentsCompanyService service;
        public GetAllHandlingAgentsCompanyRequestHandler(IHandlingAgentsCompanyService service)
        {
            this.service = service;   
        }
        public async Task<List<HandlingAgentsCompanyDomain>> Handle(GetAllHandlingAgentsCompanyRequest request, CancellationToken cancellationToken)
        {
            var obj = await service.GetAsync();
            return obj;
        }
    }
}
