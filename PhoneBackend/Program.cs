using CountryData.Standard;
using Microsoft.EntityFrameworkCore;
using PhoneBackend.Data;
using PhoneBackend.Repository;
using PhoneLibrary.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<CountryHelper>();
builder.Services.AddScoped<ICountryInterface, CountryService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContextDb>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("ProductDbConnections") ??
                     throw new InvalidOperationException("connection string is invalid"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
