using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAircraftRegisterationById
{
    class GetAircraftRegisterationByIdRequestHandler : IRequestHandler<GetAircraftRegisterationByIdRequest, AircraftRegistrationDomain>
    {
        private readonly IAircraftRegistration service;

        public GetAircraftRegisterationByIdRequestHandler(IAircraftRegistration service) 
        {
            this.service = service;
        }

        public async Task<AircraftRegistrationDomain> Handle(GetAircraftRegisterationByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await service.GetByIdAsync(request.Id);
            if (data == null)
            {
                // throw new Exception
                data = new AircraftRegistrationDomain();  //لو مافي يجب لي بيانات فاضية
            }

            return data;
        }
    }
}
