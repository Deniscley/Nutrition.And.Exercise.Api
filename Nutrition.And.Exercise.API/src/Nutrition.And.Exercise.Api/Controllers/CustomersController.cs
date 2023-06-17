using Microsoft.AspNetCore.Mvc;
using Nutrition.And.Exercise.Application.Commands;
using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.EFRepositories;
using Nutrition.And.Exercise.Domain.Interfaces.Repositories.DapperRepositories;
using Nutrition.And.Exercise.Core.Mediator;
//using SerilogTimings;

namespace Nutrition.And.Exercise.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : MainController
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientQueriesRepository _clientQueriesRepository;
        private readonly IMediatorHandler _mediatorHandler;
        //private readonly ILogger<CustomersController> _logger;

        public CustomersController(IClientRepository clientRepository,
            IClientQueriesRepository clientQueriesRepository,
            IMediatorHandler mediatorHandler
            //ILogger<CustomersController> logger
            )
        {
            _clientRepository = clientRepository;
            _clientQueriesRepository = clientQueriesRepository;
            _mediatorHandler = mediatorHandler;
            //_logger = logger;
        }

        /// <summary>
        /// Client list.
        /// </summary>
        /// <returns>Get client list.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {   
            //using (Operation.Time("Tempo para busca dos cliente."))
            //{
            //    _logger.LogInformation("Foi requisitado a busca dos clientes.");
                var response = await _clientRepository.GetCustomersAsync();

                if (response.Any())
                {
                    return Ok(response);
                }

                return NotFound();
            //}
        }

        /// <summary>
        /// Client by id
        /// </summary>
        /// <param name="id" example="123">Id of Client</param>
        /// <returns>Get client by id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _clientQueriesRepository.GetClientAsync(id));
        }

        /// <summary>
        /// Register clients
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Customer records command</returns>
        [HttpGet("clients")]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler
                .SendCommand(new RegisterClientCommand(Guid.NewGuid(), "Sasuke", DateTime.Now));

            return CustomResponse(result);
        }

        // POST api/<CustomersController>
        [HttpPost]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Customer removal by id
        /// </summary>
        /// <param name="id" example="123">Id of Client</param>
        /// <remarks>When deleting the client, it will be permanently removed from the base.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public void Delete(int id)
        {
        }
    }
}
