using CurrencyToWordsApp.Infrastructure.Guard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyToWordsApp.RestClient
{
    internal class RestClient : IRestClient
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

        public async Task<T> PostAsync<T>(string relativePath, object requestData)
        {
            Guard.AgainstNullOrEmpty(relativePath, nameof(relativePath));
            Guard.AgainstNull(requestData, nameof(requestData));

            var json = JsonConvert.SerializeObject(requestData);
            var data = new StringContent(json, Encoding.UTF8, @"application/json");

            var response = await _httpClient.PostAsync(relativePath, data);

            if(response.Content == null || 
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
