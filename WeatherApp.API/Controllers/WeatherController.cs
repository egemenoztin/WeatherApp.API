using Microsoft.AspNetCore.Mvc;
using WeatherApp.API.Interfaces;
using WeatherApp.API.Models;

namespace WeatherApp.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WeatherController : ControllerBase
  {
    private readonly IWeatherService _weatherService;
    private static string _temperatureUnit = "metric"; // Default unit

    public WeatherController(IWeatherService weatherService)
    {
      _weatherService = weatherService;
    }

    [HttpGet("getWeatherData")]
    public async Task<IActionResult> GetWeatherData([FromQuery] string city)
    {
      try
      {
        var weatherData = await _weatherService.GetWeatherForCity(city, _temperatureUnit);
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
      if (request.Unit != "metric" && request.Unit != "imperial")
      {
        return BadRequest("Invalid unit. Use 'metric' or 'imperial'");
      }

      _temperatureUnit = request.Unit;
      return Ok($"Temperature unit set to {request.Unit}");
    }
  }
}