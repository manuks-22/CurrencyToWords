using CurrencyToWordsApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CurrencyToWordsApp.View
{
    /// <summary>
    /// Interaction logic for CurrencyConvertMainView.xaml
    /// </summary>
    public partial class CurrencyConvertMainView : Window
    {
        public CurrencyConvertMainView()
        {
            InitializeComponent();

            var app = (App)Application.Current;
            DataContext = app.ServiceProvider.GetRequiredService<CurrencyConvertMainViewModel>();
        }
    }
}
