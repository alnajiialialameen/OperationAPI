using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftType.Quieres.GetAllAircraftType
{
    public class GetAllAircraftTypeRequestHandler :IRequestHandler<GetAllAircraftTypeRequest,List<AircraftTypeDomain>>
    {
        private readonly IAircraftTypeService service;
        public GetAllAircraftTypeRequestHandler(IAircraftTypeService service)
        {
            this.service = service;
        }

        public async Task<List<AircraftTypeDomain>> Handle(GetAllAircraftTypeRequest request, CancellationToken cancellationToken)
        {
          var res= await service.GetAsync();
            if (!res.Any())
            {
                res = new List<AircraftTypeDomain>();
             }
            return res;
        }
    }
}
