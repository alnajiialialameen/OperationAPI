using OperationAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Domain
{
   public class ServiceRequestDomain :BaseDomain
    {

        public int? OfficerDataId { get; set; }

        public int? AirlineId { get; set; }
    }
}
