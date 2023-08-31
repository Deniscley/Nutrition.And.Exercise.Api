using Microsoft.AspNetCore.Mvc;
using Nutrition.And.Exercise.Core.Communication.Mediator;
using Nutrition.And.Exercise.Domain.Interfaces.MongoDBServices;

namespace Nutrition.And.Exercise.Api.Controllers
{
    //[Authorize]
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductAppServices _productAppServices;

        public ProductController(
            IProductAppServices productAppServices
            )
        {
            _productAppServices = productAppServices;
        }

        [HttpGet("obter-todos")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productAppServices.GetAllProducts());
        }

        [HttpGet("obter-por-id/{id}")]
        public async Task<IActionResult> GetProductDetails(string id)
        {
            return Ok(await _productAppServices.GetProductById(id));
        }

        [HttpPost("inserir-cliente")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be empty");
            }

            await _productAppServices.InsertProduct(product);

            return Created("Created", true);
        }

        [HttpPut("atualizar-produto/{id}")]
        public async Task<IActionResult> UpdateProduct(Product product, string id)
        {
            if (product == null)
                return BadRequest();

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be empty");
            }

            product.Id = new MongoDB.Bson.ObjectId(id);
            await _productAppServices.UpdateProduct(product);

            return Created("Created", true);
        }

        [HttpDelete("deletar-por-id/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productAppServices.DeleteProduct(id);

            return NoContent(); //success
        }
    }
}   
