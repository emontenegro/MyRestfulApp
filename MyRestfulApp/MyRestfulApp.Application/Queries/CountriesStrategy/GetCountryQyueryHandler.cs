using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using MyRestfulApp.Domain.Common;
using MyRestfulApp.Domain.Models.Response;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MyRestfulApp.Application.Queries.CountriesStrategy
{
    public class GetSearchQyueryHandler : IRequestHandler<GetCountryQuery, CountryResponse>
    {
        private readonly AppSettings _appSettings;

        public GetSearchQyueryHandler(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public Task<CountryResponse> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"{_appSettings.MercadoLibre.BaseUrl}/"+
                $"{_appSettings.MercadoLibre.ClassifiedLocations}/"+
                $"{request.Country}");
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            return Task.FromResult(JsonSerializer.Deserialize<CountryResponse>(result.Content.ReadAsStringAsync().Result));
        }
    }
}
