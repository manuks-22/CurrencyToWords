
using System.Globalization;
using System.Windows.Controls;

namespace CurrencyToWordsApp.Validation
{
    public class AmountValidationRule : ValidationRule
    {
        private const double MinValue = 0;
        private const double MaxValue = 9999999999.99;

        public override ValidationResult Validate(object enteredValue, CultureInfo cultureInfo)
        {
            if (enteredValue == null)
                return new ValidationResult(false, string.Empty);

            string valueToValidate = string.Empty;
            if (enteredValue is string stringValue)
                valueToValidate = stringValue.ToString(); 

            if (!double.TryParse(valueToValidate, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = ","}, out double parsedValue))
            {
                return new ValidationResult(false, Resource.EnterValidNumberError);
            }

            if (parsedValue < MinValue || parsedValue > MaxValue)
            {
                return new ValidationResult(false, $"{Resource.AmountRangeError} {MinValue} {MaxValue}.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
