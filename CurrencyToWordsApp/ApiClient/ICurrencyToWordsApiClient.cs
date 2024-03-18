using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyToWordsApp.ApiClient
{
    public interface ICurrencyToWordsApiClient
    {
        public Task<string> GetAmountInWords(double value);
    }
}
