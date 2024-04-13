using Flight.IServices;
using Flight.Models;
using Flight.Profiles;
using Flight.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FlightContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("Flight"), b => b.MigrationsAssembly("Flight"));
});

builder.Services.AddAutoMapper(typeof(AirportProfile).Assembly);

AddServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.Run();

static void AddServices(IServiceCollection services)
{
    services.AddScoped<IAirportService, AirportService>();
}