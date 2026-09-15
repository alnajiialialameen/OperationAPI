using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.TowerData.Command.CreateDepartureService;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.CreateLandingService
{



    public class CreateLandingServiceValidator : AbstractValidator<CreateLandingServiceCommand>
    {
        private readonly IOfficerDataService service;

        public CreateLandingServiceValidator(IOfficerDataService service)
        {
            RuleFor(q => q.model.TowerDataId)
                .NotEmpty().WithMessage("TowerDataId Is Required");

            RuleFor(q => q.model)
             .MustAsync(IsUniqueObject)
             .WithMessage("There is an element in officerdata with the same ID");

            this.service = service;
        }
        private async Task<bool> IsUniqueObject(LandingServiceDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }
    }
}
