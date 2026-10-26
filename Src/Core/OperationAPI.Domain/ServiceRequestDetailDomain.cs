using OperationAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Domain
{
   public class ServiceRequestDetailDomain : BaseDomain
    {
       
        //public int? ServiceRequestId { get; set; }
        public int? ServiceTypeId { get; set; }

        public int? CountOfRequests { get; set; }
        public int? TowerDataId { get; set; }

        public int? AirlineId { get; set; }

        public DateTime? RequestedAt { get; set; }

        public string? RequestedBy { get; set; }

        public DateTime? AcceptedAt { get; set; }

        public string? AcceptedBy { get; set; }

        public DateTime? ConfirmAgentAt { get; set; }

        public string? ConfirmAgentBy { get; set; }
        //public ServiceRequestDomain? ServiceRequestDomain { get; set; }

        //public ServiceTypeDomain? ServiceTypeDomain { get; set; }
    }

    public class RequestDetailDomain : BaseDomain
    {

        public int? ServiceTypeId { get; set; }
        public int? RequestStatus { get; set; }
    }


    public class ServiceRequestDetailViewDomain : BaseDomain
    {
        public int? ServiceTypeId { get; set; }
        public string? ServiceTypeName { get; set; } // تم التعديل من int? إلى string?

        public int? CountOfRequests { get; set; }
        public int? TowerDataId { get; set; }

        public int? AirlineId { get; set; }
        public string? AirlineName { get; set; } // تم التعديل من int? إلى string?

        public DateTime? RequestedAt { get; set; }
        public string? RequestedBy { get; set; }
        public DateTime? AcceptedAt { get; set; }
        public string? AcceptedBy { get; set; }
        public DateTime? ConfirmAgentAt { get; set; }
        public string? ConfirmAgentBy { get; set; }
    }

    public class confirmServiceDetailDomain : BaseDomain
    {
        public DateTime? At { get; set; }
        public string? By { get; set; }
    
    }

}
