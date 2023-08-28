using Nutrition.And.Exercise.Domain.Entities;
using Nutrition.And.Exercise.Domain.Interfaces.MongoDBServices;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.MongoDBRepositories;

namespace Nutrition.And.Exercise.Application.MongoDBServices
{
    public class ProductAppServices : IProductAppServices
    {
        private readonly IProductMongoRepository _productMongoRepository;
        public ProductAppServices(IProductMongoRepository productMongoRepository) 
        {
            _productMongoRepository = productMongoRepository;
        }
        public Task DeleteProduct(string id)
        {
            var response = _productMongoRepository.DeleteProduct(id);

            return response;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var response = await _productMongoRepository.GetAllProducts();

            return response;
        }

        public async Task<Product> GetProductById(string id)
        {
            var response = await _productMongoRepository.GetProductById(id);

            return response;
        }

        public Task InsertProduct(Product product)
        {
            var response = _productMongoRepository.InsertProduct(product);

            return response;
        }

        public Task UpdateProduct(Product product)
        {
            var response = _productMongoRepository.UpdateProduct(product);

            return response;
        }
    }
}
