using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using WeatherHistory.Client.Services.Repositories;
using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Client.Services.Implementations
{
    public class TemperatureService : ITemperatureService
    {
        private readonly HttpClient _httpClient;
        private string apiKey = "9757dc3b3883500b85bf77e2e7f4d05b";

        public TemperatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddTemperatureForCityToDb(string cityName)
        {
            var temp = await GetTemperatureForCity(cityName);
            var serialized = JsonConvert.SerializeObject(temp);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("api/temperatures", stringContent);
        }

        public async Task<HttpResponseMessage> CheckStatusForCityTemperature(string cityName)
        {
            var res = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric");
            return res;
        }

        public async Task<LastTempDateDTO> GetLastResfreshForCity(string cityName)
        {
            var res = await _httpClient.GetStringAsync($"api/temperatures/last/{cityName}?search=date");
            return JObject.Parse(res).SelectToken("").ToObject<LastTempDateDTO>();
        }

        public async Task<LastTempDTO> GetLastTemperatureForCity(string cityName)
        {
            var res = await _httpClient.GetStringAsync($"api/temperatures/last/{cityName}?search=temp");
            return JObject.Parse(res).SelectToken("").ToObject<LastTempDTO>();
        }

        public async Task<TemperatureDTO> GetTemperatureForCity(string cityName)
        {
            TemperatureDTO temp = null;
            IEnumerable<WeatherDTO> weath = null;

            var json = await _httpClient.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric");
            var jObject = JObject.Parse(json);

            temp = jObject.SelectToken("main").ToObject<TemperatureDTO>();
            weath = jObject.SelectToken("weather").ToObject<IEnumerable<WeatherDTO>>();

            temp.WeatherName = weath.ElementAt(0).Main;
            temp.Date = DateTime.Now;
            temp.CityName = cityName;

            return temp;
        }

        public async Task<IEnumerable<TemperatureDTO>> GetTempsForCity(string cityName)
        {
            var res = await _httpClient.GetStringAsync($"api/temperatures/{cityName}");
            return JArray.Parse(res).SelectToken("").ToObject<IEnumerable<TemperatureDTO>>();
        }
    }
}
