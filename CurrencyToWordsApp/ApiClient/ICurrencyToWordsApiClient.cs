
using System.Threading.Tasks;

namespace CurrencyToWordsApp.ApiClient
{
    public interface ICurrencyToWordsApiClient
    {
        public Task<string> GetAmountInWords(decimal value);
    }
}
