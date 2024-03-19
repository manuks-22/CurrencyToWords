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
    public class BoolToInvertConverterTests
    {
        [TestMethod]
        public void BoolToInvertConverter_WhenProvidedWithStringInput_ReturnsFalse()
        {
            // Arrange
            var converter = new BoolToInvertConverter();

            // Act
            var resut = converter.Convert("Test", typeof(string), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsFalse((bool)resut);
        }

        [TestMethod]
        public void BoolToInvertConverter_WhenProvidedWithFalse_ReturnsTrue()
        {
            // Arrange
            var converter = new BoolToInvertConverter();

            // Act
            var resut = converter.Convert(false, typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsTrue((bool)resut);
        }

        [TestMethod]
        public void BoolToInvertConverter_WhenProvidedWithTrue_ReturnsFalse()
        {
            // Arrange
            var converter = new BoolToInvertConverter();

            // Act
            var resut = converter.Convert(true, typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsFalse((bool)resut);
        }

    }
}
