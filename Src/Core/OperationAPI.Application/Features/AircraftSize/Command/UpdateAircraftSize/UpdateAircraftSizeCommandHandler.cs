using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.AircraftRegisteration.Command.UpdateAircraftRegistration;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Command.UpdateAircraftSize
{
   

    public class UpdateAircraftSizeCommandHandler : IRequestHandler<UpdateAircraftSizeCommand, AircraftSizeDomain>
    {
        private readonly IAircraftSizeService service;
        public UpdateAircraftSizeCommandHandler(IAircraftSizeService service)
        {
            this.service = service;
        }

        public async Task<AircraftSizeDomain> Handle(UpdateAircraftSizeCommand command, CancellationToken cancellationToken)
        {
            // validation
            var validator = new UpdateAircraftSizeValidator(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(AircraftSizeDomain), validationResult.Errors);
            }


            var res = await service.UpdateAsync(command.model);
            return res;
        }
    }


}
