using OperationAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Domain
{
   public class FlightDataDomain :BaseDomain 
    {

        // TowerData
        public int? AirLineId { get; set; }

        public int? FlightNo { get; set; }

        public int? AircraftRegId { get; set; }

        public int? AirportIdFrom { get; set; }

        public int? AirportIdTo { get; set; }

        public int? FlightTypeD { get; set; }

        public int? FlightTypeL { get; set; }

        public DateTime? LandingDate { get; set; }

        public DateTime? TakeOffDate { get; set; }

        public int? Status { get; set; }

        public DateOnly? Date { get; set; }

        public TimeOnly? Ata { get; set; }

        public TimeOnly? Atd { get; set; }

        public int? Pob { get; set; }

        public int? Qbd { get; set; }

        public int? TripTypeId { get; set; }

        //public string? LandingPermission { get; set; }

        public int? CompanyInfoId { get; set; }

        public string? Note { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatingDate { get; set; }




        //officer Data
        public int? TowerDataId { get; set; }

        public int? CrewNo { get; set; }

        public bool HasNightStop { get; set; }

        public int? HandlingAgentId { get; set; }

        public int? FuelCompanyId { get; set; }

        /// Pax-------
        public int? Trnycupps { get; set; }

        public int? Trny { get; set; }

        public int? Trnone { get; set; }

        public int? Emb { get; set; }

        public int? EmbInft { get; set; }

        public int? Disemb { get; set; }

        public int? DisEmbInft { get; set; }

        public int? PaxInter { get; set; }
        public int? Pax { get; set; }

        public bool? IsNotUsedCupps { get; set; }

        //------------end pax
        public int? FirstClassCount { get; set; }   // FirstClass

        ///  mail And Frirght
        public int? FreightLoadingExp { get; set; }

        public int? FreightLoadingImp { get; set; }

        public decimal? NormalMailLoadingExp { get; set; }

        public decimal? RapidMailLoadingExp { get; set; }

        public decimal? NormalMailLoadingImp { get; set; }

        public decimal? RapidMailLoadingImp { get; set; }

        public int? AmbulanceCarCount { get; set; }

        public int? FireFightingCarCount { get; set; }

        //public int? ServiceCarReqId { get; set; }

        public bool IsCurrentAccount { get; set; }

        public decimal? FuelLiter { get; set; }

        public int? AireLineAgentId { get; set; }

      //  public int? CompanyInfoId { get; set; }

        public bool? HasPushPack { get; set; }


      

      

      

        //public bool? IsClaimCalculated { get; set; }


    }
}
