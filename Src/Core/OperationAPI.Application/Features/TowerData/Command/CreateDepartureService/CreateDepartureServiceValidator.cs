using FluentValidation;
using OperationAPI.Application.Contracts.Services;

namespace OperationAPI.Application.Features.TowerData.Command.CreateDepartureService
{
   
    public class CreateDepartureServiceValidator : AbstractValidator<CreateDepartureServiceCommand>
    {
        private readonly IOfficerDataService service;

        public CreateDepartureServiceValidator(IOfficerDataService service)
        {
            RuleFor(q => q.model.TowerDataId)
                .NotEmpty().WithMessage("TowerDataId Is Required");
            this.service = service;
        }    
    }

}
