using WeatherApp.API.Models;

namespace WeatherApp.API
{
  public static class Utils
  {
    public static TempratureUnitType ConvertTempratureUnitType(string unit)
    {
      return unit.ToLower() switch
      {
        "metric" => TempratureUnitType.METRIC,
        "imperial" => TempratureUnitType.IMPERIAL,
        _ => throw new ArgumentException($"Invalid unit: {unit}")
      };
    }
    public static string ConvertTempratureUnitToString(TempratureUnitType unit)
    {
      return unit switch
      {
        TempratureUnitType.METRIC => "metric",
        TempratureUnitType.IMPERIAL => "imperial",
        _ => throw new ArgumentException($"Invalid unit: {unit}")
      };
    }
  }
}
