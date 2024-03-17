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

        public Task<string> GetCurrencyValueInWords(double currencyValue)
        {
            _logger.Information(@$"Executing method {nameof(GetCurrencyValueInWords)}");

            var currencyIntegralPart = Convert.ToInt32(Math.Floor(currencyValue));

            var valueToWordsConverter = new ValueToWordsConverter();
            var currencyWords = valueToWordsConverter.ConvertNumericValueToWords(currencyIntegralPart);
            if(!string.IsNullOrEmpty(currencyWords))
            {
                currencyWords += " dollars";
            }

            return Task.FromResult(currencyWords);
        }
    }
}
