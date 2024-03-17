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
            //TODO: Support zero, 1 dollar and not dollars

            _logger.Information(@$"Executing method {nameof(GetCurrencyValueInWords)}");

            var dollarPart = Convert.ToInt32(Math.Floor(currencyValue));
            int centsPart = Convert.ToInt32((currencyValue - dollarPart) * 100); 

            var valueToWordsConverter = new ValueToWordsConverter();
            var dollarWords = valueToWordsConverter.ConvertNumericValueToWords(dollarPart);
            if(!string.IsNullOrEmpty(dollarWords))
            {
                dollarWords += " dollars";
            }

            var centsWords = valueToWordsConverter.ConvertNumericValueToWords(centsPart);
            if (!string.IsNullOrEmpty(centsWords))
            {
                dollarWords += " " + centsWords + " cents";
            } 

            return Task.FromResult(dollarWords);
        }
    }
}
