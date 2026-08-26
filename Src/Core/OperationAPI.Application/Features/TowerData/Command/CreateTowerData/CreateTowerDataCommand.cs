using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.CreateTowerData
{
    

    public class CreateTowerDataCommand : IRequest<TowerDataDomain>
    {
        public CreateTowerDataCommand(TowerDataDomain model)
        {
            this.model = model;
        }
        public TowerDataDomain model { get; set; }

    }
}
