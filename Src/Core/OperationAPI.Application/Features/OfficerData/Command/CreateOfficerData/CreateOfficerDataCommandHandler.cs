using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.OfficerData.Command.CreateOfficerData
{
 
    public class CreateOfficerDataCommandHandler : IRequestHandler<CreateOfficerDataCommand, OfficerDataDomain>
    {
        private readonly ITowerDataService towerDataService;
        private readonly IOfficerDataService officerDataService;
        private readonly IUnitOfWork unitOfWork;


        public CreateOfficerDataCommandHandler(ITowerDataService towerDataService, IOfficerDataService officerDataService, IUnitOfWork unitOfWork)
        {
            this.towerDataService = towerDataService;
            this.officerDataService = officerDataService;
            this.unitOfWork = unitOfWork;

        }

        public async Task<OfficerDataDomain> Handle(CreateOfficerDataCommand command, CancellationToken cancellationToken)
        {

            // validation
            //var validator = new CreateFlightValidator(service);
            //var validationResult = await validator.ValidateAsync(command);

            //if (validationResult.Errors.Any())
            //{

            //    throw new BadRequestException(nameof(AircraftRegistrationDomain), validationResult.Errors);
            //}

            await unitOfWork.BeginTransactionAsync();

            try
            {
                var towerDataDomain = new TowerDataDomain
                {
                    AirLineId = command.model?.TowerData?.AirLineId,
                    FlightNo = command.model?.TowerData?.FlightNo,
                    AircraftRegId = command.model?.TowerData?.AircraftRegId,

                    AirportIdFrom = command.model?.TowerData?.AirportIdFrom,
                    AirportIdTo = command.model?.TowerData?.AirportIdTo,

                    FlightTypeD = command.model?.TowerData?.FlightTypeD,
                    FlightTypeL = command.model?.TowerData?.FlightTypeL,

                    LandingDate = command.model?.TowerData?.LandingDate,
                    TakeOffDate = command.model?.TowerData?.TakeOffDate,

                    Status = command.model?.TowerData?.Status,
                    Date = command.model?.TowerData?.Date,

                    Ata = command.model?.TowerData?.Ata,
                    Atd = command.model?.TowerData?.Atd,

                    //Pob = command.model.Pob,
                    //Qbd = command.model.Qbd,

                    TripTypeId = command.model?.TowerData?.TripTypeId,


                    CompanyInfoId = command.model?.TowerData?.CompanyInfoId,

                    Note = command.model?.TowerData?.Note,

                    //CreatedBy = command.model.CreatedBy,
                    //CreationDate = command.model.CreationDate,

                    //UpdatedBy = command.model.UpdatedBy,
                    //UpdatingDate = command.model.UpdatingDate
                };

                var towerResult = await towerDataService.CreateAsync(towerDataDomain);
                command.model.TowerDataId = towerResult.Id;
                var officeResult = await officerDataService.CreateAsync(command.model);


                await unitOfWork.CommitAsync();
                return officeResult;

            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
















        }


    }

}
