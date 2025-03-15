using KdDice.Game.Api.Api.WeatherApi;

namespace KdDice.Game.Api.Api;

public static class ApiModule
{
    public static void AddApiEndpoints(this WebApplication builder)
    {
        builder.AddWeatherForecastEndpoint();
    }
}