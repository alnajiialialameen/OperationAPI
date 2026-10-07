using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.FuelCompany.Command.DeleteFuelCompany
{
  

    public class DeleteFuelCompanyCommandHandler : IRequestHandler<DeleteFuelCompanyCommand, bool>
    {
        private readonly IFuelCompanyService service;

        public DeleteFuelCompanyCommandHandler(IFuelCompanyService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(DeleteFuelCompanyCommand command, CancellationToken cancellationToken)
        {
            // validation   
            var ObjDelete = await service.GetByIdAsync(command.Id);

            if (ObjDelete == null)
            {
                // throw new Exception
                throw new NotFoundException(nameof(FuelCompanyDomain), $" With Id = [{command.Id}]");
            }

            // exe
            var res = await service.DeleteAsync(ObjDelete);

            // return
            return res;
        }
    }








}
