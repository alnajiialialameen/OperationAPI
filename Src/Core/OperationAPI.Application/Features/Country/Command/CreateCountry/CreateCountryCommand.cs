using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.Country.Command.CreateCountry
{
    public class CreateCountryCommand:IRequest<CountryDomain>
    {
        public CountryDomain model { get; set; }
        public CreateCountryCommand(CountryDomain model)
        {
            this.model = model;
        }
    }
}
