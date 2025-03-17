using KdDice.Queue;

namespace KdDice.Processing.Square;

public static class SquareModule
{
    public static IServiceCollection AddSquare(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddQueue(configuration, [typeof(SquareModule).Assembly]);
        return services;
    }
}