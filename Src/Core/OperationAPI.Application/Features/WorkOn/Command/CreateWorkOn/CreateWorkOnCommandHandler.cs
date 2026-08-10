using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Command.CreateWorkOn
{
   public class CreateWorkOnCommandHandler : IRequestHandler<CreateWorkOnCommand, WorkOnDomain>
    {
        private readonly IWorkOnService service;
        public CreateWorkOnCommandHandler(IWorkOnService service)
        {
            this.service = service;
        }
        public async Task<WorkOnDomain> Handle(CreateWorkOnCommand command, CancellationToken cancellationToken)
        {
            // validation
            var validator = new CreateWorkOnValidator(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(WorkOnDomain), validationResult.Errors);
            }




            var result = await service.CreateAsync(command.model);
            return result;
        }
    }
}
