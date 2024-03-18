using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyToWordsApp.Infrastructure.Dto
{
    public record CurrencyWordsDto
    {
        /// <summary>
        /// Get the Amount in words.
        /// </summary>
        public string AmountInWords { get; init; }

        /// <summary>
        /// Gets the status
        /// </summary>
        public StatusDto Status { get; init; }

        public CurrencyWordsDto(string amountInWords)
        {
            AmountInWords = amountInWords; 
            var hasError = string.IsNullOrEmpty(amountInWords);
            var errorMessage = hasError ? "Invalid amount" : string.Empty;
            Status = new StatusDto(hasError, errorMessage);
        }
    }
}
