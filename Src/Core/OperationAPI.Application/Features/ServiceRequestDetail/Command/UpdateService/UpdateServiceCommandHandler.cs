using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.ServiceRequestDetail.Command.CreatelService;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.ServiceRequestDetail.Command.UpdateService
{
  


    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, ServiceRequestDetailDomain>
    {

        readonly IServiceRequestDetailService service;

        public UpdateServiceCommandHandler(IServiceRequestDetailService service)
        {
            this.service = service;

        }
        public async Task<ServiceRequestDetailDomain> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
        {
            //var validator = new CreateDepartureServiceValidator(service);
            //var validationResult = await validator.ValidateAsync(command);
            //if (validationResult.Errors.Any())
            //{

            //    throw new BadRequestException(nameof(DepartureInitialDomain), validationResult.Errors);
            //}

            var obj = await service.UpdateService(command.model);
            return obj;
        }

    }










}
