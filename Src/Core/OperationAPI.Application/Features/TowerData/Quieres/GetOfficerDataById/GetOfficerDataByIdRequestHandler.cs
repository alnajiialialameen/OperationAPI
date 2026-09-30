using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.TowerData.Quieres.GetTowerDataById;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Quieres.GetOfficerDataById
{
  
    class GetOfficerDataByIdRequestHandler : IRequestHandler<GetOfficerDataByIdRequest, OfficerDataDomain>
    {
        private readonly ITowerDataService service;

        public GetOfficerDataByIdRequestHandler(ITowerDataService service)
        {
            this.service = service;
        }

        public async Task<OfficerDataDomain> Handle(GetOfficerDataByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetOfficerDataById(request.Id);
            if (data == null)
            {
                // throw new Exception
                data = new OfficerDataDomain();  //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }









}
