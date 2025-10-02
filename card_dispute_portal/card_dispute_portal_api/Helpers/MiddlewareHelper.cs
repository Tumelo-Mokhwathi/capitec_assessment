using card_dispute_portal.Configurations;
using card_dispute_portal.Constants;
using card_dispute_portal.Services;
using card_dispute_portal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace card_dispute_portal.Helpers
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
                    Title = "Card Dispute Portal API",
                    Description = "Card Dispute Portal API"
                });
            });

            services.AddScoped<ICardTransactionService, CardTransactionService>();
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
        }
    }
}
