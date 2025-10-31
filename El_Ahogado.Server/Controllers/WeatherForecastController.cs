using El_Ahogado.Server.models;
using El_Ahogado.Server.services;
using Microsoft.AspNetCore.Mvc;

namespace El_Ahogado.Server.Controllers
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
        private readonly ApiService _apiService;

        
        public WeatherForecastController(ILogger<WeatherForecastController> logger,ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
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
            .ToArray();
        }

        [HttpGet("Jair")]

        public async Task<IActionResult> ObtenerPalabraRamdom([FromQuery] int? minLength = null,[FromQuery]int? maxLength = null)
        {
            return Ok(await _apiService.GetRandomWordAsync(minLength,maxLength));
        }
    }
}
