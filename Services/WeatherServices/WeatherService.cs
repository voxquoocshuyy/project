namespace webapi.Services.WeatherServices;

public class WeatherService : IWeatherService
{
    private static readonly string[] City = new[]
    {
        "Ho Chi Minh City", "Ha Noi City", "Da Nang City", "Da Lat City", "Binh Duong City", "Hoi An", "Nha Trang",
        "Vung Tau", "Can Tho", "Hue City"
    };
    private static readonly string[] Main = new[]
    {
        "Cloudy", "Sunny", "Clear", "Fine", "Windy", "Brezze", "Gloomy", "Rainy", "Snowy", "Stormy", "Foggy", "Hazy"
    };
    private static readonly string[] Description = new[]
    {
        "Cloudy", "Sunny", "Clear", "Fine", "Windy", "Brezze", "Gloomy", "Rainy", "Snowy", "Stormy", "Foggy", "Hazy"
    };
    public IEnumerable<WeatherForecast> GetAllWeather()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Id = Random.Shared.Next(0000000, 9999999),
            City = City[Random.Shared.Next(City.Length)],
            Main = Main[Random.Shared.Next(Main.Length)],
            Description = Description[Random.Shared.Next(Description.Length)],
            Icon = "https://openweathermap.org/img/w/10d.png",
            Temperature = Random.Shared.Next(0, 40),
            Humidity = Random.Shared.Next(0, 100)
        });
    }
}