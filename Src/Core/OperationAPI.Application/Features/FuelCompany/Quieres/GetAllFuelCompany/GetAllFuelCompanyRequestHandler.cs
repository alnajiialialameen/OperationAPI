using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.FuelCompany.Quieres.GetAllFuelCompany
{
   
    public class GetAllFuelCompanyRequestHandler : IRequestHandler<GetAllFuelCompanyRequest, List<FuelCompanyDomain>>
    {
        private readonly IFuelCompanyService service;

        public GetAllFuelCompanyRequestHandler(IFuelCompanyService service)
        {
            this.service = service;
        }

        public async Task<List<FuelCompanyDomain>> Handle(GetAllFuelCompanyRequest request, CancellationToken cancellationToken)
        {
            var ob = await service.GetAsync();
            return ob;
        }
    }







}
