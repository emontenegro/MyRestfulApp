using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyRestfulApp.API.ExceptionMiddleware;
using MyRestfulApp.API.Extensions;
using MyRestfulApp.API.Filters;
using MyRestfulApp.Application.Queries.CountriesStrategy;
using MyRestfulApp.Application.Services;
using MyRestfulApp.Domain.Common;
using MyRestfulApp.Domain.Profiles;
using MyRestfulApp.Infraestructure;
using MyRestfulApp.Infraestructure.DataContext;

namespace MyRestfulApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Cross Origin Domain Mercadolibre
            services.AddCorsConfig();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat ="'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            
            services.AddApiVersioning(config => {

                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddDbContext<AppDBContext>(options => options.UseInMemoryDatabase(databaseName: "DbUsuarios"));
            services.AddAutoMapper(typeof(UsuarioProfile));
            
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(AuthorizePaisFilter));
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddMediatR(typeof(GetCountryQuery));

            services.AddInjectionConfig(Configuration);

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Restful API v1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ServiceExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
