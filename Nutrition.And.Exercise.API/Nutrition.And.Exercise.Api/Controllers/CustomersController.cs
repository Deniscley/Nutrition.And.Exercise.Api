using Microsoft.AspNetCore.Mvc;
using Nutrition.And.Exercise.Borders.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrition.And.Exercise.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// <summary>
        /// Client list.
        /// </summary>
        /// <returns>Get client list.</returns>
        [HttpGet("clients")]
        [ProducesResponseType(200, Type = typeof(Client))]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            return Ok(new List<Client>()
            {
                new Client {
                    Id = 1,
                    Nome = "Kakarotto",
                    DataNascimento = new DateTime(1980, 01, 01)
                },
                new Client {
                    Id = 2,
                    Nome = "Bulma",
                    DataNascimento = new DateTime(1978, 05, 05)
                }
            });
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
