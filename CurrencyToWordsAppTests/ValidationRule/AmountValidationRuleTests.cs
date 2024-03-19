

using CurrencyToWordsApp.Validation;
using System.Globalization;

namespace CurrencyToWordsAppTests.ValidationRule
{
    [TestClass]
    public  class AmountValidationRuleTests
    {
        [TestMethod]
        public void AmountValidationRule_WhenNullValueIsPassed_ReturnsInvalidError()
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate(null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsFalse(result.IsValid);
        }


        [TestMethod]
        public void AmountValidationRule_WhenInvalidObjectIsPassed_ReturnsInvalidError()
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate(new object(), CultureInfo.CurrentCulture);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void AmountValidationRule_WhenInvalidStringIsPassed_ReturnsInvalidError()
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate("Test", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void AmountValidationRule_WhenNegativeValueStringIsPassed_ReturnsInvalidError()
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate("-1", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [DataTestMethod]
        [DataRow("101.12")]
        [DataRow("101/12")]
        [DataRow("101`12")]
        [DataRow("101^12")]
        [DataRow("101$12")]
        public void AmountValidationRule_WhenDoubleValueWithInvalidDecimalSeparatorIsPassed_ReturnsInvalidError(string invalidDoubleValue)
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate(invalidDoubleValue, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [DataTestMethod]
        [DataRow("0")]
        [DataRow("100")]
        [DataRow("100,12")]
        [DataRow("999,12")]
        [DataRow("999999,12")]
        [DataRow("999999999,12")]
        [DataRow("999999999")]
        public void AmountValidationRule_WhenDoubleValueWithInvalidDecimalSeparatorIsPassed_ReturnsValid (string validValue)
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate(validValue, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void AmountValidationRule_WhenValueWithMultipleCommaDecimalDelimitterIsProvided_ReturnsInvalidError()
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate("999,99999,99", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [DataTestMethod]
        [DataRow(100.123)]
        [DataRow(100.01234)]
        [DataRow(100.023546)]
        [DataRow(100.0235467)]
        [DataRow(100.02354678)]
        [DataRow(100.023546789)]

        public void AmountValidationRule_WhenValueWithMoreThanTwoDecimalPointsIsProvided_ReturnsInvalidError(string invalidDecimalPointsValue)
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate(invalidDecimalPointsValue, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void AmountValidationRule_WhenValueAboveMaxValueIsProvided_ReturnsInvalidError()
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate("9999999999", CultureInfo.CurrentCulture);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [DataTestMethod]
        [DataRow("1989700,12")]
        [DataRow("10234240,34")]
        [DataRow("234234,98")]
        [DataRow("324234,54")]
        [DataRow("99999999,99")]
        [DataRow("999999999,11")]
        public void AmountValidationRule_WhenValidValueWithTwoDecimalPointsIsProvided_ReturnsValid(string validDecimalPointsValue)
        {
            // Arrange 
            var rule = new AmountValidationRule();

            // Act
            var result = rule.Validate(validDecimalPointsValue, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(result.IsValid);
        }
    }
}
