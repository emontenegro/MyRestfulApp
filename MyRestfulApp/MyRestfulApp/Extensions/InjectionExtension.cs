using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyRestfulApp.API.Extensions
{
    public static class InjectionExtension
    {
        public static void AddInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IDbConnectionStringsFactory, DbConfigurationFactory>();
        }
    }
}
