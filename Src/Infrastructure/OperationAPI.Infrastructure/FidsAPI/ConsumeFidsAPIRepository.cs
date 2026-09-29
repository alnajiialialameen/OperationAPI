using OperationAPI.Application.Contracts.FidsAPIServices;
using OperationAPI.Domain.FidsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OperationAPI.Infrastructure.FidsAPI
{
   public class ConsumeFidsAPIRepository : IConsumeFidsAPIService
    {
        private readonly HttpClient _httpClient;

        private static readonly JsonSerializerOptions _jsonOptions =
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters =
                    {
                        new DateOnlyJsonConverter()
                    }
                };

        public ConsumeFidsAPIRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FlightDomain>> GetToDayFlights()
        {
            var response = await _httpClient.GetAsync("Flights/GetToDayFlights");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<ApiResponse<List<FlightDomain>>>(_jsonOptions);


            return result?.Data ?? new List<FlightDomain>();
        }
    }
}
