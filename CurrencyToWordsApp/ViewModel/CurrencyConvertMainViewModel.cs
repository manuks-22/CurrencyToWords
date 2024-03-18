
using CurrencyToWordsApp.ApiClient;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace CurrencyToWordsApp.ViewModel
{
    public class CurrencyConvertMainViewModel : ViewModelBase
    {
        private readonly ICurrencyToWordsApiClient _apiClient;

        private string _amount; 
        public ICommand SubmitCommand { get; }


        public string Amount
        {
            get { return _amount; }
            set { Set(ref _amount, value); }
        }

        public CurrencyConvertMainViewModel(ICurrencyToWordsApiClient apiClient)
        {
            _apiClient = apiClient;
            SubmitCommand = new RelayCommand(Submit);
        }

        private  async void Submit()
        {
            var amountToConvert = Convert.ToDouble(Amount);
            var result = await _apiClient.GetAmountInWords(amountToConvert);
            System.Windows.MessageBox.Show($"Amount: {result}");
        }
    }
}
