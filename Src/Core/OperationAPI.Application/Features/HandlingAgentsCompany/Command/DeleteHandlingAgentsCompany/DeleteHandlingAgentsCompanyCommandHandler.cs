using MediatR;
using OperationAPI.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.HandlingAgentsCompany.Command.DeleteHandlingAgentsCompany
{
    public class DeleteHandlingAgentsCompanyCommandHandler : IRequestHandler<DeleteHandlingAgentsCompanyCommand, bool>
    {
        private readonly IHandlingAgentsCompanyService service;
        public DeleteHandlingAgentsCompanyCommandHandler(IHandlingAgentsCompanyService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(DeleteHandlingAgentsCompanyCommand request, CancellationToken cancellationToken)
        {
            var ObjDelete = await service.GetByIdAsync(request.Id);
            var res = await service.DeleteAsync(ObjDelete);
            return res;
        }
    }
}
