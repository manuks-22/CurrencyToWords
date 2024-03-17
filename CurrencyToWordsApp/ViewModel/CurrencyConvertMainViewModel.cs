
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace CurrencyToWordsApp.ViewModel
{
    public class CurrencyConvertMainViewModel : ViewModelBase
    {
        private string _amount; 
        public ICommand SubmitCommand { get; }


        public string Amount
        {
            get { return _amount; }
            set { Set(ref _amount, value); }
        }

        public CurrencyConvertMainViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
        }

        private void Submit()
        { 
            System.Windows.MessageBox.Show($"Entered Text: {Amount}");
        }
    }
}
