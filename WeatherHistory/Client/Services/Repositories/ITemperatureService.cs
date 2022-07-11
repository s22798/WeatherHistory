using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Client.Services.Repositories
{
    public interface ITemperatureService
    {
        Task<IEnumerable<TemperatureDTO>> GetTempsForCity(string cityName);
        Task AddTemperatureForCityToDb(string cityName);
        Task<TemperatureDTO> GetTemperatureForCity(string cityName);
        Task<HttpResponseMessage> CheckStatusForCityTemperature(string cityName);
        Task<LastTempDTO> GetLastTemperatureForCity(string cityName);
    }
}
