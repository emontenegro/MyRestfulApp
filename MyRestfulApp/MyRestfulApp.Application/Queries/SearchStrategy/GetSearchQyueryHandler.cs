using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using MyRestfulApp.Domain.Common;
using MyRestfulApp.Domain.Models.Response;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MyRestfulApp.Application.Queries.SearchStrategy
{
    public class GetSearchQyueryHandler : IRequestHandler<GetSearchQuery, SearchResponse>
    {
        private readonly AppSettings _appSettings;

        public GetSearchQyueryHandler(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public Task<SearchResponse> Handle(GetSearchQuery request, CancellationToken cancellationToken)
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"{_appSettings.MercadoLibre.BaseUrl}/"+
                $"{_appSettings.MercadoLibre.Sites}"+
                $"{request.Busqueda}");
            var result = response.Result;
            result.EnsureSuccessStatusCode();
            var x = result.Content.ReadAsStringAsync().Result;
            return Task.FromResult(JsonSerializer.Deserialize<SearchResponse>(result.Content.ReadAsStringAsync().Result));
        }
    }
}
