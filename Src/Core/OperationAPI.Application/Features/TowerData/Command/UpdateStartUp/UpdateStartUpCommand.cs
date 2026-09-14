using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.UpdateTowerData
{
   

    public class UpdateStartUpCommand : IRequest<TowerDataDomain>
    {
        public UpdateStartUpCommand(InitialDataDomain model)
        {
            this.model = model;
        }

        public InitialDataDomain model { get; set; }
    }
}
