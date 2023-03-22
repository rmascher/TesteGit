using Microsoft.AspNetCore.Mvc;

namespace GitTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeatureGController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<FeatureGController> _logger;

        public FeatureGController(ILogger<FeatureGController> logger)
        {
            _logger = logger;
        }

        [HttpPut(Name = "PutFeatureG")]
        public IEnumerable<WeatherForecast> Put()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}