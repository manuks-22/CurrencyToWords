using CurrencyToWordsApp.Infrastructure.Logging;
using CurrencyToWordsApp.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CurrencyToWordsApp.Service.Tests
{
    [TestClass]
    public class CurrencyToWordsServiceTests
    {

        [DataRow("0", "zero dollars")]
        [DataRow("1", "one dollar")]
        [DataRow("3", "three dollars")]
        [DataRow("10", "ten dollars")]
        [DataRow("11", "eleven dollars")]
        [DataRow("16", "sixteen dollars")]
        [DataRow("100", "one hundred dollars")]
        [DataRow("100.00", "one hundred dollars")]
        [DataRow("113", "one hundred thirteen dollars")]
        [DataRow("120", "one hundred twenty dollars")]
        [DataRow("999", "nine hundred ninety nine dollars")]
        [DataRow("1001", "one thousand one dollars")]
        [DataRow("1001.00", "one thousand one dollars")]
        [DataRow("1011", "one thousand eleven dollars")]
        [DataRow("1221", "one thousand two hundred twenty one dollars")]
        [DataRow("1213", "one thousand two hundred thirteen dollars")]
        [DataRow("1500", "one thousand five hundred dollars")]
        [DataRow("999999999", "nine hundred ninety nine million nine hundred ninety nine thousand nine hundred ninety nine dollars")]
        [DataTestMethod]
        public async Task GetCurrencyValueInWords_WhenExecutedWithValueWithoutCents_ReturnsDollarText(string inputValue, string expectedText)
        {
            // Arrange
            var decimalValue = decimal.Parse(inputValue);
            var currencyToWordsService = new CurrencyToWordsService(Mock.Of<ILogManager>());

            // Act 
            var result = await currencyToWordsService.GetCurrencyValueInWords(decimalValue);

            // Assert
            Assert.AreEqual(expectedText, result.AmountInWords);

        }


        [DataRow("1.01", "one dollar and one cent")]
        [DataRow("11.99", "eleven dollars and ninety nine cents")]
        [DataRow("100.13", "one hundred dollars and thirteen cents")]
        [DataRow("100.30", "one hundred dollars and thirty cents")]
        [DataRow("1001.69", "one thousand one dollars and sixty nine cents")]
        [DataRow("1221.90", "one thousand two hundred twenty one dollars and ninety cents")]
        [DataRow("1500.99", "one thousand five hundred dollars and ninety nine cents")]
        [DataRow("999999999.99", "nine hundred ninety nine million nine hundred ninety nine thousand nine hundred ninety nine dollars and ninety nine cents")]
        [DataTestMethod]
        public async Task GetCurrencyValueInWords_WhenExecutedWithValueWithCents_ReturnsDollarAndCentsText(string inputValue, string expectedText)
        {
            // Arrange
            var decimalValue = decimal.Parse(inputValue);
            var currencyToWordsService = new CurrencyToWordsService(Mock.Of<ILogManager>());

            // Act 
            var result = await currencyToWordsService.GetCurrencyValueInWords(decimalValue);

            // Assert
            Assert.AreEqual(expectedText, result.AmountInWords);

        }

        [DataRow(".01", "zero dollars and one cent")]
        [DataRow(".99", "zero dollars and ninety nine cents")]
        [DataRow(".13", "zero dollars and thirteen cents")]
        [DataRow(".30", "zero dollars and thirty cents")]
        [DataRow(".69", "zero dollars and sixty nine cents")]
        [DataRow(".90", "zero dollars and ninety cents")]
        [DataRow(".99", "zero dollars and ninety nine cents")]
        [DataTestMethod]
        public async Task GetCurrencyValueInWords_WhenExecutedWithValueWithOnlyCents_ReturnsCentsText(string inputValue, string expectedText)
        {
            // Arrange
            var decimalValue = decimal.Parse(inputValue);
            var currencyToWordsService = new CurrencyToWordsService(Mock.Of<ILogManager>());

            // Act 
            var result = await currencyToWordsService.GetCurrencyValueInWords(decimalValue);

            // Assert
            Assert.AreEqual(expectedText, result.AmountInWords);

        }
    }
}