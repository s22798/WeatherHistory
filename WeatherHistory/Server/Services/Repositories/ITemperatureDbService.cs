using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Server.Services.Repositories
{
    public interface ITemperatureDbService
    {
        Task<IEnumerable<TemperatureDTO>> GetTemperaturesForCity(string cityName);
        Task AddNewTemperatureForCity(TemperatureDTO temp);
        Task<int> GetLocationIdByName(string cityName);
        Task<LastTempDTO> GetLastTemperatureForCity(string cityName);
        Task<LastTempDateDTO> GetLastTempDateForCity(string cityName);
    }
}
