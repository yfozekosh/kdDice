using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KdDice.Persistence;

public static class PersistenceModule
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration["MongoDb:ConnectionString"];
        var databaseName = configuration["MongoDb:DatabaseName"];

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("MongoDb:ConnectionString is required");
        }

        if (string.IsNullOrWhiteSpace(databaseName))
        {
            throw new ArgumentException("MongoDb:DatabaseName is required");
        }

        services.AddSingleton(new MongoDbContext(connectionString, databaseName));
        MongoDbConfigurator.Configure();

        return services;
    }
}