using Carter;
using Geolocations.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GeolocationsDbContext>(
    (options) => options
        .UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"))
        .UseSnakeCaseNamingConvention()
);

builder.Services.AddCarter();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapCarter();

app.Run();
