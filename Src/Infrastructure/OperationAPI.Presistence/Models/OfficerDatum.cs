using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class OfficerDatum
{
    public int Id { get; set; }

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

    public virtual AirLineAgent? AireLineAgent { get; set; }

    public virtual FuelCompany? FuelCompany { get; set; }

    public virtual HandlingAgentsCompany? HandlingAgent { get; set; }

    public virtual ICollection<Revenue> Revenues { get; set; } = new List<Revenue>();

    public virtual TowerDatum? TowerData { get; set; }
}
