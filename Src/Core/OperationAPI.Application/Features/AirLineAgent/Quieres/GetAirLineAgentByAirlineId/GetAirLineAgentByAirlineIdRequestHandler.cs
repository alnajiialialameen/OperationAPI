using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.AirLineAgent.Quieres.GetAirLineAgentByAirlineId
{
   

    class GetAirLineAgentByAirlineIdRequestHandler : IRequestHandler<GetAirLineAgentByAirlineIdRequest, List<AirLineAgentDomain>>
    {
        private readonly IAirlineAgentService service;

        public GetAirLineAgentByAirlineIdRequestHandler(IAirlineAgentService service)
        {
            this.service = service;
        }

        public async Task<List<AirLineAgentDomain>> Handle(GetAirLineAgentByAirlineIdRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetAirLineAgentByAirlineId(request.AirlineId);


            if (data == null)
            {
                // throw new Exception
                data = new List<AirLineAgentDomain>();  //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }







}
