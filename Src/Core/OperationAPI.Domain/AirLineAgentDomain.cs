using OperationAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Domain
{
    public class AirLineAgentDomain : BaseDomain
    {
        public string? NameAr { get; set; }

        public string? NameAn { get; set; }

        public string? Phone1 { get; set; }

        public string? Phone2 { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public int? AirLineId { get; set; }

        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatingDate { get; set; }
    }
}
