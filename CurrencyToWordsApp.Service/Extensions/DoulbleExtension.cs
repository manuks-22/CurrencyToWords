using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyToWordsApp.Service.Extensions
{
    internal static class DoulbleExtension
    {
        public static int GetDecimalPart(this double number)
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
