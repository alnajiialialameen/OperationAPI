using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.WorkOn.Command.CreateWorkOn;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Command.UpdateWorkOn
{
    class UpdateWorkOnCommandHandler : IRequestHandler<UpdateWorkOnCommand, WorkOnDomain>   
    {
        private readonly IWorkOnService service;

        public UpdateWorkOnCommandHandler(IWorkOnService service)
        {
            this.service = service;
        }

        public async Task<WorkOnDomain> Handle(UpdateWorkOnCommand command, CancellationToken cancellationToken)
        {
            // validation
            var validator = new UpdateWorkOnValidator(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(WorkOnDomain), validationResult.Errors);
            }


            var result = await service.UpdateAsync(command.model);
            return result;
        }
    }
}
