// <copyright file="Program.cs" company="Bumindu Yasith">
// Copyright (c) Bumindu Yasith. All rights reserved.
// </copyright>
#pragma warning disable
namespace AzureApplicationInsights
{
    using Serilog;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddEnvironmentVariables();

            builder.Services.AddControllers();

            builder.Host.UseSerilog((context, loggerConfig) =>
            {
                loggerConfig.ReadFrom.Configuration(context.Configuration);
            });

            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));

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