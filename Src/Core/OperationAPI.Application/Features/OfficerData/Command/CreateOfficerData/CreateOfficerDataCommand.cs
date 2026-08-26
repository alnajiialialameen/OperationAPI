using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.OfficerData.Command.CreateOfficerData
{
  
    public class CreateOfficerDataCommand : IRequest<OfficerDataDomain>
    {
        public CreateOfficerDataCommand(OfficerDataDomain model)
        {
            this.model = model;
        }
        public OfficerDataDomain model { get; set; }

    }
}
