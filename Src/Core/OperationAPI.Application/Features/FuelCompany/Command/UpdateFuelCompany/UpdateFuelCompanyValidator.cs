using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
namespace OperationAPI.Application.Features.FuelCompany.Command.UpdateFuelCompany
{
   
    public class UpdateFuelCompanyValidator : AbstractValidator<UpdateFuelCompanyCommand>
    {
        private readonly IFuelCompanyService service;

        public UpdateFuelCompanyValidator(IFuelCompanyService service)
        {
            RuleFor(q => q.model.NameEn)
                .NotEmpty().WithMessage("NameEn Is Required");

            RuleFor(q => q.model.NameAr)
              .NotEmpty().WithMessage("NameAr Is Required");


            RuleFor(q => q.model)
                .MustAsync(IsUniqueObject)
                .WithMessage("Object Already Exist");

            this.service = service;
        }

        private async Task<bool> IsUniqueObject(FuelCompanyDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }
    }

}
