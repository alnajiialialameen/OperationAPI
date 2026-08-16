using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.CompanyInfo.Quieres.GetByIdCompanyInfo
{
    public class GetByIdCompanyInfoRequestHandler : IRequestHandler<GetByIdCompanyInfoRequest, CompanyInfoDomain>
    {
        private readonly ICompanyInfoSercice service;
        public GetByIdCompanyInfoRequestHandler(ICompanyInfoSercice service)
        {
            this.service = service;
        }
        public async Task<CompanyInfoDomain> Handle(GetByIdCompanyInfoRequest request, CancellationToken cancellationToken)
        {
            var obj = await service.GetByIdAsync(request.Id);
            return obj;
        }
    }
}
