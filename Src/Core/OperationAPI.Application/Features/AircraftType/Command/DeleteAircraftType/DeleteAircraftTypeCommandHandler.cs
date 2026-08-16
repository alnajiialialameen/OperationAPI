using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftType.Command.DeleteAircraftType
{
    public class DeleteAircraftTypeCommandHandler : IRequestHandler<DeleteAircraftTypeCommand, bool>
    {
       private readonly IAircraftTypeService service;

        public DeleteAircraftTypeCommandHandler(IAircraftTypeService service)
        {
            this.service = service;
        }
        public async Task<bool> Handle(DeleteAircraftTypeCommand request, CancellationToken cancellationToken)
        {
            var ObjDelete = await service.GetByIdAsync(request.Id);

            if (ObjDelete == null)
            {
                // throw new Exception
                throw new NotFoundException(nameof(AircraftTypeDomain), $" With Id = [{request.Id}]");
            }

            // exe
            var res = await service.DeleteAsync(ObjDelete);

            // return
            return res;
        }
    }
}
