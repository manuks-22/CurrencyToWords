using CurrencyToWordsApp.Infrastructure.Guard;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyToWordsApp.RestClient
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient _httpClient;

        public RestClient() 
        {
            _httpClient = new HttpClient();
        } 

        public async Task<T> GetAsync<T>(string relativePath)
        {
            Guard.AgainstNullOrEmpty(relativePath, nameof(relativePath));

            var response = await _httpClient.GetAsync(relativePath);

            if (response.Content == null ||
                response.StatusCode == System.Net.HttpStatusCode.BadRequest ||
                response.StatusCode == System.Net.HttpStatusCode.InternalServerError ||
                response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }


            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
