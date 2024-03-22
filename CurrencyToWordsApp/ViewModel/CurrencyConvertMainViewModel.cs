
using CurrencyToWordsApp.ApiClient;
using CurrencyToWordsApp.Infrastructure.Logging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CurrencyToWordsApp.ViewModel
{
    public class CurrencyConvertMainViewModel : ViewModelBase
    {
        private readonly ICurrencyToWordsApiClient _apiClient;
        private readonly ILogManager _logger;

        private string _amount; 
        public ICommand SubmitCommand { get; }


        public string Amount
        {
            get { return _amount; }
            set { Set(ref _amount, value); }
        }

        public CurrencyConvertMainViewModel(ICurrencyToWordsApiClient apiClient, ILogManager logger)
        {
            _apiClient = apiClient;
            _logger = logger;

            SubmitCommand = new RelayCommand(Submit);
        }

        private async void Submit()
        {
            if (decimal.TryParse(_amount, new NumberFormatInfo { NumberDecimalSeparator = "," }, out decimal amountValue))
            {
                var result = await _apiClient.GetAmountInWords(amountValue);
                if(result!= null)
                {
                    System.Windows.MessageBox.Show($"Amount: {result}"); 
                }
            }
            else
            {
                _logger.Error("Error parsing invalid amoun on submit.");
                MessageBox.Show(Resource.InvalidAmountValueError, Resource.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
