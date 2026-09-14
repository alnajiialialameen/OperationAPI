using OperationAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Domain
{
   public class OfficerDataDomain : BaseDomain
    {
        public int? TowerDataId { get; set; }

        public int? CrewNo { get; set; }

        public bool HasNightStop { get; set; }

        public int? HandlingAgentId { get; set; }

        public int? FuelCompanyId { get; set; }

        public int? Trnycupps { get; set; }

        public int? Trny { get; set; }

        public int? Trnone { get; set; }

        public int? Emb { get; set; }

        public int? EmbInft { get; set; }

        public int? Disemb { get; set; }

        public int? DisEmbInft { get; set; }

        public int? Pax { get; set; }

        public int? FirstClassCount { get; set; }

        public DateTime? Date { get; set; }

        public int? FreightLoadingExp { get; set; }

        public int? FreightLoadingImp { get; set; }

        public decimal? NormalMailLoadingExp { get; set; }

        public decimal? RapidMailLoadingExp { get; set; }

        public decimal? NormalMailLoadingImp { get; set; }

        public decimal? RapidMailLoadingImp { get; set; }

        public int? AmbulanceCarCount { get; set; }

        public int? FireFightingCarCount { get; set; }

        public int? ServiceCarReqId { get; set; }

        public bool IsCurrentAccount { get; set; }

        public decimal? FuelLiter { get; set; }

        public int? AireLineAgentId { get; set; }

        public int? CompanyInfoId { get; set; }

        public bool? HasPushPack { get; set; }

        public bool? IsNotUsedCupps { get; set; }

        public string? Note { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatingDate { get; set; }

        public int? PaxInter { get; set; }

        public bool? IsClaimCalculated { get; set; }

        public TowerDataDomain? TowerData { get; set; }

    }


    public class DepartureServiceDomain : BaseDomain
    {
        public int? TowerDataId { get; set; }
        public int? HandlingAgentId { get; set; }
        public int? FuelCompanyId { get; set; }
        public decimal? FuelLiter { get; set; }
        public int? Pax { get; set; }
        public int? PaxInter { get; set; }
        public int? FirstClassCount { get; set; }
        public int? FreightLoadingExp { get; set; }
        public decimal? NormalMailLoadingExp { get; set; }
        public decimal? RapidMailLoadingExp { get; set; }
        public int? AmbulanceCarCount { get; set; }
        public int? FireFightingCarCount { get; set; }
      
        public bool? HasPushPack { get; set; }
    }


    public class LandingServiceDomain : BaseDomain
    {
        public int? TowerDataId { get; set; }
        //public int? HandlingAgentId { get; set; }

      
        public int? Disemb { get; set; }  //البالغين النازلين من الطائرة
        public int? DisEmbInft { get; set; }  //dis الاطقال النازلين  من الطائرة

        //public int? Pax { get; set; }
        public int? FreightLoadingImp { get; set; }
        public decimal? NormalMailLoadingImp { get; set; }
        public decimal? RapidMailLoadingImp { get; set; }
        //public int? AmbulanceCarCount { get; set; }

        //public int? FireFightingCarCount { get; set; }

        //public int? AireLineAgentId { get; set; }

        //public int? CompanyInfoId { get; set; }   

    }


}
