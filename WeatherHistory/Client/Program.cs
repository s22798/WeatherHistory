using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeatherHistory.Client;
using WeatherHistory.Client.Services.Implementations;
using WeatherHistory.Client.Services.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITemperatureService, TemperatureService>();

await builder.Build().RunAsync();
