using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KdDice.Queue;

public static class QueueModule
{
    public static IServiceCollection AddQueue(this IServiceCollection services, IConfiguration configuration, IEnumerable<Assembly>? consumerAssemblies = null)
    {
        var host = configuration["RabbitMQ:Host"];
        var username = configuration["RabbitMQ:Username"];
        var password = configuration["RabbitMQ:Password"];

        if (host is null || username is null || password is null)
        {
            throw new InvalidOperationException("RabbitMQ configuration is missing");
        }

        services.AddMassTransit(x =>
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

            if (consumerAssemblies is not null)
            {
                x.AddConsumers(consumerAssemblies.ToArray());
            }
        });

        return services;
    }
}