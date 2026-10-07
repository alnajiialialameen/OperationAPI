using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.FuelCompany.Command.DeleteFuelCompany
{

    public record DeleteFuelCompanyCommand(int Id) : IRequest<bool>;
    
    
}
