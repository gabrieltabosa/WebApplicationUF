using Microsoft.AspNetCore.Rewrite;
using WebUF.Profiles;
using WebUF.Services;

var builder = WebApplication.CreateBuilder(args);


var apiBase = builder.Configuration["ApiSettings:BaseAddress"] ?? "https://localhost:7179/"; // ajuste

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<EstadoProfile>());

// HttpClient tipado
builder.Services.AddHttpClient<IEstadoApiClient, EstadoApiClient>(client =>
{
    client.BaseAddress = new Uri(apiBase);
    client.Timeout = TimeSpan.FromSeconds(10);
});

var app = builder.Build();


app.UseHttpsRedirection();// Redireciona HTTP para HTTPS
app.UseHsts(); // Adiciona cabeçalhos de segurança (HTTP Strict Transport Security)
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();