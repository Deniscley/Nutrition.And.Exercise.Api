using Nutrition.And.Exercise.Domain.Entities;

namespace Nutrition.And.Exercise.Domain.Interfaces.Repositories.MongoDBRepositories
{
    public interface IProductMongoRepository
    {
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);

        Task<List<Product>> GetAllProducts();

        Task<Product> GetProductById(string id);
    }
}
