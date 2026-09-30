using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.TowerData.Quieres.GetTowerDataById;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Quieres.GetFlightByStatus
{
   
    class GetFlightByStatusRequestHandler : IRequestHandler<GetFlightByStatusRequest,List<TowerDataViewDomain>>
    {
        private readonly ITowerDataService service;

        public GetFlightByStatusRequestHandler(ITowerDataService service)
        {
            this.service = service;
        }

        public async Task<List<TowerDataViewDomain>> Handle(GetFlightByStatusRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetFlightByStatus(request.AirlineId, request.Statuses);
            if (data == null)
            {
                // throw new Exception
                data = new List<TowerDataViewDomain>();  //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }







}
