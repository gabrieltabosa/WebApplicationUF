using WebUF.Services;

var builder = WebApplication.CreateBuilder(args);


var apiBase = builder.Configuration["ApiSettings:BaseAddress"] ?? "https://localhost:7179/"; // ajuste

builder.Services.AddControllersWithViews();

// HttpClient tipado
builder.Services.AddHttpClient<EstadoApiClient>(client =>
{
    client.BaseAddress = new Uri(apiBase);
    client.Timeout = TimeSpan.FromSeconds(10);
});

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();