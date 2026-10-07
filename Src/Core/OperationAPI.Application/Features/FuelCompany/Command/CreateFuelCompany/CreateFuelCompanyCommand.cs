using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.FuelCompany.Command.CreateFuelCompany
{
  
    public class CreateFuelCompanyCommand : IRequest<FuelCompanyDomain>
    {
        public CreateFuelCompanyCommand(FuelCompanyDomain model)
        {
            this.model = model;
        }
        public FuelCompanyDomain model { get; set; }
    }
}

