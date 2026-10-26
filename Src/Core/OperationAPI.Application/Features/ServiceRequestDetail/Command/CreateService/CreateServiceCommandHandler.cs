using AutoMapper;
using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.TowerData.Command.CreateDepartureService;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.ServiceRequestDetail.Command.CreatelService
{
    
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ServiceRequestDetailDomain>
    {

        readonly IServiceRequestDetailService service;

        public CreateServiceCommandHandler(IServiceRequestDetailService service)
        {
            this.service = service;
          
        }
        public async Task<ServiceRequestDetailDomain> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
        {
            //var validator = new CreateDepartureServiceValidator(service);
            //var validationResult = await validator.ValidateAsync(command);
            //if (validationResult.Errors.Any())
            //{

            //    throw new BadRequestException(nameof(DepartureInitialDomain), validationResult.Errors);
            //}

            var obj = await service.CreatelService(command.model);
            return obj;
        }

    }




















}
