﻿using CurrencyToWordsApp.Infrastructure.Dto;
using CurrencyToWordsApp.Infrastructure.Logging;
using CurrencyToWordsApp.Service.Extensions;

namespace CurrencyToWordsApp.Service.Service
{
    public class CurrencyToWordsService : ICurrencyToWordsService
    {
        private readonly ILogManager _logger;

        public CurrencyToWordsService(ILogManager logger)
        {
            _logger = logger; 
        }

        public Task<CurrencyWordsDto> GetCurrencyValueInWords(decimal currencyValue)
        {
            _logger.Information(@$"Executing service method {nameof(GetCurrencyValueInWords)}");

            var dollarPart = Convert.ToInt32(Math.Floor(currencyValue));
            var centsPart = currencyValue.GetDecimalPart();

            var valueToWordsConverter = new ValueToWordsConverter();
            var dollarWords = valueToWordsConverter.ConvertNumericValueToWords(dollarPart);
            if(!string.IsNullOrEmpty(dollarWords))
            {
                dollarWords += (dollarPart == 1 ? " dollar" : " dollars");
            }

            if (centsPart > 0)
            {
                var centsWords = valueToWordsConverter.ConvertNumericValueToWords(centsPart);
                if (!string.IsNullOrEmpty(centsWords))
                {
                    dollarWords += " and " + centsWords + (centsPart == 1 ? " cent" : " cents");
                }
            }

            return Task.FromResult(new CurrencyWordsDto(dollarWords));
        }

    }
}
