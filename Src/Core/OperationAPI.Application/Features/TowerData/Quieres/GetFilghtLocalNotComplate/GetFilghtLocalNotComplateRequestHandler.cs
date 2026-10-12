using MediatR;
using OperationAPI.Application.Contracts.FidsAPIServices;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Domain.FidsAPI;

namespace OperationAPI.Application.Features.TowerData.Quieres.GetFilghtLocalNotComplate
{
  
    public class GetFilghtLocalNotComplateRequestHandler : IRequestHandler<GetFilghtLocalNotComplateRequest, List<TowerDataViewDomain>>
    {
        private readonly ITowerDataService service;
        private readonly IConsumeFidsAPIService FidsAPIService;

        public GetFilghtLocalNotComplateRequestHandler(ITowerDataService service, IConsumeFidsAPIService FidsAPIService)
        {
            this.service = service;
            this.FidsAPIService = FidsAPIService;
        }
        

        public async Task<List<TowerDataViewDomain>> Handle(GetFilghtLocalNotComplateRequest request, CancellationToken cancellationToken)
        {
            // 1. جلب البيانات المحلية
            var localData = await service.GetFilghtLocalNotComplate(request.AirLineId);

           

            return localData;
        }



    }











}
