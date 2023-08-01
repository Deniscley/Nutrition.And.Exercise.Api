using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Nutrition.And.Exercise.Domain.DTOs.ResponseDtos;
using System.Diagnostics;

namespace Nutrition.And.Exercise.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var excetion = context?.Error;

            Response.StatusCode = 500;

            var idError = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            return new ErrorResponse(idError, HttpContext?.TraceIdentifier);
        }
    }
}
