using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.FuelCompany.Quieres.GetFuelCompanyForList
{
 
    public class GetFuelCompanyForListRequestHandler : IRequestHandler<GetFuelCompanyForListRequest, List<ListDomain>>
    {
        private readonly IFuelCompanyService service;
        public GetFuelCompanyForListRequestHandler(IFuelCompanyService service)
        {
            this.service = service;
        }

        public async Task<List<ListDomain>> Handle(GetFuelCompanyForListRequest request, CancellationToken cancellationToken)
        {
            var data = await service.getList();
            if (data == null)
            {
                // throw new Exception
                data = new List<ListDomain>();   //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }















}
