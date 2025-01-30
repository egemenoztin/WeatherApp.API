using WeatherApp.API.Models;

namespace WeatherApp.API
{
  public static class Utils
  {
    public static TemperatureUnitType ConvertTempratureUnitType(string unit)
    {
      return unit.ToLower() switch
      {
        "metric" => TemperatureUnitType.METRIC,
        "imperial" => TemperatureUnitType.IMPERIAL,
        _ => throw new ArgumentException($"Invalid unit: {unit}")
      };
    }
    public static string ConvertTempratureUnitToString(TemperatureUnitType unit)
    {
      return unit switch
      {
        TemperatureUnitType.METRIC => "metric",
        TemperatureUnitType.IMPERIAL => "imperial",
        _ => throw new ArgumentException($"Invalid unit: {unit}")
      };
    }
  }
}
