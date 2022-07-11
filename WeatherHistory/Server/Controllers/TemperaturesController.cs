using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherHistory.Server.Services.Repositories;
using WeatherHistory.Shared.DTOs;

namespace WeatherHistory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturesController : ControllerBase
    {
        private readonly ITemperatureDbService _temperatureDbService;

        public TemperaturesController(ITemperatureDbService temperatureDbService)
        {
            _temperatureDbService = temperatureDbService;
        }

        [HttpGet("{cityName}")]
        public async Task<IActionResult> GetTempsForCity(string cityName)
        {
            var res = await _temperatureDbService.GetTemperaturesForCity(cityName);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddTempToCity([FromBody]TemperatureDTO temp)
        {
            await _temperatureDbService.AddNewTemperatureForCity(temp);
            return Ok("Added to db");
        }

        [HttpGet("last/{cityName}")]
        public async Task<IActionResult> GetLastTemperatureForCity(string cityName, string search)
        {
            switch (search)
            {
                case "temp":
                    return Ok(await _temperatureDbService.GetLastTemperatureForCity(cityName));
                case "date":
                    return Ok(await _temperatureDbService.GetLastTempDateForCity(cityName));
                default:
                    return BadRequest();
            }
        }
    }
}
