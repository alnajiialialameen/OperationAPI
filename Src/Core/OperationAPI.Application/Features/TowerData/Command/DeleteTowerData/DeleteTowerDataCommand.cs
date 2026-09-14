using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.DeleteTowerData
{
  
    public record DeleteTowerDataCommand(int Id) : IRequest<bool>;

}
