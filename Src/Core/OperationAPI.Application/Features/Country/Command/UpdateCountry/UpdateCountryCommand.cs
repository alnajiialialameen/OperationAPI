using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.Country.Command.UpdateCountry
{
    public class UpdateCountryCommand:IRequest<CountryDomain>
    {
        public CountryDomain model { get; set; }
        public UpdateCountryCommand(CountryDomain model)
        {
            this.model = model;
            
        }

        
    }
}
