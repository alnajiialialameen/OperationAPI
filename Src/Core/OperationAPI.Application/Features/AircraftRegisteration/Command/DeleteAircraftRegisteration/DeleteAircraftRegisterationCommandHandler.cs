using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftRegisteration.Command.DeleteAircraftRegisteration
{
   public class DeleteAircraftRegisterationCommandHandler : IRequestHandler<DeleteAircraftRegisterationCommand,bool>
    {
        private readonly IAircraftRegistrationService service;


        public DeleteAircraftRegisterationCommandHandler(IAircraftRegistrationService service) 
        {
            this.service = service;
        }

        public async Task<bool> Handle(DeleteAircraftRegisterationCommand command, CancellationToken cancellationToken)
        {
            // validation   
            var ObjDelete = await service.GetByIdAsync(command.Id);

            if (ObjDelete == null)
            {
                // throw new Exception
                throw new NotFoundException(nameof(AircraftRegisteration), $" With Id = [{command.Id}]");
            }

            // exe
            var res = await service.DeleteAsync(ObjDelete);

            // return
            return res;
        }
    }
}
