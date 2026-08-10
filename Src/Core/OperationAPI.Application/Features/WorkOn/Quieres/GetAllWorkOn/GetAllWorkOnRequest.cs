using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Quieres.GetAllWorkOn
{
   public record GetAllWorkOnRequest : IRequest<List<WorkOnDomain>>
    {

    }
}
