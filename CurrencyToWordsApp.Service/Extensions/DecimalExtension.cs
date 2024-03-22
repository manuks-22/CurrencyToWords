using System.Globalization; 

namespace CurrencyToWordsApp.Service.Extensions
{
    internal static class DecimalExtension
    {
        public static int GetDecimalPart(this decimal number)
        {
            //TODO: This is expensive, need a better solution.
            var decimalString = number.ToString(CultureInfo.InvariantCulture);
            var parts =  decimalString.Split(".");
            if (parts.Length > 1)
                return Convert.ToInt32(parts[1]);

            return 0;
        }
    }
}
