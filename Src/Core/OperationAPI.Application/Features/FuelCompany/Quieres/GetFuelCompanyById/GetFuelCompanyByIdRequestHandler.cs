using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.FuelCompany.Quieres.GetFuelCompanyById
{
  
    class GetFuelCompanyByIdRequestHandler : IRequestHandler<GetFuelCompanyByIdRequest, FuelCompanyDomain>
    {
        private readonly IFuelCompanyService service;
        public GetFuelCompanyByIdRequestHandler(IFuelCompanyService service)
        {
            this.service = service;
        }

        public async Task<FuelCompanyDomain> Handle(GetFuelCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var obj = await service.GetByIdAsync(request.Id);
            return obj;
        }
    }




}
