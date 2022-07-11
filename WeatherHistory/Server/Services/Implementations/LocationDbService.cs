using Microsoft.EntityFrameworkCore;
using WeatherHistory.Server.Data;
using WeatherHistory.Server.Models;
using WeatherHistory.Server.Services.Repositories;
using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Server.Services.Implementations
{
    public class LocationDbService : ILocationDbService
    {
        private readonly WeatherDbContext _weatherDbContext;

        public LocationDbService(WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
        }

        public async Task AddLocation(LocationDTO location)
        {
            var cityName = location.Name.ToLower();
            var tab = cityName.ToCharArray();
            tab[0] = char.ToUpper(tab[0]);

            var loc = new Location
            {
                Name = new string(tab)
            };

            _weatherDbContext.Locations.Add(loc);
            await _weatherDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<LocationDTO>> GetLocations()
        {
            return await _weatherDbContext.Locations.Select(e => new LocationDTO { Name = e.Name }).ToListAsync();
        }

        public async Task<bool> IfAnyLocationExists()
        {
            return await _weatherDbContext.Locations.AnyAsync();
        }

        public async Task<bool> IfLocationExists(string name)
        {
            return await _weatherDbContext.Locations.AnyAsync(e => e.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
