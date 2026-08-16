using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Command.CreateAircraftSize
{
   public class CreateAircraftSizeCommandHandler : IRequestHandler<CreateAircraftSizeCommand , AircraftSizeDomain>
    {
        private readonly IAircraftSizeService service;
        public CreateAircraftSizeCommandHandler(IAircraftSizeService service)
        {
            this.service = service;
        }

        public async Task<AircraftSizeDomain> Handle(CreateAircraftSizeCommand request, CancellationToken cancellationToken)
        {
            var obj = await service.CreateAsync(request.model);
            return obj;
        }
    }
}
