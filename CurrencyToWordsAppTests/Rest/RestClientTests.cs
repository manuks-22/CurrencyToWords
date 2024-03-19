using CurrencyToWordsApp.RestClient;
using Moq;

namespace CurrencyToWordsAppTests.Rest
{
    [TestClass]
    public class RestClientTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAsync_WhenNullUrlIsPassed_ThrowsException()
        {
            // Arrange
            var restClient = new RestClient();

            // Act
            await restClient.GetAsync<string>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetAsync_WhenEmptyNullUrlIsPassed_ThrowsException()
        {
            // Arrange
            var restClient = new RestClient();

            // Act
            await restClient.GetAsync<string>(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetAsync_WhenCalledWithInvalidUrl_ThrowsException()
        {
            // Arrange
            var restClient = new RestClient();

            // Act
            await restClient.GetAsync<string>("abc_url");
        } 
    }
}
