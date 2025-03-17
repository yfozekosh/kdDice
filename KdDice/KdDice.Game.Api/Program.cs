using KdDice.Game.Api.Modules.Square;
using KdDice.Queue;

namespace KdDice.Game.Api;

internal static class Program
{
    public static void Main(string[] args)
    {
        Thread.Sleep(TimeSpan.FromSeconds(5));

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddQueue(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseSquareModule();

        app.Run();
    }
}