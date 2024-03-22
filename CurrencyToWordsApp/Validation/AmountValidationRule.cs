
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Controls;

namespace CurrencyToWordsApp.Validation
{
    public class AmountValidationRule : ValidationRule
    {
        private const decimal MinValue = 0M;
        private const decimal MaxValue = 999999999.99M;

        public override ValidationResult Validate(object enteredValue, CultureInfo cultureInfo)
        {
            const string validDecimalSeparator = ",";
            const string inValidDecimalSeparator = ".";

            if (enteredValue == null)
                return new ValidationResult(false, string.Empty);

            string valueToValidate = string.Empty;
            if (enteredValue is string stringValue)
                valueToValidate = stringValue.ToString(); 

            // Validate . is not accepted as decimal separator
            if(valueToValidate.Contains(inValidDecimalSeparator))
            {
                return new ValidationResult(false, string.Format(Resource.EnterValidDecimalNumberError, validDecimalSeparator) );
            }

            // Validate that not more than two valid separators are present
            if (valueToValidate.Count(x=>x.ToString() == validDecimalSeparator) > 1)
            {
                return new ValidationResult(false, Resource.EnterValidNumberError);
            } 

            // Validate that not more than two decimal points is accepted
            if (valueToValidate.Contains(validDecimalSeparator))
            {
                var decimalString = valueToValidate.Split(validDecimalSeparator);
                if (decimalString[1].Length > 2)
                    return new ValidationResult(false, string.Format(Resource.AmountRangeError, MinValue, MaxValue));
            }


            if (!decimal.TryParse(valueToValidate, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = validDecimalSeparator }, out decimal parsedValue))
            {
                return new ValidationResult(false, Resource.EnterValidNumberError);
            }

            if (parsedValue < MinValue || parsedValue > MaxValue)
            {
                return new ValidationResult(false, string.Format(Resource.AmountRangeError,  MinValue, MaxValue));
            }

            return ValidationResult.ValidResult;
        }
    }
}
