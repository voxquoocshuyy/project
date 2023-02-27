using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Services.WeatherServices;

namespace webapi.Controllers;
[ApiController]
[Route("api/weathers")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    
    public WeatherForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ModelsResponse<WeatherForecast>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllWeather()
    {
        IEnumerable<WeatherForecast> result = _weatherService.GetAllWeather();
        if (!result.Any())
        {
            return NoContent();
        }  
        if (result == null)
        {
            return BadRequest(new ModelsResponse<WeatherForecast>
            {
                Code = StatusCodes.Status400BadRequest,
                Data = result.ToList(),
                Msg = "Use API get weather fail!"
            });
        }
        return Ok(new ModelsResponse<WeatherForecast>()
        {
            Code = StatusCodes.Status200OK,
            Data = result.ToList(),
            Msg = "Use API get weather success!"
        });
    }
}
