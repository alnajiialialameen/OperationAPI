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

namespace OperationAPI.Application.Features.AircraftType.Command.CreateAircraftType
{
    public class CreateAircraftTypeCommandHandler : IRequestHandler<CreateAircraftTypeCommand, AircraftTypeDomain>
    {

        readonly IAircraftTypeService service;
        public CreateAircraftTypeCommandHandler(IAircraftTypeService service)
        {
            this.service = service;
        }
        public async Task<AircraftTypeDomain> Handle(CreateAircraftTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAircraftTypeValidator(service);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(AircraftTypeDomain), validationResult.Errors);
            }


            var res = await service.CreateAsync(request.model);
            return res;
        }
    }
}
