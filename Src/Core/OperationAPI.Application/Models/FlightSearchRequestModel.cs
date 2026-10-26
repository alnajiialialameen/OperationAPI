using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Models
{
   public class FlightSearchRequestModel
    {
        public int? AirlineId { get; set; }

        public string? FlightNo { get; set; }

        public DateOnly? DateTo { get; set; }
        public DateOnly? DateFrom { get; set; }
    }
}
