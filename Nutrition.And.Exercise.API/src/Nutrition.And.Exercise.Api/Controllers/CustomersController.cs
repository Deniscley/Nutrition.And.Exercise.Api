using Microsoft.AspNetCore.Mvc;
using Nutrition.And.Exercise.Borders.Dtos.Response;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrition.And.Exercise.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IClientUseCase clientUseCase;
        public CustomersController(IClientUseCase clientUseCase)
        {
            this.clientUseCase = clientUseCase;
        }

        /// <summary>
        /// Client list.
        /// </summary>
        /// <returns>Get client list.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ClientsResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            var response = await clientUseCase.GetCustomersAsync();
            return Ok(response);
        }

        /// <summary>
        /// Client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get client by id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ClientsResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await clientUseCase.GetClientAsync(id));
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
