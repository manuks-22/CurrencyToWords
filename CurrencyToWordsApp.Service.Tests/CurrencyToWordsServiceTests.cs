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
        [DataRow(1.01, "one dollars and one cents")]
        [DataRow(3, "three dollars")]
        [DataRow(10, "ten dollars")]
        [DataRow(11, "eleven dollars")]
        [DataRow(11.99, "eleven dollars and ninety nine cents")]
        [DataRow(16, "sixteen dollars")]
        [DataRow(100, "one hundred dollars")]
        [DataRow(100.00, "one hundred dollars")]
        [DataRow(100.13, "one hundred dollars and thirteen cents")]
        [DataRow(100.30, "one hundred dollars and thirty cents")]
        [DataRow(113, "one hundred thirteen dollars")]
        [DataRow(120, "one hundred twenty dollars")]
        [DataRow(999, "nine hundred ninety nine dollars")]
        [DataRow(1001, "one thousand one dollars")]
        [DataRow(1001.00, "one thousand one dollars")]
        [DataRow(1001.69, "one thousand one dollars and sixty nine cents")]
        [DataRow(1011, "one thousand eleven dollars")]
        [DataRow(1221, "one thousand two hundred twenty one dollars")]
        [DataRow(1221.90, "one thousand two hundred twenty one dollars and ninety cents")]
        [DataRow(1213, "one thousand two hundred thirteen dollars")]
        [DataRow(1500, "one thousand five hundred dollars")]
        [DataRow(1500.99, "one thousand five hundred dollars and ninety nine cents")]
        [DataTestMethod]
        public async Task GetCurrencyValueInWords_WhenExecutedWithValuewithoutCents_ReturnsDollarText(double inputValue, string expectedText)
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