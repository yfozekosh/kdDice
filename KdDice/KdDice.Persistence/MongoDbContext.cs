using KdDice.Persistence.Square;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace KdDice.Persistence;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string? databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<SquareResponseEntity> SquareResponses =>
        _database.GetCollection<SquareResponseEntity>("SquareResponses");
}

public class MongoDbConfigurator
{
    public static void Configure()
    {
        // Register the GuidSerializer with the specified GuidRepresentation
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
    }
}