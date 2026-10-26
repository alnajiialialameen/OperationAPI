using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.ServiceRequestDetail.Command.AcceptOfficer;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.ServiceRequestDetail.Command.ConfirmAgent
{
  

    public class ConfirmAgentCommandHandler : IRequestHandler<ConfirmAgentCommand, ServiceRequestDetailDomain>
    {

        readonly IServiceRequestDetailService service;

        public ConfirmAgentCommandHandler(IServiceRequestDetailService service)
        {
            this.service = service;

        }
        public async Task<ServiceRequestDetailDomain> Handle(ConfirmAgentCommand command, CancellationToken cancellationToken)
        {
            //var validator = new CreateDepartureServiceValidator(service);
            //var validationResult = await validator.ValidateAsync(command);
            //if (validationResult.Errors.Any())
            //{

            //    throw new BadRequestException(nameof(DepartureInitialDomain), validationResult.Errors);
            //}

            var obj = await service.ConfirmAgent(command.model);
            return obj;
        }

    }

}
