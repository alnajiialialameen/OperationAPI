using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.HandlingAgentsCompany.Quieres.GetByIdHandlingAgentsCompany
{
    public record GetByIdHandlingAgentsCompanyRequest(int Id) : IRequest<HandlingAgentsCompanyDomain>
    {
    }
}
