using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.TowerData.Command.DeleteTowerData;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.ConfirmedOfficer
{
   

    public class ConfirmedOfficerCommandHandler : IRequestHandler<ConfirmedOfficerCommand, bool>
    {
        private readonly ITowerDataService service;


        public ConfirmedOfficerCommandHandler(ITowerDataService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(ConfirmedOfficerCommand command, CancellationToken cancellationToken)
        {
            // validation   
            var Objresult = await service.ConfirmedOfficer(command.Id);

            // return
            return Objresult;
        }
    }










}
