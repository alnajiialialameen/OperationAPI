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

namespace OperationAPI.Application.Features.AircraftRegisteration.Command.UpdateAircraftRegistration
{
   public class UpdateAircraftRegistrationCommandHandler :IRequestHandler<UpdateAircraftRegistrationCommand,AircraftRegistrationDomain>
    {
        private readonly IAircraftRegistration service;
       public UpdateAircraftRegistrationCommandHandler(IAircraftRegistration service) 
        {
           this.service = service;
        }

        public async Task<AircraftRegistrationDomain> Handle(UpdateAircraftRegistrationCommand command, CancellationToken cancellationToken)
        {
            // validation
            var validator = new UpdateAircraftRegistrationValidation(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(AircraftRegistrationDomain), validationResult.Errors);
            }


            var res = await service.UpdateAsync(command.model);
            return res;
        }
    }
}
