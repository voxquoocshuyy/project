namespace webapi.Services.WeatherServices;

public interface IWeatherService
{
    IEnumerable<WeatherForecast> GetAllWeather();
}