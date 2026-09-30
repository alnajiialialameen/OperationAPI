using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Domain.FidsAPI
{
   public class FlightDomain
    {
        public int Id { get; set; }
        public int AirlineId { get; set; }
        public string? FlightNo { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int AirportFrom { get; set; }
        public int AirportTo { get; set; }
        public int FlightTypeId { get; set; }
        public string? FlightTypeNameAr { get; set; }
        public string? FlightTypeNameEn { get; set; } 
        public string? AirlineNameAr { get; set; } 
        public string? AirlineNameEn { get; set; }
        public string? AirportFromNameAr { get; set; }
        public string? AirportFromNameEn { get; set; }
        public string? AirportToNameAr { get; set; }
        public string? AirportToNameEn { get; set; }
        //public string? ImagePath { get; set; } 
        public bool? IsConsumed { get; set; }
        public int? FlightStatusId { get; set; }
        public bool? IsOpen { get; set; }
        public int? TowerDataId { get; set; }

    }
}
