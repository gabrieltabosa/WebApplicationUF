using Microsoft.AspNetCore.Builder;
using WebApplicationUF.Repositories;
using WebApplicationUF.Services;

var builder = WebApplication.CreateBuilder(args);

// DI - serviços
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IEstadoService, EstadoService>();

// Se a aplicação for majoritariamente API, prefira AddControllers()
builder.Services.AddControllers(); // mais enxuto para APIs
// Se precisar de Views/Razor, use AddControllersWithViews() em vez disso
// builder.Services.AddControllersWithViews();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ambiente / Swagger
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(); // /swagger
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// *** IMPORTANTE: expõe endpoints definidos por atributos ([Route], [HttpGet], etc.) ***
app.MapControllers();



// Opcional: WelcomePage — cuidado: intercepta "/".
// Remova ou comente se quiser que Home/Index responda a "/".
/*
app.UseWelcomePage(new WelcomePageOptions
{
    Path = "/"
});
*/

app.Run();
