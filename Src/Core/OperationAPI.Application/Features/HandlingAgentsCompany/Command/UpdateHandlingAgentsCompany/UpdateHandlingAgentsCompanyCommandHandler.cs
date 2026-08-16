using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.HandlingAgentsCompany.Command.UpdateHandlingAgentsCompany
{
    public class UpdateHandlingAgentsCompanyCommandHandler : IRequestHandler<UpdateHandlingAgentsCompanyCommand, HandlingAgentsCompanyDomain>
    {
        private readonly IHandlingAgentsCompanyService service;
        public UpdateHandlingAgentsCompanyCommandHandler(IHandlingAgentsCompanyService service)
        {
            this.service = service;
        }
        public async Task<HandlingAgentsCompanyDomain> Handle(UpdateHandlingAgentsCompanyCommand request, CancellationToken cancellationToken)
        {
            var res = await service.UpdateAsync(request.model);
            return res;
        }
    }
}
