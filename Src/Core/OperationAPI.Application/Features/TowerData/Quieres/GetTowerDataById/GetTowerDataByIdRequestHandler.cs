using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.TowerData.Quieres.GetTowerDataById
{
  
    class GetTowerDataByIdRequestHandler : IRequestHandler<GetTowerDataByIdRequest, TowerDataDomain>
    {
        private readonly ITowerDataService service;

        public GetTowerDataByIdRequestHandler(ITowerDataService service)
        {
            this.service = service;
        }

        public async Task<TowerDataDomain> Handle(GetTowerDataByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetByIdAsync(request.Id);
            if (data == null)
            {
                // throw new Exception
                data = new TowerDataDomain();  //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }



}
