
using CurrencyToWordsApp.Infrastructure.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace CurrencyToWordsApp.Api.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {

        private readonly ILogManager _logger; 

        public ErrorController(ILogManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.Error(@$"Error in API | {exception.Error.Message}", exception.Error);
            return Problem();
        }

    }
}
