using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Command.DeleteWorkOn
{
    class DeleteWorkOnCommandHandler : IRequestHandler<DeleteWorkOnCommand, bool>
    {
        private readonly IWorkOnService service;
        public DeleteWorkOnCommandHandler(IWorkOnService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(DeleteWorkOnCommand command, CancellationToken cancellationToken)
        {
            var ObjDelete = await service.GetByIdAsync(command.Id);

            if (ObjDelete == null)
            {
                // throw new Exception
                throw new NotFoundException(nameof(WorkOnDomain), $" With Id = [{command.Id}]");
            }

            // exe
            var res = await service.DeleteAsync(ObjDelete);

            // return
            return res;
        }
    }
}
