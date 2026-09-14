using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{

 

    public class CompanyInfoDomain : BaseDomain
    {
        public string? NameAr { get; set; }

        public string? NameEn { get; set; }

        public string? Code { get; set; }

        public string? Address { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        //public byte[]? Image { get; set; }

        public string? RevenuesManager { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatingDate { get; set; }

        public string? LandingSupervisor { get; set; }

        public string? ServiceCarSupervisor { get; set; }

        public string? InterCuupssupervisor { get; set; }

        public string? DomeCuupssupervisor { get; set; }

        public string? InterNysupervisor { get; set; }

        public string? DomeNysupervisor { get; set; }

        public string? FirstClassSupervisor { get; set; }

        public string? PushBackSupervisor { get; set; }

        public bool? IsSingleAccounting { get; set; }
    }
}
