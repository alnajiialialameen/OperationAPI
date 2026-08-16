using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AircraftRegisteration.Command.UpdateAircraftRegistration;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Command.UpdateAircraftSize
{
   

    public class UpdateAircraftSizeValidator : AbstractValidator<UpdateAircraftSizeCommand>
    {
        private readonly IAircraftSizeService service;

        public UpdateAircraftSizeValidator(IAircraftSizeService service)
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
