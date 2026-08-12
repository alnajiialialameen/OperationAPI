using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftType.Command.CreateAircraftType
{
    public class CreateAircraftTypeValidator:AbstractValidator<CreateAircraftTypeCommand>
    {
        private readonly IAircraftTypeService service;

        public CreateAircraftTypeValidator(IAircraftTypeService service)
        {
            RuleFor(q=>q.model.SizeId).NotEmpty().WithMessage("SizeId is requerd");

            RuleFor(q => q.model.Type).NotEmpty().WithMessage("Type is Requerd");

            RuleFor(q=>q.model).MustAsync(IsUniqueObject).WithMessage("Object Already Exist");
            this.service = service;

        }
        private async Task<bool> IsUniqueObject(AircraftTypeDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }
    }
}
