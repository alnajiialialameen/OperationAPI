using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Command.CreateAircraftSize
{
  


    public class CreateAircraftSizeValidator : AbstractValidator<CreateAircraftSizeCommand>
    {
        private readonly IAircraftSizeService service;

        public CreateAircraftSizeValidator(IAircraftSizeService service)
        {
            RuleFor(q => q.model.Size)
                .NotEmpty().WithMessage("Size Is Required");

            RuleFor(q => q.model)
                .MustAsync(IsUniqueObject)
                .WithMessage("Object Already Exist");

            this.service = service;
        }

        private async Task<bool> IsUniqueObject(AircraftSizeDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }
    }



}
