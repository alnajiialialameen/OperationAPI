using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.CompanyInfo.Command.CreateCompanyInfo
{
    public class CreateCompanyInfoCommand : IRequest<CompanyInfoDomain>
    {
        public CreateCompanyInfoCommand(CompanyInfoDomain model)
        {
            this.model = model;
        }
        public CompanyInfoDomain model { get; set; }
    }
}
