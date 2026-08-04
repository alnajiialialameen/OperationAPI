using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Quieres.GetByIdAircraftSize
{
    class GetByIdAircraftSizeRequestHandler : IRequestHandler<GetByIdAircraftSizeRequest , AircraftSizeDomain>
    {
        private readonly IAircraftSizeService service;
        public GetByIdAircraftSizeRequestHandler(IAircraftSizeService service)
        {
            this.service = service;
        }

        public async Task<AircraftSizeDomain> Handle(GetByIdAircraftSizeRequest request, CancellationToken cancellationToken)
        {
            var obj = await service.GetByIdAsync(request.Id);
            return obj;
        }
    }
}
