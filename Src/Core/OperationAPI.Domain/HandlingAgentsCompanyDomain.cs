using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{
    public class HandlingAgentsCompanyDomain : BaseDomain
    {
        public int? AccId { get; set; }

        public int? CurrencyId { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? NameAr { get; set; }

        public string? NameEn { get; set; }

        public string? Address { get; set; }

        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatingDate { get; set; }

    }
}
