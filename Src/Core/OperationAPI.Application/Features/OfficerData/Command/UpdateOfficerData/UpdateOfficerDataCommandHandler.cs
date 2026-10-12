using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System.Windows.Input;

namespace OperationAPI.Application.Features.OfficerData.Command.UpdateOfficerData
{
    public class UpdateOfficerDataCommandHandler
        : IRequestHandler<UpdateOfficerDataCommand, OfficerDataDomain>
    {
        private readonly ITowerDataService towerDataService;
        private readonly IOfficerDataService officerDataService;
        private readonly IUnitOfWork unitOfWork;

        public UpdateOfficerDataCommandHandler(ITowerDataService towerDataService,  IOfficerDataService officerDataService,  IUnitOfWork unitOfWork)
        {
            this.towerDataService = towerDataService;
            this.officerDataService = officerDataService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<OfficerDataDomain> Handle(UpdateOfficerDataCommand command, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
          
                var towerData = await towerDataService.GetByIdAsync(command.model.TowerDataId);

                if (towerData == null)
                {
                    throw new Exception(
                        $"TowerData with Id {command.model.TowerDataId} not found.");
                }
                towerData.AirLineId = command.model?.TowerData?.AirLineId;
                towerData.FlightNoName = command.model?.TowerData?.FlightNoName;
                towerData.AircraftRegId = command.model?.TowerData?.AircraftRegId;
                towerData.AirportIdFrom = command.model?.TowerData?.AirportIdFrom;
                towerData.AirportIdTo = command.model?.TowerData?.AirportIdTo;
                towerData.LandingDate = command.model?.TowerData?.LandingDate;
                towerData.TakeOffDate =  command.model?.TowerData?.TakeOffDate;
                towerData.Status = command.model?.TowerData?.Status;
                towerData.Date = command.model?.TowerData?.Date;
                towerData.Ata =  command.model?.TowerData?.Ata;
                towerData.Atd = command.model?.TowerData?.Atd;
                towerData.TripTypeId = command.model?.TowerData?.TripTypeId;

                towerData.CompanyInfoId = command.model?.TowerData?.CompanyInfoId;
                int status = await towerDataService.GetStatusOfficer(towerData);
                towerData.Status = status;
                towerData.TripTypeId = 1; // default value for TripTypeId   
                await towerDataService.UpdateAsync(towerData);

                // ==============================
                // 4. Keep TowerDataId
                // ==============================

                command.model.TowerDataId = towerData.Id;

                // ==============================
                // 5. Update OfficerData
                // ==============================
                if (command.model.AireLineAgentId <= 0) { command.model.AireLineAgentId = null; }
                if (command.model.CompanyInfoId <= 0) { command.model.CompanyInfoId = null; }

                var officerResult = await officerDataService.UpdateAsync(command.model);

                // ==============================
                // 6. Commit transaction
                // ==============================

                await unitOfWork.CommitAsync();

                return officerResult;
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}