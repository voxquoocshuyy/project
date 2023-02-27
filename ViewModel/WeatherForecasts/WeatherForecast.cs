namespace webapi;

public class WeatherForecast
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Main { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public int Temperature { get; set; }
    public int Humidity { get; set; }
}
