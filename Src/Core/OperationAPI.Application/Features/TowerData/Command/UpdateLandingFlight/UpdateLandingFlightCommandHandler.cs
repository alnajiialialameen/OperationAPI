using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.TowerData.Command.CreateDepartureInitial;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.UpdateTakeOffFlight
{
   
    public class UpdateLandingFlightCommandHandler : IRequestHandler<UpdateLandingFlightCommand, TowerDataDomain>
    {

        readonly ITowerDataService service;
        public UpdateLandingFlightCommandHandler(ITowerDataService service)
        {
            this.service = service;
        }
        public async Task<TowerDataDomain> Handle(UpdateLandingFlightCommand command, CancellationToken cancellationToken)
        {
            //var validator = new CreateAircraftTypeValidator(service);
            //var validationResult = await validator.ValidateAsync(request);

            //if (validationResult.Errors.Any())
            //{

            //    throw new BadRequestException(nameof(DepartureInitialDomain), validationResult.Errors);
            //}
            var towerData = await service.GetByIdAsync(command.model.Id);

            if (towerData == null)
            {
                throw new NotFoundException(nameof(TowerDataDomain), command.model.Id);
            }

            // تعديل الخصائص على الكائن الموجود
            towerData.AircraftRegId = command.model.AircraftRegId;
            towerData.TakeOffDate = command.model.LandingDate;
            towerData.Ata = command.model.Ata;

            var res = await service.UpdateAsync(towerData);
            return res;
        }
    }








}
