using MediatR;
using OperationAPI.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.CompanyInfo.Command.DeleteCompanyInfo
{
    public class DeleteCompanyInfoCommandHandler : IRequestHandler<DeleteCompanyInfoCommand, bool>
    {
        private ICompanyInfoSercice service;
        public DeleteCompanyInfoCommandHandler(ICompanyInfoSercice service)
        {
            this.service = service;
        }
        public async Task<bool> Handle(DeleteCompanyInfoCommand request, CancellationToken cancellationToken)
        {

            var ObjDelete = await service.GetByIdAsync(request.Id);
            var res = await service.DeleteAsync(ObjDelete);
            return res;
        }
    }
}
