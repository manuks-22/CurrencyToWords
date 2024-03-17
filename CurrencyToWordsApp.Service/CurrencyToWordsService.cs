namespace CurrencyToWordsApp.Service
{
    public class CurrencyToWordsService : ICurrencyToWordsService
    {
        public Task<string> GetCurrencyValueInWords(long currencyValue)
        {
            return Task.FromResult("Some Currency Value");
        }
    }
}
