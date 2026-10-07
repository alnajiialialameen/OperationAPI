using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.OfficerData.Command.UpdateOfficerData
{
   
    public class UpdateOfficerDataCommand : IRequest<OfficerDataDomain>
    {
        public UpdateOfficerDataCommand(OfficerDataDomain model)
        {
            this.model = model;
        }
        public OfficerDataDomain model { get; set; }

    }
}
