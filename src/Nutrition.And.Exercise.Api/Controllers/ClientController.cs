using Microsoft.AspNetCore.Mvc;
using Nutrition.And.Exercise.Application.Commands;
using Nutrition.And.Exercise.Core.Communication.Mediator;
using Nutrition.And.Exercise.Domain.Interfaces.Queries;
using Microsoft.AspNetCore.Authorization;
//using SerilogTimings;

namespace Nutrition.And.Exercise.Api.Controllers
{
    //[Authorize]
    [Route("api/client")]
    [ApiController]
    public class ClientController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IClientQueries _clientQueries;
        //private readonly ILogger<CustomersController> _logger;

        public ClientController(
            IMediatorHandler mediatorHandler,
            IClientQueries clientQueries
            //ILogger<CustomersController> logger
            )
        {
            _mediatorHandler = mediatorHandler;
            _clientQueries = clientQueries;
            //_logger = logger;
        }

        /// <summary>
        /// Client list.
        /// </summary>
        /// <returns>Get client list.</returns>
        [HttpGet("obter-todos")]
        public async Task<IActionResult> Get()
        {   
            //using (Operation.Time("Tempo para busca dos cliente."))
            //{
            //    _logger.LogInformation("Foi requisitado a busca dos clientes.");
                var response = await _clientQueries.GetCustomers();

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
        [HttpGet("obter-por-id/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _clientQueries.GetClient(id));
        }

        /// <summary>
        /// Register clients
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Customer records command</returns>
        [HttpPost("inserir-clientes")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Post()
        {
            var result = await _mediatorHandler
                .SendCommand(new RegisterClientCommand(Guid.NewGuid(), "Sakura", DateTime.Now, "12456789452"));

            return CustomResponse(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        //[HttpPost("")]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPut("atualizar-clientes/{id:guid}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Customer removal by id
        /// </summary>
        /// <param name="id" example="123">Id of Client</param>
        /// <remarks>When deleting the client, it will be permanently removed from the base.</remarks>
        [HttpDelete("deletar-por-id/{id:guid}")]
        public void Delete(int id)
        {
        }
    }
}
