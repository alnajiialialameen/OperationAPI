using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Command.CreateWorkOn
{
   
    public class CreateWorkOnValidator : AbstractValidator<CreateWorkOnCommand>
    {
        private readonly IWorkOnService service;

        public CreateWorkOnValidator(IWorkOnService service)
        {
            RuleFor(q => q.model.UserId)
                .NotEmpty().WithMessage("UserId Is Required");

            RuleFor(q => q.model.YearWorkOn)
               .NotEmpty().WithMessage("Year Is Required");

            RuleFor(q => q.model.MonthWorkOn)
            .NotEmpty().WithMessage("Month Is Required");

            RuleFor(q => q.model.CompanyInfoId)
           .NotEmpty().WithMessage("Month Is CompanyInfoId");

            RuleFor(q => q.model)
                .MustAsync(IsUniqueObject)
                .WithMessage("Object Already Exist");

            this.service = service;
        }

        private async Task<bool> IsUniqueObject(WorkOnDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }
    }






}
