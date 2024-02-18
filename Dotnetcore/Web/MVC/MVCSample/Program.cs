using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCSample.Data;
using MVCSample.Models;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCSampleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCSampleContext") ?? throw new InvalidOperationException("Connection string 'MVCSampleContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


//Globalization
var defaultCulture = new CultureInfo("tr-TR");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};
app.UseRequestLocalization(localizationOptions);


//Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
