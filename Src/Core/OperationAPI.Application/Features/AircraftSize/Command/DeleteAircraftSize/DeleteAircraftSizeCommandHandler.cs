using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.AircraftRegisteration.Command.DeleteAircraftRegisteration;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Command.DeleteAircraftSize
{
 

    public class DeleteAircraftSizeCommandHandler : IRequestHandler<DeleteAircraftSizeCommand, bool>
    {
        private readonly IAircraftSizeService service;


        public DeleteAircraftSizeCommandHandler(IAircraftSizeService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(DeleteAircraftSizeCommand command, CancellationToken cancellationToken)
        {
            // validation   
            var ObjDelete = await service.GetByIdAsync(command.Id);

            if (ObjDelete == null)
            {
                // throw new Exception
                throw new NotFoundException(nameof(AircraftSizeDomain), $" With Id = [{command.Id}]");
            }

            // exe
            var res = await service.DeleteAsync(ObjDelete);

            // return
            return res;
        }
    }

}
