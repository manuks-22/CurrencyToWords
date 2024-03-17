using CurrencyToWordsApp.Infrastructure.Logging;

namespace CurrencyToWordsApp.Service.Service
{
    public class CurrencyToWordsService : ICurrencyToWordsService
    {
        private readonly ILogManager _logger;

        public CurrencyToWordsService(ILogManager logger)
        {
            _logger = logger; 
        }

        public Task<string> GetCurrencyValueInWords(long currencyValue)
        {
            _logger.Information(@$"Executing method {nameof(GetCurrencyValueInWords)}");

            var valueToWordsConverter = new ValueToWordsConverter();
            return Task.FromResult(valueToWordsConverter.ConvertNumericValueToWords(1000));
        }
    }
}
