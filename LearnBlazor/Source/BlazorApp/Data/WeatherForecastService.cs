namespace BlazorApp.Data;

public class WeatherForecastService
{
    private static readonly string[] Summaries =
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    };

    private readonly ILogger<WeatherForecastService> _logger;

    public WeatherForecastService(ILogger<WeatherForecastService> logger) => _logger = logger;

    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        _logger.LogInformation("Getting the forecast");

        return Task.FromResult(Enumerable.Range(1, 5)
                                         .Select(index => new WeatherForecast
                                                          {
                                                              Date         = startDate.AddDays(index),
                                                              TemperatureC = Random.Shared.Next(-20, 55),
                                                              Summary      = Summaries[Random.Shared.Next(Summaries.Length)]
                                                          })
                                         .ToArray());
    }
}
