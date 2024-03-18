
using System;
using System.Threading.Tasks;

namespace CurrencyToWordsApp.RestClient
{
    internal interface IRestClient
    { 
        Task<T> GetAsync<T>(string relativePath);

        Task<T> PostAsync<T>(string relativePath, object requestData);
    }
}
