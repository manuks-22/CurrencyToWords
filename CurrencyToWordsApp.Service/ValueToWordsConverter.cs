

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

        private Dictionary<int, string> _thousandsWords = new() { 
            { 0, "" }, { 1, "thousand" }, { 2, "million" }
        };

        public string ConvertNumericValueToWords(int valueToConvertToWords)
        {
            var result = string.Empty;

            int numericValue = valueToConvertToWords;
            var stack = new Stack<string>();
            var thousandsIndex = 0;

            while (numericValue > 0)
            {
                var thousandsValue = numericValue % 1000;

                if (thousandsValue > 0)
                {

                    stack.Push(" " + _thousandsWords[thousandsIndex]);
                }
                stack.Push(GetWordsFromNumber(thousandsValue));

                numericValue = numericValue / 1000;
                thousandsIndex++;
            }

            if (stack.Any())
            {
                result = string.Join("", stack).Trim();
            }
            return result; 
        }

        private string GetWordsFromNumber(long number)
        {
            string result = string.Empty;

            if (number >= 100)
            {
                var unitsDigit = number / 100;
                if (number > 0)
                {
                    result = " " + _unitsWords[(int)unitsDigit] + " hundred";
                }
            }

            var tensDigit = number % 100;
            if (tensDigit > 0)
            {
                if (tensDigit > 10 && tensDigit < 20)
                {
                    result += " " + _teensWords[(int)tensDigit];
                }
                else
                {
                    var unitsDigit = tensDigit % 10;
                    var tensDigitRounded = tensDigit - unitsDigit;

                    if (tensDigitRounded > 0)
                    {
                        result += " " + _tensWords[(int)tensDigitRounded];
                    }

                    if (unitsDigit != 0)
                    {
                        result += " " + _unitsWords[(int)unitsDigit];
                    } 
                }
            }

            return result;
        }
    }
}
