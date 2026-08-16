using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftType.Quieres.GetByIdAircraftType
{
    public class GetByIdAircraftTypeRequestHandler : IRequestHandler<GetByIdAircraftTypeRequest, AircraftTypeDomain>
    {

        private readonly IAircraftTypeService service;
        public GetByIdAircraftTypeRequestHandler(IAircraftTypeService service)
        {
            this.service = service;
            
        }

        public async Task<AircraftTypeDomain> Handle(GetByIdAircraftTypeRequest request, CancellationToken cancellationToken)
        {
            var res = await service.GetByIdAsync(request.id);
            return res;
        }
    }
}
