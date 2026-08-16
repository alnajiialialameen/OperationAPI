using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.CompanyInfo.Quieres.GetByIdCompanyInfo
{
    public record GetByIdCompanyInfoRequest(int Id) : IRequest<CompanyInfoDomain>
    {
    }
}
