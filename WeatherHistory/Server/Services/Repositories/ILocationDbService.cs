using WeatherHistory.Server.Models;
using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Server.Services.Repositories
{
    public interface ILocationDbService
    {
        Task<IEnumerable<LocationDTO>> GetLocations();
        Task AddLocation(LocationDTO location);
        Task<bool> IfLocationExists(string name);
        Task<bool> IfAnyLocationExists();
    }
}
