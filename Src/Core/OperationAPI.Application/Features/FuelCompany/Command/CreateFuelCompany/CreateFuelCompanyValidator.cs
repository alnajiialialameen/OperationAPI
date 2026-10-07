using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AircraftSize.Command.CreateAircraftSize;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.FuelCompany.Command.CreateFuelCompany
{
   


    public class CreateFuelCompanyValidator : AbstractValidator<CreateFuelCompanyCommand>
    {
        private readonly IFuelCompanyService service;

        public CreateFuelCompanyValidator(IFuelCompanyService service)
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
