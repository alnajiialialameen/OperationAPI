using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.HandlingAgentsCompany.Quieres.GetByIdHandlingAgentsCompany
{
    public class GetByIdHandlingAgentsCompanyRequestHandler : IRequestHandler<GetByIdHandlingAgentsCompanyRequest, HandlingAgentsCompanyDomain>
    {
        private readonly IHandlingAgentsCompanyService service;
        public GetByIdHandlingAgentsCompanyRequestHandler(IHandlingAgentsCompanyService service)
        {
            this.service = service;
        }
        public async Task<HandlingAgentsCompanyDomain> Handle(GetByIdHandlingAgentsCompanyRequest request, CancellationToken cancellationToken)
        {
            var obj = await service.GetByIdAsync(request.Id);
            return obj;
        }
    }
}
