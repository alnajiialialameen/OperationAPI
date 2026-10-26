using MediatR;
using OperationAPI.Application.Contracts.FidsAPIServices;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.TowerData.Quieres.GetFilghtLocalNotComplate;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.ServiceRequestDetail.Quieres.GetRequestDetailByTowerId
{
   


    public class GetRequestDetailByTowerIdRequestHandler : IRequestHandler<GetRequestDetailByTowerIdRequest, List<ServiceRequestDetailViewDomain>>
    {
        private readonly IServiceRequestDetailService service;
       

        public GetRequestDetailByTowerIdRequestHandler(IServiceRequestDetailService service)
        {
            this.service = service;
        }


        public async Task<List<ServiceRequestDetailViewDomain>> Handle(GetRequestDetailByTowerIdRequest request, CancellationToken cancellationToken)
        {
            // 1. جلب البيانات المحلية
            var localData = await service.GetIServiceRequestDetailServiceByTowerId(request.TowerId);



            return localData;
        }



    }
}
