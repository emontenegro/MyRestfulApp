using MediatR;
using MyRestfulApp.Domain.Models.Response;

namespace MyRestfulApp.Application.Queries.CountriesStrategy
{
    public class GetCountryQuery : IRequest<CountryResponse>
    {
        private string country;
        public string Country { get { return country.ToUpper(); } set { country = value; } }
    }
}
