using CurrencyToWordsApp.Infrastructure.Dto;
using CurrencyToWordsApp.Infrastructure.Logging;
using CurrencyToWordsApp.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyToWordsApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyToWordsController : ControllerBase
    {
        private readonly ICurrencyToWordsService _currencyToWordsService; 
        private readonly ILogManager _logger; 

        public CurrencyToWordsController(ILogManager logger, ICurrencyToWordsService currencyToWordsService)
        {
            _logger = logger;
            _currencyToWordsService = currencyToWordsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("api/GetCurrencyWords/{amount:decimal}")]
        public async Task<ActionResult<CurrencyWordsDto>> GetCurrencyValueConvertedToWords(decimal amount)
        {
            _logger.Information("Executing method GetCurrencyValueConvertedToWords"); 
            return await _currencyToWordsService.GetCurrencyValueInWords(amount);
        }
    }
}