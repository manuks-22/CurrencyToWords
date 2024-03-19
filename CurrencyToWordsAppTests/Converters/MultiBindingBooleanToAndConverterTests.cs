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
    public class MultiBindingBooleanToAndConverterTests
    {

        [TestMethod]
        public void MultiBindingBooleanToAndConverterTests_WhenNullPassed_ReturnsFalse()
        {
            // Arrange
            var converter = new MultiBindingBooleanToAndConverter();

            // Act
            var resut = converter.Convert(null, typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsFalse((bool)resut);
        }

        [TestMethod]
        public void MultiBindingBooleanToAndConverterTests_WhenPassedEmptyArray_ReturnsFalse()
        {
            // Arrange
            var converter = new MultiBindingBooleanToAndConverter();
            bool[] bools = { };

            // Act
            var resut = converter.Convert(bools.Cast<object>().ToArray(), typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsFalse((bool)resut);
        }

        [TestMethod]
        public void MultiBindingBooleanToAndConverterTests_WhenPassedNonBooleanArray_ReturnsFalse()
        {
            // Arrange
            var converter = new MultiBindingBooleanToAndConverter();
            string[] strings = { "Test", "MoreTest" };

            // Act
            var resut = converter.Convert(strings.Cast<object>().ToArray(), typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsFalse((bool)resut);
        }


        [TestMethod]
        public void MultiBindingBooleanToAndConverterTests_WhenPassedBooleanArrayWithAFalseValue_ReturnsFalse()
        {
            // Arrange
            var converter = new MultiBindingBooleanToAndConverter();
            bool[] bools = { true, true, false, true };

            // Act
            var resut = converter.Convert(bools.Cast<object>().ToArray(), typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsFalse((bool)resut);
        }

        [TestMethod]
        public void MultiBindingBooleanToAndConverterTests_WhenPassedBooleanArrayWithAllTrueValues_ReturnsTrue()
        {
            // Arrange
            var converter = new MultiBindingBooleanToAndConverter();
            bool[] bools = { true, true, true, true };

            // Act
            var resut = converter.Convert(bools.Cast<object>().ToArray(), typeof(bool), null, CultureInfo.CurrentCulture);

            // Assert
            Assert.IsTrue(resut is bool);
            Assert.IsTrue((bool)resut);
        }
    }
}
