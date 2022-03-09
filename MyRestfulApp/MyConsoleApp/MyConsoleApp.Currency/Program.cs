using MyConsoleApp.Currency.Services;
using System;

namespace MyConsoleApp.Currency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Currency ratio STARTED.");
            var mlService = new MercadoLibreService();
            mlService.GetCurrencyData();
            Console.WriteLine("Currency ratio FINISHED.");
        }
    }
}
