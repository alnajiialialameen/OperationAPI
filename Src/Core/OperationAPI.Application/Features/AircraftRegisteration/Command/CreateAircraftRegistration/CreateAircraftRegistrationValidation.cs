using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration
{
 
    public class CreateAircraftRegistrationValidation : AbstractValidator<CreateAircraftRegistrationCommand>
    {
        private readonly IAircraftRegistration service;

        public CreateAircraftRegistrationValidation(IAircraftRegistration service)
        {
            RuleFor(q => q.model.Registration)
                .NotEmpty().WithMessage("Registration Is Required");

            RuleFor(q => q.model)
                .MustAsync(IsUniqueObject)
                .WithMessage("Object Already Exist");

            this.service = service;
        }

        private async Task<bool> IsUniqueObject(AircraftRegistrationDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }
    }






}
