using FluentValidation;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AirLineAgent.Command.CreateAirLineAgent;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Command.UpdateAirLineAgent
{
   

    public class UpdateAirLineAgentValidator : AbstractValidator<UpdateAirLineAgentCommand>
    {
        private readonly IAirlineAgentService service;

        public UpdateAirLineAgentValidator(IAirlineAgentService service)
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
