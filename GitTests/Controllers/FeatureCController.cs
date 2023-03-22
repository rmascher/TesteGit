using Microsoft.AspNetCore.Mvc;

namespace GitTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeatureCController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<FeatureCController> _logger;

        public FeatureCController(ILogger<FeatureCController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFeatureC")]
        public IEnumerable<WeatherForecast> Get()
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