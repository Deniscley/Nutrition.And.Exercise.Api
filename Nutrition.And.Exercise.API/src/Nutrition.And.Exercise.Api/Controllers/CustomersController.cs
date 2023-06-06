using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nutrition.And.Exercise.Borders.Commands;
using Nutrition.And.Exercise.Borders.Dtos.Response;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Repositories.PersistenceRepositories;
using Nutrition.And.Exercise.Borders.Interfaces.UseCases;
using Nutrition.And.Exercise.Borders.Mediator;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrition.And.Exercise.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : MainController
    {
        private readonly IClientUseCase _clientUseCase;
        private readonly IClientRepository _clientRepository;
        private readonly IMediatorHandler _mediatorHandler;
        //private readonly IMapper _mapper;

        public CustomersController(IClientUseCase clientUseCase,
            IClientRepository clientRepository,
            IMediatorHandler mediatorHandler
            //IMapper mapper
            )
        {
            _clientUseCase = clientUseCase;
            _clientRepository = clientRepository;
            _mediatorHandler = mediatorHandler;
            //_mapper = mapper;
        }

        /// <summary>
        /// Client list.
        /// </summary>
        /// <returns>Get client list.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ClientResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            var response = await _clientUseCase.GetCustomersAsync();
            return Ok(response);
        }

        /// <summary>
        /// Client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get client by id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ClientResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _clientUseCase.GetClientAsync(id));
        }

        [HttpGet("clients")]
        [ProducesResponseType(200, Type = typeof(ClientResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler
                .SendCommand(new RegisterClientCommand(Guid.NewGuid(), "Cascão", DateTime.Now));

            return CustomResponse(result);
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
