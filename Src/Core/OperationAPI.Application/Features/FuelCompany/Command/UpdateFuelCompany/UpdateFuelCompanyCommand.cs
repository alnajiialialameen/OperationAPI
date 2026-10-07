using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.FuelCompany.Command.UpdateFuelCompany
{
   
    public class UpdateFuelCompanyCommand : IRequest<FuelCompanyDomain>
    {
        public UpdateFuelCompanyCommand(FuelCompanyDomain model)
        {
            this.model = model;
        }
        public FuelCompanyDomain model { get; set; }
    }







}
