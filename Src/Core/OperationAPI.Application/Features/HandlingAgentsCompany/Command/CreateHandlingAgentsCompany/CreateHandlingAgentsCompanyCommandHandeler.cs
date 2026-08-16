using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.HandlingAgentsCompany.Command.CreateHandlingAgentsCompany
{
    class CreateHandlingAgentsCompanyCommandHandeler : IRequestHandler<CreateHandlingAgentsCompanyCommand, HandlingAgentsCompanyDomain>
    {
        private readonly IHandlingAgentsCompanyService service;
        public CreateHandlingAgentsCompanyCommandHandeler(IHandlingAgentsCompanyService service)
        {
            this.service = service;
        }
        public async Task<HandlingAgentsCompanyDomain> Handle(CreateHandlingAgentsCompanyCommand request, CancellationToken cancellationToken)
        {
            var obj = await service.CreateAsync(request.model);
            return obj;
        }
    }
}
