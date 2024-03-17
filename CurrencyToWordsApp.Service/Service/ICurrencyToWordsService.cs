namespace CurrencyToWordsApp.Service.Service
{
    public interface ICurrencyToWordsService
    {
        /// <summary>
        /// Gets the currency value in words.
        /// </summary>
        /// <param name="currencyValue">The value of currency</param>
        /// <returns></returns>
        Task<string> GetCurrencyValueInWords(double currencyValue);
    }
}