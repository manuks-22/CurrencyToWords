using CurrencyToWordsApp.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyToWordsAppTests.Converters
{
    [TestClass]
    public class EmptyTextLengthToBoolConverterTests
    {
        [TestMethod]
        public void EmptyTextLengthToBoolConverterTests_WhenProvidedWithNull_ReturnsFalse()
        {
            // Arrange
            var converter = new EmptyTextLengthToBoolConverter();

            // Act
            var resut = converter.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsFalse((bool)resut);
        }

        [TestMethod]
        public void EmptyTextLengthToBoolConverterTests_WhenProvidedWithString_ReturnsFalse()
        {
            // Arrange
            var converter = new EmptyTextLengthToBoolConverter();

            // Act
            var resut = converter.Convert("Test", typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsFalse((bool)resut);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(10)]
        [DataRow(13)]
        public void EmptyTextLengthToBoolConverterTests_WhenProvidedWithNonZeroValue_ReturnsFalse(int length)
        {
            // Arrange
            var converter = new EmptyTextLengthToBoolConverter();

            // Act
            var resut = converter.Convert(length, typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsTrue((bool)resut);
        }


        [TestMethod]
        public void EmptyTextLengthToBoolConverterTests_WhenProvidedWithZeroValue_ReturnsFalse()
        {
            // Arrange
            var converter = new EmptyTextLengthToBoolConverter();

            // Act
            var resut = converter.Convert(0, typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsFalse((bool)resut);
        }

        [TestMethod]
        public void EmptyTextLengthToBoolConverterTests_WhenProvidedWithGreaterThanZeroValue_ReturnsTrue()
        {
            // Arrange
            var converter = new EmptyTextLengthToBoolConverter();

            // Act
            var resut = converter.Convert(3, typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsTrue((bool)resut);
        }
    }
}
