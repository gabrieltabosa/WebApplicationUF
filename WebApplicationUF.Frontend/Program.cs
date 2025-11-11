using WebApplicationUF.Frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// 1) MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

// 2) Typed HttpClient para EstadoApiClient
builder.Services.AddHttpClient<EstadoApiClient>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];
    if (string.IsNullOrWhiteSpace(apiBaseUrl))
    {
        // log opcional
        throw new InvalidOperationException("A URL base da API ('ApiSettings:BaseUrl') não está configurada no appsettings.json.");
    }

    // normaliza trailing slash
    if (!apiBaseUrl.EndsWith('/')) apiBaseUrl += '/';

    client.BaseAddress = new Uri(apiBaseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.Timeout = TimeSpan.FromSeconds(30); // ajuste conforme necessário
})
// Ex.: adicionar políticas de retry com Polly (opcional)
// .AddPolicyHandler(GetRetryPolicy())
;

// 3) Registre abstrações se desejar desacoplar
// builder.Services.AddScoped<IEstadoService, EstadoApiClient>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Autenticação (se houver) viria aqui: app.UseAuthentication();

app.UseAuthorization(); // movido antes dos Map...

// Mapas de endpoint
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Se você estiver usando Razor Pages, mantenha:
app.MapRazorPages();

app.Run();