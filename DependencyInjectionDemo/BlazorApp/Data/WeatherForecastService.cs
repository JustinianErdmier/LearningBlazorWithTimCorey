namespace BlazorApp.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IDataAccess _db;

        public WeatherForecastService(IDataAccess db)
        {
            _db = db;
        }

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            int upperValue = _db.GetUserAge();

            return Task.FromResult(Enumerable.Range(1, upperValue).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}