using MongoDB.Driver;

namespace Nutrition.And.Exercise.Data.Context
{
    public class MongoDBContext
    {
        public MongoClient _client;
        public IMongoDatabase _database;
        public MongoDBContext() 
        {
            _client = new MongoClient("");
            _database = _client.GetDatabase("");
        }
    }
}

