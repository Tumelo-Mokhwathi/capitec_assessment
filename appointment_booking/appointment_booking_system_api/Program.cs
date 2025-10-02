using appointment_booking_system.Configurations;
using appointment_booking_system.Constants;
using appointment_booking_system.DataAccess;
using appointment_booking_system.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration;

var corsOptions = configuration.GetSection("Cors").Get<CorsOptions>()
    ?? throw new InvalidOperationException("Cors configuration is missing or invalid.");

MiddlewareHelper.ConfigureServices<ApplicationDbContext>(
    builder.Services,
    configuration.GetConnectionString("DefaultConnection"),
    corsOptions);

var app = builder.Build();

app.UseCors(General.AllowSpecificOriginsName);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
