using MassTransit;

namespace KdDice.Game.Api.Modules;

public static class QueueModule
{
    public static void AddQueue(this WebApplicationBuilder builder)
    {
        var host = builder.Configuration["RabbitMQ:Host"];
        var username = builder.Configuration["RabbitMQ:Username"];
        var password = builder.Configuration["RabbitMQ:Password"];

        if (host is null || username is null || password is null)
        {
            throw new InvalidOperationException("RabbitMQ configuration is missing");
        }

        builder.Services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(host, "/", h =>
                {
                    h.Username(username);
                    h.Password(password);
                });
                cfg.ConfigureEndpoints(context);
            });
        });
    }
}