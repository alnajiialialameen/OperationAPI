using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.CreateTowerData
{
   
    public class CreateStartUpValidator : AbstractValidator<CreateStartUpCommand>
    {
        private readonly ITowerDataService service;

        public CreateStartUpValidator(ITowerDataService service)
        {
            RuleFor(q => q.model.AirLineId)
                .NotEmpty().WithMessage("AirLineId Is Required");

            RuleFor(q => q.model.AircraftRegId)
              .NotEmpty().WithMessage("AircraftRegId Is Required");

            //RuleFor(q => q.model.AirportIdFrom)
            //  .NotEmpty().WithMessage("AirportIdFrom Is Required");

            RuleFor(q => q.model.AirportIdTo)
            .NotEmpty().WithMessage("AirportIdFrom Is Required");

            RuleFor(q => q.model)
                .MustAsync(IsUniqueObject)
                .WithMessage("Object Already Exist");

            this.service = service;
        }

        private async Task<bool> IsUniqueObject(InitialDataDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObjectSetUp(model);
        }
    }

}
