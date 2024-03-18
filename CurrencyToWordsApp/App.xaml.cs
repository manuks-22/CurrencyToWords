
using CurrencyToWordsApp.ApiClient;
using CurrencyToWordsApp.Infrastructure.Logging;
using CurrencyToWordsApp.Logging;
using CurrencyToWordsApp.RestClient;
using CurrencyToWordsApp.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CurrencyToWordsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            ConfigureServices();

            DispatcherUnhandledException += (sender, args) =>
            {
                var logger = ServiceProvider.GetRequiredService<ILogManager>();

                logger.Error("An unhandled exception has occured", args.Exception);
                MessageBox.Show("An unexpected error has occurred.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                args.Handled = true;  
            };
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                Build();

            services.AddSingleton(configuration);
            services.AddSingleton<ILogManager, ClientLogger>();
            services.AddSingleton<ICurrencyToWordsApiClient, CurrencyToWordsApiClient>();
            services.AddSingleton<IRestClient, RestClient.RestClient>();
            services.AddTransient<CurrencyConvertMainViewModel>();
             
            ServiceProvider = services.BuildServiceProvider();
        }
    }


}
