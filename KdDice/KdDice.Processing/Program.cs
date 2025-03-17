using KdDice.Persistence;
using KdDice.Processing.Square;
using KdDice.Queue;

namespace KdDice.Processing;

public class Program
{
    public static void Main(string[] args)
    {
        Thread.Sleep(TimeSpan.FromSeconds(5));

        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddPersistence(builder.Configuration)
            .AddSquare(builder.Configuration);

        var app = builder.Build();

        app.Run();
    }
}