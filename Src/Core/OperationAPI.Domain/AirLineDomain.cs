using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{
   public class AirLineDomain : BaseDomain
    {
        public string NameAr { get; set; } = null!;

        public string? NameEn { get; set; }

        public string? Code { get; set; }

        public string? Logo { get; set; }

        public string? Email { get; set; }
    }
}
