using Blazored.Toast;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PhoneClient;
using PhoneClient.Services;
using PhoneLibrary.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IHttpHelperClass>();
builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<ICountryInterface, CountryService>();
builder.Services.AddBlazoredToast();
builder.Services.AddDevExpressBlazor(x => x.BootstrapVersion = BootstrapVersion.v5);
//builder.Services.AddMvc();

await builder.Build().RunAsync();
