using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Client.Services.Repositories
{
    public interface ILocationService
    {
        Task<HttpResponseMessage> AddLocationToDb(string cityName);
        Task<IEnumerable<LocationDTO>> GetLocationsFromDb();
        Task<HttpResponseMessage> CheckStatusForLocationsInDb();
    }
}
