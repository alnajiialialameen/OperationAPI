using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.HandlingAgentsCompany.Quieres.GetHandlingAgentForList
{

  
    public class GetHandlingAgentForListRequestHandler : IRequestHandler<GetHandlingAgentForListRequest, List<ListDomain>>
    {
        private readonly IHandlingAgentsCompanyService service;
        public GetHandlingAgentForListRequestHandler(IHandlingAgentsCompanyService service)
        {
            this.service = service;
        }

        public async Task<List<ListDomain>> Handle(GetHandlingAgentForListRequest request, CancellationToken cancellationToken)
        {
            var data = await service.getList();
            if (data == null)
            {
                // throw new Exception
                data = new List<ListDomain>();   //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }

}
