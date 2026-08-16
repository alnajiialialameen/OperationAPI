using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.CompanyInfo.Command.CreateCompanyInfo
{
    internal class CreateCompanyInfoCommandHandler : IRequestHandler<CreateCompanyInfoCommand, CompanyInfoDomain>
    {
        private readonly ICompanyInfoSercice service;
        public CreateCompanyInfoCommandHandler(ICompanyInfoSercice service)
        {
            this.service = service;
        }
        public async Task<CompanyInfoDomain> Handle(CreateCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            var obj = await service.CreateAsync(request.model);
            return obj;
        }
    }
}
