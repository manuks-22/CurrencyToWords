using CurrencyToWordsApp.Infrastructure.Dto;

namespace CurrencyToWordsApp.Service.Service
{
    public interface ICurrencyToWordsService
    {
        /// <summary>
        /// Gets the currency value in words.
        /// </summary>
        /// <param name="currencyValue">The value of currency</param>
        /// <returns></returns>
        Task<CurrencyWordsDto> GetCurrencyValueInWords(double currencyValue);
    }
}