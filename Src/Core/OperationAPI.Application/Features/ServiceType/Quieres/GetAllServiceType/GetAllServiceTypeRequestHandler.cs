using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.ServiceType.Quieres.GetAllServiceType
{
   


    public class GetAllServiceTypeRequestHandler : IRequestHandler<GetAllServiceTypeRequest, List<ServiceTypeDomain>>
    {
        private readonly IServiceTypeService service;

        public GetAllServiceTypeRequestHandler(IServiceTypeService service)
        {
            this.service = service;
        }

        public async Task<List<ServiceTypeDomain>> Handle(GetAllServiceTypeRequest request, CancellationToken cancellationToken)
        {
            var ob = await service.GetAsync();
            return ob;
        }
    }









}
