using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.CompanyInfo.Quieres.GetAllCompanyInfo
{
    internal class GetAllCompanyInfoRequestHandler : IRequestHandler<GetAllCompanyInfoRequest, List<CompanyInfoDomain>>
    {
        private readonly ICompanyInfoSercice sercice;
        public GetAllCompanyInfoRequestHandler(ICompanyInfoSercice sercice)
        {
            this.sercice = sercice;
        }
        public async Task<List<CompanyInfoDomain>> Handle(GetAllCompanyInfoRequest request, CancellationToken cancellationToken)
        {
            var obj = await sercice.GetAsync();
            return obj;
        }
    }
}
