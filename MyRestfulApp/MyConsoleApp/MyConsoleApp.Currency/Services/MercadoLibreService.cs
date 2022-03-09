using MyConsoleApp.Currency.Models;
using MyConsoleApp.Currency.Writer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace MyConsoleApp.Currency.Services
{
    public class MercadoLibreService
    {
        private static readonly string APICurrenciesUrl = "https://api.mercadolibre.com/currencies/";
        private static readonly string APICurrenciesConversionUrl = "https://api.mercadolibre.com/currency_conversions/search?from={0}&to=USD";
        private List<MyCurrency> MyCurrenciesConversion;

        public MercadoLibreService()
        {
        }

        public void GetCurrencyData()
        {
            try
            {
                var response = ConnectToClient(APICurrenciesUrl);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rawResponse = readTask.GetAwaiter().GetResult();
                    this.MyCurrenciesConversion = JsonSerializer.Deserialize<List<MyCurrency>>(rawResponse);

                    for (int i = 0; i < MyCurrenciesConversion.Count; i++)
                    {
                        var element = this.MyCurrenciesConversion[i];
                        GetCurrencyConversionsAsync(ref element);
                    }

                    var currencyJson = JsonSerializer.Serialize(MyCurrenciesConversion);
                    JsonWriter.Write(currencyJson, "currency_conversions");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GetCurrencyConversionsAsync(ref MyCurrency currency)
        {
            try
            {
                var response = ConnectToClient(string.Format(APICurrenciesConversionUrl, currency.id));
                if (response == null)
                    throw new Exception($"Can't connect to {string.Format(APICurrenciesConversionUrl, currency.id)}. Please review if it's reachable.");

                var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var rawResponse = readTask.GetAwaiter().GetResult();
                var ratioObject = JsonSerializer.Deserialize<CurrencyConversion>(rawResponse);
                currency.todolar = ratioObject.ratio;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private HttpResponseMessage ConnectToClient(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add
            (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                return null;
            }
        }
    }
}
