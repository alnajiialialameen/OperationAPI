using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.HandlingAgentsCompany.Command.CreateHandlingAgentsCompany
{
    public class CreateHandlingAgentsCompanyCommand : IRequest<HandlingAgentsCompanyDomain>
    {
        public CreateHandlingAgentsCompanyCommand(HandlingAgentsCompanyDomain model)
        {
            this.model = model;

        }
        public HandlingAgentsCompanyDomain model {  get; set; }
    }
}
