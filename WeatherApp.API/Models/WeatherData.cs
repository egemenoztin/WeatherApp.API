namespace WeatherApp.API.Models
{
  public class WeatherData
  {
    public string CityName { get; set; }
    public string Description { get; set; }
    public double Temperature { get; set; }
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
    public string WeatherIcon { get; set; }
  }

  public class TemperatureUnitRequest
  {
    public string Unit { get; set; }
  }
}