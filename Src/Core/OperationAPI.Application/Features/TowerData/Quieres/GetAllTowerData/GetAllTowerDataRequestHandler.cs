using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.TowerData.Quieres.GetAllTowerData
{
   
    public class GetAllTowerDataRequestHandler : IRequestHandler<GetAllTowerDataRequest, List<TowerDataDomain>>
    {
        private readonly ITowerDataService service;
        public GetAllTowerDataRequestHandler(ITowerDataService service)
        {
            this.service = service;
        }

        public async Task<List<TowerDataDomain>> Handle(GetAllTowerDataRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetAsync();
            if (data == null)
            {
                // throw new Exception
                data = new List<TowerDataDomain>();   //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }

}
