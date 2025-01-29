using WeatherApp.API.Models;

namespace WeatherApp.API.Interfaces
{
  public interface IWeatherService
  {
    Task<WeatherData> GetWeatherForCity(string city, string unit);
  }
}