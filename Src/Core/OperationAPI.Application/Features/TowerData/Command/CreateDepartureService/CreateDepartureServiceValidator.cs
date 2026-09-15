using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.TowerData.Command.CreateDepartureService
{
   
    public class CreateDepartureServiceValidator : AbstractValidator<CreateDepartureServiceCommand>
    {
        private readonly IOfficerDataService service;

        public CreateDepartureServiceValidator(IOfficerDataService service)
        {
            RuleFor(q => q.model.TowerDataId)
                .NotEmpty().WithMessage("TowerDataId Is Required");
            RuleFor(q => q.model)
                      .MustAsync(IsUniqueObject)
                      .WithMessage("There is an element in officerdata with the same ID");

            this.service = service;
        }
        private async Task<bool> IsUniqueObject(DepartureServiceDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }
    }

}
