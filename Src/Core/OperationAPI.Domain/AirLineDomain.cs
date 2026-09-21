using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{
   public class AirLineDomain : BaseDomain
    {
        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? ArName { get; set; }

        public string? Address { get; set; }

        public int? AccId { get; set; }

        public bool IsLocalCompany { get; set; }

        public int? CurrencyType { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatingDate { get; set; }
    }
}
