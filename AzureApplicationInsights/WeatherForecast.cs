// <copyright file="WeatherForecast.cs" company="Bumindu Yasith">
// Copyright (c) Bumindu Yasith. All rights reserved.
// </copyright>

namespace AzureApplicationInsights
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
