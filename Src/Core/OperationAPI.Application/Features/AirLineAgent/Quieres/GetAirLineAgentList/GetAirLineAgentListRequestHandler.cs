using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.AirLineAgent.Quieres.GetAirLineAgentList
{
   

    public class GetAirLineAgentListRequestHandler : IRequestHandler<GetAirLineAgentListRequest, List<ListDomain>>
    {
        private readonly IAirlineAgentService service;
        public GetAirLineAgentListRequestHandler(IAirlineAgentService service)
        {
            this.service = service;
        }

        public async Task<List<ListDomain>> Handle(GetAirLineAgentListRequest request, CancellationToken cancellationToken)
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
