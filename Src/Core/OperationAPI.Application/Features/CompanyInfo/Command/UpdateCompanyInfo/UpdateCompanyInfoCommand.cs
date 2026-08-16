using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.CompanyInfo.Command.UpdateCompanyInfo
{
    public class UpdateCompanyInfoCommand : IRequest<CompanyInfoDomain>
    {
        public UpdateCompanyInfoCommand(CompanyInfoDomain model)
        {
            this.model = model;
        }

        public CompanyInfoDomain model { get; set; }
    }
}
