using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.FuelCompany.Command.CreateFuelCompany
{
   
    public class CreateFuelCompanyCommandHandler : IRequestHandler<CreateFuelCompanyCommand, FuelCompanyDomain>
    {
        private readonly IFuelCompanyService service;
        public CreateFuelCompanyCommandHandler(IFuelCompanyService service)
        {
            this.service = service;
        }

        public async Task<FuelCompanyDomain> Handle(CreateFuelCompanyCommand request, CancellationToken cancellationToken)
        {
            var obj = await service.CreateAsync(request.model);
            return obj;
        }
    }

}
