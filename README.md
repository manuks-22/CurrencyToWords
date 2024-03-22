# CurrencyToWordsApp
This application converts the numeric value etered in the UI to dollars and cents.
The range that is accepted as the input is from 0 to 999999999,99
The decimals are comma separated.

The app is a single git hub repo with a .NetCore Web API and a WPF Application.
The project CurrencyToWordsApp is the WPF application.
THe project is the CurrencyToWordsApp.Api is the API project.

## Setting up the App
1. Ensure .Net 7.0 sdk is installed.

## Running the App

1. Open the solution in Visual Studio.
2. Publish the project on to a local hosting server (I used IIS Express).
3. Start the hosted Api.
4. Note down the base address of the url.
5. Replace the ApiBaseUrl in appsettings.json in CurrencyToWordsApp WPF project.
6. Build the CurrencyToWordsApp WPF project.
7. Run the WPF application.


 
