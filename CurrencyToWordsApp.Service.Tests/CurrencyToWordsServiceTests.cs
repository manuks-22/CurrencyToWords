using CurrencyToWordsApp.Infrastructure.Logging;
using CurrencyToWordsApp.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CurrencyToWordsApp.Service.Tests
{
    [TestClass]
    public class CurrencyToWordsServiceTests
    { 

        [TestMethod]
        public async Task GetCurrencyValueInWords_WhenExecutedWithDummyInput_ReturnsDummyMessage()
        {
            // Arrange
            var currencyToWordsService = new CurrencyToWordsService(Mock.Of<ILogManager>());

            // Act 
            var result = await currencyToWordsService.GetCurrencyValueInWords(1000);

            // Assert
            Assert.AreEqual("Some Currency Value", result);
        }
    }
}