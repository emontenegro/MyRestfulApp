using Microsoft.Extensions.DependencyInjection;
using MyRestfulApp.Domain.Profiles;

namespace MyRestfulApp.API.Extensions
{
    public static class MapperExtension
    {
        public static void AddMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CountryProfile));
        }
    }
}
