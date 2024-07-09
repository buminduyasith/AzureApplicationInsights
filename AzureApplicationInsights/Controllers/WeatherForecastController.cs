// <copyright file="WeatherForecastController.cs" company="Bumindu Yasith">
// Copyright (c) Bumindu Yasith. All rights reserved.
// </copyright>

namespace AzureApplicationInsights.Controllers
{
    using System.Security.Cryptography;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            logger.LogInformation("GetWeatherForecast");

            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
                Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)],
            })
            .ToArray();

            logger.LogInformation("weather forecast daa {@Data}", data);

            return data;
        }

        [HttpGet("byId", Name = "GetWeatherForecastById")]
        public ActionResult<WeatherForecast> GetById([FromQuery] int id)
        {
            #pragma warning disable
            logger.LogInformation("GetWeatherForecastById with id {Id}", id);

            if (id == 0) 
            { 
                throw new Exception("id shuold not be zero");
            }

            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
                Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)],
            })
             .ToArray();

            return data[id];
        }
    }
}
