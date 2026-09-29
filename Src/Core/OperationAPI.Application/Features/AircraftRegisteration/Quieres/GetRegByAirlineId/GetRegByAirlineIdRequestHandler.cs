using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAircraftRegisterationById;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetRegByAirlineId
{
   
    class GetRegByAirlineIdRequestHandler : IRequestHandler<GetRegByAirlineIdRequest, List<AircraftRegistrationDomain>>
    {
        private readonly IAircraftRegistrationService service;

        public GetRegByAirlineIdRequestHandler(IAircraftRegistrationService service)
        {
            this.service = service;
        }

        public async Task<List<AircraftRegistrationDomain>> Handle(GetRegByAirlineIdRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetRegistrationByAirlineId(request.AirlineId);

         
            if (data == null)
            {
                // throw new Exception
                data = new List<AircraftRegistrationDomain>();  //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }











}
