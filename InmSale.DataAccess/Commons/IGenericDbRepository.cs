using MongoDB.Driver;

namespace InmSale.Repositories.Commons
{
    public interface IGenericDbRepository
    {
        IMongoCollection<T> GetCollection<T>(ReadPreference? readPreference) where T : class;
    }
}