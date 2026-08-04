using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Quieres.GetAllAircraftSize
{
    public record GetAllAircraftSizeRequest : IRequest<List<AircraftSizeDomain>>
    { 
    }
}
