using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherHistory.Server.Services.Repositories;
using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationDbService _locationDbService;

        public LocationsController(ILocationDbService locationDbService)
        {
            _locationDbService = locationDbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            if (!await _locationDbService.IfAnyLocationExists()) return NotFound("Locations not found");
            var locs = await _locationDbService.GetLocations();
            return Ok(locs);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationDTO location)
        {
            if (await _locationDbService.IfLocationExists(location.Name)) return BadRequest("Location already exists");

            await _locationDbService.AddLocation(location);
            return Ok("Added location");
        }
    }
}
