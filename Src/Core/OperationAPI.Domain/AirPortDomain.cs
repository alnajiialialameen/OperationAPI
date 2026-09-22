using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{
    public class AirPortDomain : BaseDomain
    {
        public string? NameAr { get; set; }

        public string? NameEn { get; set; }

        public string? Code { get; set; }

        public int? CountryId { get; set; }

        public string? CountryName { get; set; }
    }
}
