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

namespace OperationAPI.Application.Features.Country.Command.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CountryDomain>
    {private readonly ICountryService service;

        public CreateCountryCommandHandler(ICountryService service)
        {
            this.service = service;
        }
        public async Task<CountryDomain> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCountryValidator(service);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(CountryDomain), validationResult.Errors);
            }


            var res = await service.CreateAsync(request.model);
            return res;
        }
    }
}
