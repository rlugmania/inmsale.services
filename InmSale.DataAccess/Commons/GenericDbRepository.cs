using InmSale.Infrastructure.Data;
using MongoDB.Driver;

namespace InmSale.Repositories.Commons;

public class GenericDbRepository : IGenericDbRepository
{
    private readonly IMongoDatabase _database;

    public GenericDbRepository(IMongoClient mongoClient, string database)
    {
        _database = mongoClient.GetDatabase(database);

    }

    public IMongoCollection<T> GetCollection<T>(ReadPreference? readPreference) where T : class
    {
        return _database
            .WithReadPreference(readPreference ?? ReadPreference.Primary)
            .GetCollection<T>(GetCollectionName<T>());
    }


    private static string GetCollectionName<T>() where T : class
    {
        if (Attribute.GetCustomAttributes(typeof(T)).FirstOrDefault(t => t is MongoCollectionAttribute) is not MongoCollectionAttribute attributeInfo)
            throw new Exception($"No mongo collection defined for {typeof(T).Name}, use MongoCollectionAttribute for defining a collection name for the class");
        return attributeInfo.CollectionName;
    }

}
