using OperationAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Domain
{
   public class ServiceTypeDomain : BaseDomain
    {

        public string? NameAr { get; set; }

        public string? NameEn { get; set; }

        public bool? IsActive { get; set; }

        public string? LogoCode { get; set; }
    }
}
