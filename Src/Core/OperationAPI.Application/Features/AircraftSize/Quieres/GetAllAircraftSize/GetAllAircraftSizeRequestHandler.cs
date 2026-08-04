using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Quieres.GetAllAircraftSize
{
   public class GetAllAircraftSizeRequestHandler : IRequestHandler<GetAllAircraftSizeRequest,List<AircraftSizeDomain>>
    {
        private readonly IAircraftSizeService service;

        public GetAllAircraftSizeRequestHandler(IAircraftSizeService service)
        {
            this.service = service;
        }

        public async Task<List<AircraftSizeDomain>> Handle(GetAllAircraftSizeRequest request, CancellationToken cancellationToken)
        {
         var ob = await  service.GetAsync();
            return ob;
        }
    }
}
