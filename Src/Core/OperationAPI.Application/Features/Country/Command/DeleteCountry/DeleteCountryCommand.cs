using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.Country.Command.DeleteCountry
{
    public record DeleteCountryCommand (int id):IRequest<bool>
    {
    }
}
