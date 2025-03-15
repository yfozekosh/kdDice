using System;
using System.Linq;
using KdDice.Game.Api.Model;
using Microsoft.AspNetCore.Builder;

namespace KdDice.Game.Api.Api.WeatherApi;

public static class WeatherForecastApi
{
    public static void AddWeatherForecastEndpoint(this WebApplication builder)
    {
        var summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        builder.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return new Response(VersionInfo.InstanceId, forecast);
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();
    }
}