using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using small_business_invoice_tracker.Configurations;
using small_business_invoice_tracker.Constants;
using small_business_invoice_tracker.Controllers;
using small_business_invoice_tracker.Services;
using small_business_invoice_tracker.Services.Interfaces;
using System.Text.Json.Serialization;

namespace small_business_invoice_tracker.Helpers
{
    public class MiddlewareHelper
    {
        public static void ConfigureServices<TDbContext>(
            IServiceCollection services,
            string? connectionString,
            CorsOptions corsOptions) where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            }, ServiceLifetime.Scoped);

            services.AddCors(option =>
            {
                option.AddPolicy(General.AllowSpecificOriginsName,
                    builder => builder.AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .WithOrigins(corsOptions.GetAllowedOriginsAsArray()));
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Small Business Invoice Tracker API",
                    Description = "Small Business Invoice Tracker API"
                });
            });
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            services.AddScoped(typeof(GenericController<,>));
            services.AddAuthorization();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddEndpointsApiExplorer();
        }
    }
}
