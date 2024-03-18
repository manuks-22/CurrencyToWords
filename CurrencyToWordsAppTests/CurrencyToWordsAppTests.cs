using CurrencyToWordsApp;
using CurrencyToWordsApp.ApiClient;
using CurrencyToWordsApp.Infrastructure.Dto;
using CurrencyToWordsApp.Infrastructure.Logging;
using CurrencyToWordsApp.RestClient;
using Microsoft.Extensions.Configuration;
using Moq;

namespace CurrencyToWordsAppTests
{
    [TestClass]
    public class CurrencyToWordsAppTests
    {
        private Mock<IConfigurationRoot> _configrationRootMock;
        private Mock<ILogManager> _loggerMock;
        private Mock<IRestClient> _restClientMock; 

        [TestInitialize]
        public void Initialize()
        {
            _configrationRootMock = new Mock<IConfigurationRoot>();
            _loggerMock = new Mock<ILogManager>();
            _restClientMock = new Mock<IRestClient>();
        }

        [TestMethod]
        public async Task GetAmountInWords_WhenExecuted_CallTheApiWithCorrectUrl()
        {
            // Arrange
            const string apiBaseUrl = $@"https://localhost:7051/";
            const string currencyUrl = $@"CurrencyToWords/api/GetCurrencyWords/";
            const double amount = 2000.56D;

            _configrationRootMock.Setup(x => x[ApiClientConstants.ApiBaseUrl]).Returns("https://localhost:7051/");
            _configrationRootMock.Setup(x => x[ApiClientConstants.CurrencyToWordsUrl]).Returns("CurrencyToWords/api/GetCurrencyWords/");

            _restClientMock.Setup(x => x.GetAsync<CurrencyWordsDto>(It.IsAny<string>())).Returns(Task.FromResult(new CurrencyWordsDto("Nine")));

            var apiClient = new CurrencyToWordsApiClient(_configrationRootMock.Object, _loggerMock.Object, _restClientMock.Object);

            // Act
            await apiClient.GetAmountInWords(amount);

            // Assert
            _restClientMock.Verify(x=>x.GetAsync<CurrencyWordsDto>(It.Is<string>(url =>  url == $@"{apiBaseUrl}{currencyUrl}{amount}")));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetAmountInWords_WhenReturnsInvlidStatus_ThrowsException()
        {
            // Arrange 
            _restClientMock.Setup(x => x.GetAsync<CurrencyWordsDto>(It.IsAny<string>())).Returns(Task.FromResult(new CurrencyWordsDto(string.Empty)));

            var apiClient = new CurrencyToWordsApiClient(_configrationRootMock.Object, _loggerMock.Object, _restClientMock.Object);

            // Act
            await apiClient.GetAmountInWords(2000);
        }


        [TestMethod]
        public async Task GetAmountInWords_WhenSuccessful_ReturnsAmountInWords()
        {
            // Arrange 
            const string amountWords = @"nine hundred and ninety nine dollars sixt two cents";

            _restClientMock.Setup(x => x.GetAsync<CurrencyWordsDto>(It.IsAny<string>())).Returns(Task.FromResult(new CurrencyWordsDto(amountWords)));

            var apiClient = new CurrencyToWordsApiClient(_configrationRootMock.Object, _loggerMock.Object, _restClientMock.Object);

            // Act
            var result = await apiClient.GetAmountInWords(2000);

            // Assert
            Assert.AreEqual(amountWords, result);
        }
    }
}