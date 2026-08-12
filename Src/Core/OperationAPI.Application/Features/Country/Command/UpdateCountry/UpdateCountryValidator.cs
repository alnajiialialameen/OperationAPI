using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.Country.Command.UpdateCountry
{
    public class UpdateCountryValidator:AbstractValidator<UpdateCountryCommand>
    {
        private readonly ICountryService service;

        public UpdateCountryValidator(ICountryService service)
        {
            RuleFor(q => q.model.NameAr)
                    .NotEmpty().WithMessage("NameAr Is Required");
            RuleFor(q => q.model.NameEn).NotEmpty().WithMessage("NameEn Is Requred");
            RuleFor(q => q.model.Code).NotEmpty().WithMessage("Code Is Requred");
            RuleFor(q => q.model).MustAsync(IsUniqueObject).WithMessage("Object Already Exist");
            this.service = service;

        }
        private async Task<bool> IsUniqueObject(CountryDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }
    }
}
