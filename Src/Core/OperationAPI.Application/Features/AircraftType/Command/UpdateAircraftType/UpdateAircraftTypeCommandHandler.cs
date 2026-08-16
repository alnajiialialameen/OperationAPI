using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.WorkOn.Command.UpdateWorkOn;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftType.Command.UpdateAircraftType
{
    public class UpdateAircraftTypeCommandHandler : IRequestHandler<UpdateAircraftTypeCommand, AircraftTypeDomain>
    {

        private readonly IAircraftTypeService service;

        public UpdateAircraftTypeCommandHandler(IAircraftTypeService service)
        {
            this.service = service;
        }
        public async Task<AircraftTypeDomain> Handle(UpdateAircraftTypeCommand request, CancellationToken cancellationToken)
        {

            // validation
            var validator = new UpdateAircraftTypeValidator(service);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(AircraftTypeDomain), validationResult.Errors);
            }


            var result = await service.UpdateAsync(request.model);
            return result;
        }
    }
}
