using OperationAPI.Domain.Common;

namespace OperationAPI.Domain
{
   public class TowerDataDomain : BaseDomain
    {
      
        public int? AirLineId { get; set; }

        public int? FlightNo { get; set; }

        public int? AircraftRegId { get; set; }

        //public int? AirportIdFrom { get; set; }

        public int? AirportIdTo { get; set; }

        //public int? FlightTypeD { get; set; }

        //public int? FlightTypeL { get; set; }

        //public DateTime? LandingDate { get; set; }

        public DateTime? TakeOffDate { get; set; }

        //public int? Status { get; set; }

        public DateOnly? Date { get; set; }

        public TimeOnly? Ata { get; set; }

        //public TimeOnly? Atd { get; set; }

        //public int? Pob { get; set; }

        //public int? Qbd { get; set; }

        //public int? TripTypeId { get; set; }

        //public string? LandingPermission { get; set; }

        public int? CompanyInfoId { get; set; }

        //public string? Note { get; set; }

        //public string? CreatedBy { get; set; }

        //public DateTime? CreationDate { get; set; }

        //public string? UpdatedBy { get; set; }

        //public DateTime? UpdatingDate { get; set; }
    }


    public class InitialDataDomain : BaseDomain
    {
        public int? AirLineId { get; set; }
        public int? FlightNo { get; set; }
        public int? AircraftRegId { get; set; }
        public int? AirportIdTo { get; set; }
        public DateOnly? Date { get; set; }
        public int? CompanyInfoId { get; set; }
    }



    public class DepartureInitialDomain : BaseDomain
    {
        public int? AircraftRegId { get; set; }
        public DateTime? TakeOffDate { get; set; }
        public TimeOnly? Atd { get; set; }
        //public int? CompanyInfoId { get; set; }

        //public int? TowerDataId { get; set; }


    }

    public class LandingInitialDomain : BaseDomain
    {
        public int? AircraftRegId { get; set; }
        public DateTime? LandingDate { get; set; }
        public TimeOnly? Ata { get; set; }
        //public int? CompanyInfoId { get; set; }

        //public int? TowerDataId { get; set; }


    }












}
