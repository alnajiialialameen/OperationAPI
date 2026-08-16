using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftType.Command.UpdateAircraftType
{
    public class UpdateAircraftTypeValidator:AbstractValidator<UpdateAircraftTypeCommand>
    {
        private readonly IAircraftTypeService service;

        public UpdateAircraftTypeValidator(IAircraftTypeService service)
        {
            RuleFor(q => q.model.Type)
                 .NotEmpty().WithMessage("Type Is Required");
            RuleFor(q => q.model.SizeId).NotEmpty().WithMessage("SizeId Is Requred");
            RuleFor(q=>q.model).MustAsync(IsUniqueObject).WithMessage("Object Already Exist");
            this.service = service;

        }
        private async Task<bool> IsUniqueObject(AircraftTypeDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }

    }
}
