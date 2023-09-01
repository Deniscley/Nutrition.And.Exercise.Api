using MongoDB.Bson;
using MongoDB.Driver;
using Nutrition.And.Exercise.Data.Context;
using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.MongoDBRepositories;

namespace Nutrition.And.Exercise.Data.Repositories.MongoDBRepositories
{
    public class ProductMongoRepository : IProductMongoRepository
    {
        private MongoDBContext _context = new MongoDBContext();
        private IMongoCollection<Product> _collection;
        public ProductMongoRepository()
        {
            _collection = _context._database.GetCollection<Product>("Products");
        }

        public async Task DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, new ObjectId(id));
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
           return await _collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertProduct(Product product)
        {
            await _collection.InsertOneAsync(product);
        }

        public async Task UpdateProduct(Product product)
        {
            var filter = Builders<Product>
                .Filter
                .Eq(s => s.Id, product.Id);

            await _collection.ReplaceOneAsync(filter, product);
        }
    }
}
