using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.Country.Quieres.GetByIdCountry
{
    public class GetByIdCountryRequestHandler : IRequestHandler<GetByIdCountryRequest, CountryDomain>
    {private readonly ICountryService service;

        public GetByIdCountryRequestHandler(ICountryService service)
        {
            this.service = service;
        }
        public async Task<CountryDomain> Handle(GetByIdCountryRequest request, CancellationToken cancellationToken)
        {
            var res = await service.GetByIdAsync(request.id);
            return res;
        }
    }
}
