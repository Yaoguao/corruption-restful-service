using Corruption.Core.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Corruption.DataAccess;

public class CorruptionContext 
{
    private readonly IMongoDatabase _database;

    public CorruptionContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
        _database = client.GetDatabase(configuration["DatabaseName"]);
    }

    public IMongoCollection<Message> Messages => _database.GetCollection<Message>("Messages");
    public IMongoCollection<CorruptionMessage> CorruptionMessages => _database.GetCollection<CorruptionMessage>("CorruptionMessages");

    
}