using OperationAPI.Domain.FidsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Contracts.FidsAPIServices
{
   public interface IConsumeFidsAPIService
    {
        public Task<List<FlightDomain>> GetToDayFlights();
    }
}
