using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.CompanyInfo.Command.UpdateCompanyInfo
{
    public class UpdateCompanyInfoCommandHandler : IRequestHandler<UpdateCompanyInfoCommand, CompanyInfoDomain>
    {
        private readonly ICompanyInfoSercice service;
        public UpdateCompanyInfoCommandHandler(ICompanyInfoSercice service)
        {
            this.service = service;
        }
        public async Task<CompanyInfoDomain> Handle(UpdateCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            var obj = await service.UpdateAsync(request.model);
            return obj;
        }
    }
}
