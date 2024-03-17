using CurrencyToWordsApp.Infrastructure.Logging;
using CurrencyToWordsApp.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CurrencyToWordsApp.Service.Tests
{
    [TestClass]
    public class CurrencyToWordsServiceTests
    {  

        //[DataRow(0, "zero dollars")]
        [DataRow(1, "one dollars")]
        [DataRow(3, "three dollars")]
        [DataRow(10, "ten dollars")]
        [DataRow(11, "eleven dollars")]
        [DataRow(16, "sixteen dollars")]
        [DataRow(100, "one hundred dollars")]
        [DataRow(113, "one hundred thirteen dollars")]
        [DataRow(120, "one hundred twenty dollars")]
        [DataRow(999, "nine hundred ninety nine dollars")]
        [DataRow(1001, "one thousand one dollars")]
        [DataRow(1011, "one thousand eleven dollars")]
        [DataRow(1221, "one thousand two hundred twenty one dollars")]
        [DataRow(1213, "one thousand two hundred thirteen dollars")]
        [DataRow(1500, "one thousand five hundred dollars")]
        [DataTestMethod]
        public async Task GetCurrencyValueInWords_WhenExecutedWithValuewithoutCents_ReturnsDollarText(long inputValue, string expectedText)
        {
            // Arrange
            var currencyToWordsService = new CurrencyToWordsService(Mock.Of<ILogManager>());
            
            // Act 
            var result = await currencyToWordsService.GetCurrencyValueInWords(inputValue);

            // Assert
            Assert.AreEqual(expectedText, result);
        }
    }
}