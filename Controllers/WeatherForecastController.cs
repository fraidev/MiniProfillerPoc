using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniProfillerPoc.Models;
using StackExchange.Profiling;

namespace MiniProfillerPoc.Controllers
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
        private readonly TodoDbContext _todoDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TodoDbContext todoDbContext)
        {
            _logger = logger;
            _todoDbContext = todoDbContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            var todo = new Todo()
            {
                Name = rng.Next().ToString()
            };
            using (MiniProfiler.Current.Step("InitUser"))
            {
                _todoDbContext.Add(todo);
            
                _todoDbContext.SaveChanges();
            }
            
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}
