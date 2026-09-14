using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.TowerData.Command.DeleteTowerData
{
  


    public class DeleteTowerDataCommandHandler : IRequestHandler<DeleteTowerDataCommand, bool>
    {
        private readonly IAircraftRegistrationService service;


        public DeleteTowerDataCommandHandler(IAircraftRegistrationService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(DeleteTowerDataCommand command, CancellationToken cancellationToken)
        {
            // validation   
            var ObjDelete = await service.GetByIdAsync(command.Id);

            if (ObjDelete == null)
            {
                // throw new Exception
                throw new NotFoundException(nameof(TowerDataDomain), $" With Id = [{command.Id}]");
            }

            // exe
            var res = await service.DeleteAsync(ObjDelete);

            // return
            return res;
        }
    }







}
