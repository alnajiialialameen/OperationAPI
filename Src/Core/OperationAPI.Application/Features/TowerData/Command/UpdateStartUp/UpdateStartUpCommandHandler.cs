using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.AircraftRegisteration.Command.UpdateAircraftRegistration;
using OperationAPI.Application.Features.TowerData.Command.CreateTowerData;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.UpdateTowerData
{
   




    public class UpdateStartUpCommandHandler : IRequestHandler<UpdateStartUpCommand, TowerDataDomain>
    {
        private readonly ITowerDataService service;

        public UpdateStartUpCommandHandler(ITowerDataService service)
        {
            this.service = service;
        }

        public async Task<TowerDataDomain> Handle(UpdateStartUpCommand command, CancellationToken cancellationToken)
        {
            //command.model.CompanyInfoId = 10;
            //command.model.Date = DateOnly.FromDateTime(DateTime.Now);
            var validator = new UpdateStartUpValidator(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(InitialDataDomain), validationResult.Errors);
            }

            var towerData = new TowerDataDomain
            {
                AirLineId = command.model.AirLineId,
                FlightNo = command.model.FlightNo,
                AircraftRegId = command.model.AircraftRegId,
                CompanyInfoId = 10,
                Date = DateOnly.FromDateTime(DateTime.Now),

            };

            var res = await service.CreateAsync(towerData);
            return res;

        }
    }







}
