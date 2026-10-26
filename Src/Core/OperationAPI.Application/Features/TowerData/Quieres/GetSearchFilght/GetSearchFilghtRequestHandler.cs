using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.TowerData.Quieres.GetOfficerDataById;
using OperationAPI.Application.Models;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Quieres.GetSearchFilght
{
   

    class GetSearchFilghtRequestHandler : IRequestHandler<GetSearchFilghtRequest, List<TowerDataViewDomain>>
    {
        private readonly ITowerDataService service;

        public GetSearchFilghtRequestHandler(ITowerDataService service)
        {
            this.service = service;
        }

        public async Task<List<TowerDataViewDomain>> Handle(GetSearchFilghtRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetSearchFilght(request.model);
            if (data == null)
            {
                // throw new Exception
                data = new List<TowerDataViewDomain>();  //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }










}
