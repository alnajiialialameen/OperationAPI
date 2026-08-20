using OperationAPI.Domain.Common;

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

        public string? UserId { get; set; }

        public bool IsActive { get; set; }

        public AirLineDomain? AirLine { get; set; }

        //public virtual ICollection<AireCraftStyIn> AireCraftStyInAireLineAgentId1Navigations { get; set; } = new List<AireCraftStyIn>();

        //public virtual ICollection<AireCraftStyIn> AireCraftStyInAireLineAgentId2Navigations { get; set; } = new List<AireCraftStyIn>();

        //public virtual ICollection<OfficerDatum> OfficerData { get; set; } = new List<OfficerDatum>();
    }
}
