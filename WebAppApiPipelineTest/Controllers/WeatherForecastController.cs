using Microsoft.AspNetCore.Mvc;

namespace WebAppApiPipelineTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }

        [HttpGet("greating")]
        public async Task<IActionResult> Greating(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Please enter the name");
            }

            return Ok($"Hello {name} from v1");
        }
        
        [HttpGet("greating-v2")]
        public async Task<IActionResult> Greatingv2(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Please enter the name");
            }

            return Ok($"Hello {name} vvrom v2");
        }
        
        [HttpGet("greating-v3")]
        public async Task<IActionResult> Greatingv3(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Please enter the name");
            }

            return Ok($"Hello {name} vvrom v3");
        }
    }
}
