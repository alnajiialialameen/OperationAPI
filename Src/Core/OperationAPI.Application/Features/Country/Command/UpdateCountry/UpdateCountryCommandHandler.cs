using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.AircraftType.Command.UpdateAircraftType;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.Country.Command.UpdateCountry
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, CountryDomain>
    {
        private readonly ICountryService service;
        public UpdateCountryCommandHandler(ICountryService service)
        {
            this.service = service;
        }
        public async Task<CountryDomain> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            // validation
            var validator = new UpdateCountryValidator(service);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(CountryDomain), validationResult.Errors);
            }


            var result = await service.UpdateAsync(request.model);
            return result;
        }
    }
}
