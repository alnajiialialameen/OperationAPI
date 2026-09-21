using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{
    public class AircraftTypeDomain : BaseDomain
    {
        public string? Type { get; set; }

        public int? SizeId { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatingDate { get; set; }

        public AircraftSizeDomain? Size { get; set; }

    }
}
