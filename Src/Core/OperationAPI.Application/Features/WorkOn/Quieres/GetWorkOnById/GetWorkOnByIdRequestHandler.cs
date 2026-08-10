using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Quieres.GetWorkOnById
{
   public class GetWorkOnByIdRequestHandler : IRequestHandler<GetWorkOnByIdRequest, WorkOnDomain>
    {
        private readonly IWorkOnService service;
        public GetWorkOnByIdRequestHandler(IWorkOnService service)
        {
            this.service = service;
        }
        public async Task<WorkOnDomain> Handle(GetWorkOnByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await service.GetByIdAsync(request.Id);
            return result;
        }
    }
}
