using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.Country.Quieres.GetAllCountry
{
    public class GetAllCountryRequestHandler : IRequestHandler<GetAllCountryRequest, List<CountryDomain>>
    {
        private readonly ICountryService service;
        public GetAllCountryRequestHandler(ICountryService service)
        {
            this.service = service;
            
        }
        public async Task<List<CountryDomain>> Handle(GetAllCountryRequest request, CancellationToken cancellationToken)
        {
            var res = await service.GetAsync();
            if (!res.Any())
            {
                res = new List<CountryDomain>();
            }
            return res;
        }
    }
}
