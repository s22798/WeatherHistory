using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using WeatherHistory.Client.Services.Repositories;
using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Client.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddLocationToDb(string cityName)
        {
            var loc = new LocationDTO { Name = cityName };

            var seralized = JsonConvert.SerializeObject(loc);
            var stringContent = new StringContent(seralized, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/locations", stringContent);
            return response;
        }

        public async Task<HttpResponseMessage> CheckStatusForLocationsInDb()
        {
            var res = await _httpClient.GetAsync("api/locations");
            return res;
        }

        public async Task<IEnumerable<LocationDTO>> GetLocationsFromDb()
        {
            var res = await _httpClient.GetStringAsync("api/locations");
            return JArray.Parse(res).SelectToken("").ToObject<IEnumerable<LocationDTO>>();
        }
    }
}
