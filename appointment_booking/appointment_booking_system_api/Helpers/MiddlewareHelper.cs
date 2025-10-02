using appointment_booking_system.Configurations;
using appointment_booking_system.Constants;
using appointment_booking_system.Controllers;
using appointment_booking_system.Services;
using appointment_booking_system.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace appointment_booking_system.Helpers
{
    public class MiddlewareHelper
    {
        public static void ConfigureServices<TDbContext>(
            IServiceCollection services,
            string? connectionString,
            CorsOptions corsOptions,
            ConfigurationManager configuration) where TDbContext : DbContext
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
                    Title = "Appointment Booking System API",
                    Description = "Appointment Booking System API"
                });
            });
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            services.AddScoped<IBookingService, BookingService>();
            services.Configure<EmailSettings>(configuration.GetSection("Email"));
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped(typeof(GenericController<,>));
            services.AddAuthorization();
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            services.AddEndpointsApiExplorer();
        }
    }
}
