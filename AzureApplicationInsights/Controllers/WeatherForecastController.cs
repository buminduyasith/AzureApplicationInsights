// <copyright file="WeatherForecastController.cs" company="Bumindu Yasith">
// Copyright (c) Bumindu Yasith. All rights reserved.
// </copyright>

namespace AzureApplicationInsights.Controllers
{
    using System.Security.Cryptography;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
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
#pragma warning disable CA1848 // Use the LoggerMessage delegates
            logger.LogInformation("GetWeatherForecast");
            logger.LogInformation("remove this log");
#pragma warning restore CA1848 // Use the LoggerMessage delegates

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
                Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)],
            })
            .ToArray();
        }
    }
}
