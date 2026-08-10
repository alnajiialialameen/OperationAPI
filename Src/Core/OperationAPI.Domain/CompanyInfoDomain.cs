using OperationAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Domain
{
   public class CompanyInfoDomain : BaseDomain
    {   
        public string? NameAr { get; set; }

        public string? NameEn { get; set; }

        public string? Code { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool IsActive { get; set; }
    }
}
