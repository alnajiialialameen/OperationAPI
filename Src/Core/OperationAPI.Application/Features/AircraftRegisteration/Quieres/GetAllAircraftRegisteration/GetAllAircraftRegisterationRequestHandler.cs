using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAllAircraftRegisteration
{
   public class GetAllAircraftRegisterationRequestHandler :IRequestHandler<GetAllAircraftRegisterationRequest, List<AircraftRegistrationDomain>>
    {
        private readonly IAircraftRegistration service;
        public GetAllAircraftRegisterationRequestHandler(IAircraftRegistration service)
        {
            this.service = service;
        }

        public async Task<List<AircraftRegistrationDomain>> Handle(GetAllAircraftRegisterationRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetAsync();
            if (data == null)
            {
                // throw new Exception
               data = new List<AircraftRegistrationDomain>();   //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }
}
