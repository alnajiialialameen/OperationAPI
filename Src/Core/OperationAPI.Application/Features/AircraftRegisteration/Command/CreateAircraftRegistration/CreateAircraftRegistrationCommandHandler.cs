using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration
{
   public class CreateAircraftRegistrationCommandHandler : IRequestHandler<CreateAircraftRegistrationCommand,AircraftRegistrationDomain>
    {
        private readonly IAircraftRegistrationService service;

        public CreateAircraftRegistrationCommandHandler(IAircraftRegistrationService service)
        {
            this.service = service;
        }

        public async Task<AircraftRegistrationDomain> Handle(CreateAircraftRegistrationCommand command, CancellationToken cancellationToken)
        {
            // validation
            var validator = new CreateAircraftRegistrationValidation(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(AircraftRegistrationDomain), validationResult.Errors);
            }


            var res = await service.CreateAsync(command.model);
            return res;

        }
    }
}
