using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Command
{
  


    public class AirlineAgentValidator : AbstractValidator<AirLineAgentCommand>
    {
        private readonly IAirlineAgentService service;

        public AirlineAgentValidator(IAirlineAgentService service)
        {
            RuleFor(q => q.model.AirLineId)
                .NotEmpty().WithMessage("AirLineId Is Required");

            RuleFor(q => q.model)
                .MustAsync(IsUniqueObject)
                .WithMessage("Object Already Exist");

            this.service = service;
        }

        private async Task<bool> IsUniqueObject(AirLineAgentDomain model, CancellationToken token)
        {
            return !await service.IsUniqueObject(model);
        }
    }



}
