using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Quieres.GetAllWorkOn
{
   public class GetAllWorkOnRequestHandler : IRequestHandler<GetAllWorkOnRequest, List<WorkOnDomain>>   
    {
        private readonly IWorkOnService service;
        public GetAllWorkOnRequestHandler(IWorkOnService service)
        {
            this.service = service;
        }
        public async Task<List<WorkOnDomain>> Handle(GetAllWorkOnRequest request, CancellationToken cancellationToken)
        {
            var result = await service.GetAsync();
            return result;
        }
    }
}
