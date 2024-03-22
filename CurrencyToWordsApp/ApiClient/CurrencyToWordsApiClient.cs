using CurrencyToWordsApp.ApiClient;
using CurrencyToWordsApp.Infrastructure.Dto;
using CurrencyToWordsApp.Infrastructure.Logging;
using CurrencyToWordsApp.RestClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyToWordsApp
{
    internal sealed class CurrencyToWordsApiClient: ICurrencyToWordsApiClient
    {
        private readonly IConfigurationRoot _configration;
        private readonly ILogManager _logger;
        private readonly IRestClient _restClient;

        public CurrencyToWordsApiClient(IConfigurationRoot configration, ILogManager logger, IRestClient restClient)
        {
            _configration = configration;
            _logger = logger;
            _restClient = restClient;
        }

        public async Task<string> GetAmountInWords(decimal value)
        {
            var url = $@"{GetUrl(ApiClientConstants.CurrencyToWordsUrl)}{value}";
            var response = await _restClient.GetAsync<CurrencyWordsDto>(url);

            if (response?.Status == null)
            {
                _logger.Error(@$"Error fetching data from API | Invalid data received!");
                throw new InvalidOperationException();
            }
            else if (response.Status.HasError)
            {
                _logger.Error(@$"Error fetching data from crypto currency API | Message : {response.Status.ErrorMessage}");
                throw new InvalidOperationException();
            }


            return response.AmountInWords;
        }

        private string GetUrl(string serviceName)
        {
            var baseUrl = _configration[ApiClientConstants.ApiBaseUrl];
            var serviceUrl = _configration[serviceName];
            return baseUrl + serviceUrl;
        }
    }
}
