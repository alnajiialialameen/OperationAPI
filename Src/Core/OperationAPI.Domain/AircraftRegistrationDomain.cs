using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{
   public class AircraftRegistrationDomain : BaseDomain
    {
        public string Registration { get; set; } = null!;

        public int? AircraftTypeId { get; set; }

        public decimal? MaxTakoffWieght { get; set; }

        public int? AireLineId { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatingDate { get; set; }

        public  AircraftTypeDomain? AircraftType { get; set; }
    }
}
