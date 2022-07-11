using Microsoft.EntityFrameworkCore;
using WeatherHistory.Server.Data;
using WeatherHistory.Server.Models;
using WeatherHistory.Server.Services.Repositories;
using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Server.Services.Implementations
{
    public class TemperatureDbService : ITemperatureDbService
    {
        private readonly WeatherDbContext _weatherDbContext;

        public TemperatureDbService(WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
        }

        public async Task AddNewTemperatureForCity(TemperatureDTO temp)
        {
            var temperature = new Temperature
            {
                Temp = temp.Temp,
                FeelsLike = temp.Feels_like,
                Pressure = temp.Pressure,
                Humidity = temp.Humidity,
                TempMin = temp.Temp_min,
                TempMax = temp.Temp_max,
                WeatherName = temp.WeatherName,
                Date = temp.Date,
                IdLocation = await GetLocationIdByName(temp.CityName)
            };

            _weatherDbContext.Add(temperature);
            await _weatherDbContext.SaveChangesAsync();
        }

        public async Task<LastTempDTO> GetLastTemperatureForCity(string cityName)
        {
            var id = await GetLocationIdByName(cityName);
            var max = _weatherDbContext.Temperatures.Where(e=> e.IdLocation==id).Max(e => e.Date);
            return await _weatherDbContext.Temperatures.Where(e => e.Date == max).Select(e => new LastTempDTO { LastTemperature = e.Temp}).FirstOrDefaultAsync();
        }

        public async Task<int> GetLocationIdByName(string cityName)
        {
            return await _weatherDbContext.Locations.Where(e => e.Name.Equals(cityName)).Select(e => e.IdLocation).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TemperatureDTO>> GetTemperaturesForCity(string cityName)
        {
            var id = await GetLocationIdByName(cityName);
            return await _weatherDbContext.Temperatures.Where(e => e.IdLocation == id).Select(e => new TemperatureDTO
            {
                Temp = e.Temp,
                Feels_like = e.FeelsLike,
                Pressure = e.Pressure,
                Humidity = e.Humidity,
                Temp_min = e.TempMin,
                Temp_max = e.TempMax,
                WeatherName = e.WeatherName,
                Date = e.Date
            }).ToListAsync();
        }
    }
}
