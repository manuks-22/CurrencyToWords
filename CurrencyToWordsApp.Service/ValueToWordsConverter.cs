

namespace CurrencyToWordsApp.Service
{
    public class ValueToWordsConverter
    {

        private Dictionary<int, string> _unitsWords = new()
        {
            {1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}, {5, "five"},
            {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"}
        };

        private Dictionary<int, string> _teensWords = new() 
        {
            {11, "eleven"}, {12, "twelve"}, {13, "thirteen"}, {14, "fourteen"}, {15, "fifteen"},
            {16, "sixteen"}, {17, "seventeen"}, {18, "eighteen"}, {19, "nineteen"}
        };

        private Dictionary<int, string> _tensWords = new()
        {
            {10, "ten"}, {20, "twenty"}, {30, "thirty"}, {40, "forty"}, {50, "fifty"},
            {60, "sixty"}, {70, "seventy"}, {80, "eighty"}, {90, "ninety"}
        }; 

        public string ConvertNumericValueToWords(int valueToConvertToWords)
        {
            if (valueToConvertToWords == 0)
                return "zero";

            var result = string.Empty;
            var millionDigits = valueToConvertToWords / 1000000;
            if (millionDigits > 0)
            {
                result = GetWordsForUptoFourDigitNumberNumber(millionDigits) + " million ";
                valueToConvertToWords = valueToConvertToWords % 1000000;
            }

            var thousandsDigit = valueToConvertToWords / 1000;
            if (thousandsDigit > 0)
            {
                result += GetWordsForUptoFourDigitNumberNumber(thousandsDigit) + " thousand ";
                valueToConvertToWords = valueToConvertToWords % 1000;
            }

            if (valueToConvertToWords > 0)
            {
                result += GetWordsForUptoFourDigitNumberNumber(valueToConvertToWords);
            }

            return result.Trim();
        }

        private string GetWordsForUptoFourDigitNumberNumber(long number)
        {
            string result = string.Empty;

            var hundredsPart = number / 100;
            if (hundredsPart > 0)
            {
                result = _unitsWords[(int)hundredsPart] + " hundred ";
                number = number % 100;
            }

            if (number > 0)
            {
                if (number > 10 && number < 20)
                {
                    result += _teensWords[(int)number] + " ";
                }
                else
                {
                    var unitsDigit = number % 10;
                    var tensDigitRounded = number - unitsDigit;

                    if (tensDigitRounded > 0)
                    {
                        result += _tensWords[(int)tensDigitRounded] + " ";
                    }

                    if (unitsDigit != 0)
                    {
                        result += _unitsWords[(int)unitsDigit];
                    }
                }
            }

            return result;
        }
    }
}
