using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{
   public class WorkOnDomain : BaseDomain
    {
        public string? UserId { get; set; }

        public int? YearWorkOn { get; set; }

        public int? MonthWorkOn { get; set; }

        public int? CompanyInfoId { get; set; }
    }
}
