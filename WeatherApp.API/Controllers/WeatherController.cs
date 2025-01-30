using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using WeatherApp.API.Interfaces;
using WeatherApp.API.Models;

namespace WeatherApp.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WeatherController : ControllerBase
  {
    private readonly IWeatherService _weatherService;
    private TempratureUnitType _temperatureUnit;  // Keep this field

    public WeatherController(IWeatherService weatherService)
    {
      _weatherService = weatherService;
    }

    [HttpGet("getWeatherData")]
    public async Task<IActionResult> GetWeatherData([FromQuery] string city, [FromQuery] string unit)
    {
      try
      {
        var weatherData = await _weatherService.GetWeatherForCity(city, unit);
        return Ok(weatherData);
      }
      catch (Exception ex)
      {
        return BadRequest($"Error fetching weather data: {ex.Message}");
      }
    }

    [HttpPost("setTemperatureUnit")]
    public IActionResult SetTemperatureUnit([FromBody] TemperatureUnitRequest request)
    {
      try
      {
        _temperatureUnit = Utils.ConvertTempratureUnitType(request.Unit);
        return Ok($"Temperature unit set to {request.Unit}");
      }
      catch (Exception)
      {
        return BadRequest("Invalid unit. Use 'metric' or 'imperial'");
      }
    }
  }
}