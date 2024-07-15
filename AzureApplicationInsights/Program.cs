// <copyright file="Program.cs" company="Bumindu Yasith">
// Copyright (c) Bumindu Yasith. All rights reserved.
// </copyright>
#pragma warning disable
namespace AzureApplicationInsights
{
    using Microsoft.Extensions.Configuration;
    using Serilog;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddEnvironmentVariables();

            builder.Logging.AddAzureWebAppDiagnostics();

            var connectionString = builder.Configuration["AzureMetaData:ApplicationInsights"];

            Console.WriteLine(connectionString);

            builder.Logging.AddApplicationInsights(
                 configureTelemetryConfiguration: (config) =>
                 {
                     config.ConnectionString = connectionString;
                 },
                        configureApplicationInsightsLoggerOptions: (options) => { }
            );

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}