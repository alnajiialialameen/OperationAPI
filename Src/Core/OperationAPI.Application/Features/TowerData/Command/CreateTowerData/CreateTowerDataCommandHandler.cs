using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.TowerData.Command.CreateTowerData;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command
{
   
    public class CreateTowerDataCommandHandler : IRequestHandler<CreateTowerDataCommand, TowerDataDomain>
    {
        private readonly ITowerDataService service;

        public CreateTowerDataCommandHandler(ITowerDataService service)
        {
            this.service = service;
        }

        public async Task<TowerDataDomain> Handle(CreateTowerDataCommand command, CancellationToken cancellationToken)
        {

            //if (command.model.AireLineId == 0) { command.model.AireLineId = null; }
            //// validation
            //var validator = new CreateAircraftRegistrationValidation(service);
            //var validationResult = await validator.ValidateAsync(command);

            //if (validationResult.Errors.Any())
            //{

            //    throw new BadRequestException(nameof(AircraftRegistrationDomain), validationResult.Errors);
            //}


            var res = await service.CreateAsync(command.model);
            return res;

        }
    }








}
