
using System.Threading.Tasks;

namespace CurrencyToWordsApp.RestClient
{
    public interface IRestClient
    { 
        Task<T> GetAsync<T>(string relativePath); 
    }
}
