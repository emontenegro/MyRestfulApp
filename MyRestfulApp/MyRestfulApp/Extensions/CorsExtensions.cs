using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MyRestfulApp.API.Extensions
{
    public static class CorsExtensions
    {
        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy-public", builder => builder.AllowAnyOrigin().Build());
            });
        }

        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy-public");
        }
    }
}
