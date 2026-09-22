using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{
    public class CountryDomain:BaseDomain
    {
        public string? NameAr { get; set; }

        public string? NameEn { get; set; }

        public string? Code { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpadatingDate { get; set; }
    }
}
