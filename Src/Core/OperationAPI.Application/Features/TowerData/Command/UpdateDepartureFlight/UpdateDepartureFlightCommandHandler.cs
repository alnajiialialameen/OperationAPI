using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.TowerData.Command.CreateDepartureInitial
{
   

    public class UpdateDepartureFlightCommandHandler : IRequestHandler<UpdateDepartureFlightCommand, TowerDataDomain>
    {

        readonly ITowerDataService service;
        public UpdateDepartureFlightCommandHandler(ITowerDataService service)
        {
            this.service = service;
        }
        public async Task<TowerDataDomain> Handle(UpdateDepartureFlightCommand command, CancellationToken cancellationToken)
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
            towerData.TakeOffDate = command.model.TakeOffDate;
            towerData.Ata = command.model.Atd;

            var res = await service.UpdateAsync(towerData);
            return res;
        }
    }

}
