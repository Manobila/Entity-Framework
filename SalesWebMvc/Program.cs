using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System.Configuration;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// 1. Busca a string de conexão configurada no appsettings.json
var connectionString = builder.Configuration.GetConnectionString("SalesWebMvcContext")
    ?? throw new InvalidOperationException("Connection string 'SalesWebMvcContext' not found.");

// 2. Detecta automaticamente a versão do seu servidor MySQL
var serverVersion = ServerVersion.AutoDetect(connectionString);

// 3. Substitui o SQL Server pelo Pomelo MySQL
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(connectionString, serverVersion, b => b.MigrationsAssembly("SalesWebMvc")));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var emUs = new CultureInfo("en-US");
var localizationOpdions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(emUs),
    SupportedCultures = new List<CultureInfo> { emUs },
    SupportedUICultures = new List<CultureInfo> { emUs }
};
app.UseRequestLocalization(localizationOpdions);



using (var scope = app.Services.CreateScope())
{
    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seedingService.Seed();
}

app.Run();
