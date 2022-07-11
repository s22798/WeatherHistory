using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using WeatherHistory.Server.Data;
using WeatherHistory.Server.Services.Implementations;
using WeatherHistory.Server.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<WeatherDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ILocationDbService, LocationDbService>();
builder.Services.AddScoped<ITemperatureDbService, TemperatureDbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
