using System.Text.Json;
using WeatherApp.API.Interfaces;
using WeatherApp.API.Models;

namespace WeatherApp.API.Services
{
  public class WeatherService : IWeatherService
  {
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public WeatherService(HttpClient httpClient)
    {
      _httpClient = httpClient;
      _apiKey = "f00c38e0279b7bc85480c3fe775d518c";
    }

    public async Task<WeatherData> GetWeatherForCity(string city, string unit)
    {
      // Build the API URL with query parameters
      var response = await _httpClient.GetAsync(
          $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units={unit}");

      response.EnsureSuccessStatusCode();
      var content = await response.Content.ReadAsStringAsync();
      var data = JsonSerializer.Deserialize<JsonElement>(content);

      // Map the API response to WeatherData model
      return new WeatherData
      {
        CityName = data.GetProperty("name").GetString(),
        Description = data.GetProperty("weather")[0].GetProperty("description").GetString(),
        Temperature = data.GetProperty("main").GetProperty("temp").GetDouble(),
        Sunrise = data.GetProperty("sys").GetProperty("sunrise").GetInt64(),
        Sunset = data.GetProperty("sys").GetProperty("sunset").GetInt64(),
        WeatherIcon = data.GetProperty("weather")[0].GetProperty("icon").GetString()
      };
    }
  }
}