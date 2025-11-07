// Program.cs

using WebApplicationUF.Repositories; // Usado para referenciar a interface
using WebApplicationUF.Services;    // Usado para referenciar o serviço

var builder = WebApplication.CreateBuilder(args);

// -------------------------------------------------------------
// 1. Configuração de Serviços (Injeção de Dependência)
// -------------------------------------------------------------

// Adiciona o Repositório no container de DI.
// O serviço será criado uma vez por requisição (Scoped).
// Isso é o que torna o seu Controller 'dinâmico', pois ele não se importa com a implementação.
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
// Mapeamos a interface IEstadoService para a implementação EstadoService
builder.Services.AddScoped<IEstadoService, EstadoService>();
// Adiciona suporte a Controllers com Views (MVC)
builder.Services.AddControllersWithViews();

// -------------------------------------------------------------
// 2. Construção e Configuração do Pipeline de Requisições
// -------------------------------------------------------------

var app = builder.Build();

// Verifica o Ambiente e Configura o Middleware de Erros
if (app.Environment.IsDevelopment()) // Verifica se estamos no ambiente de Desenvolvimento
{
    // Se for Desenvolvimento, usa a página de exceção detalhada
    app.UseDeveloperExceptionPage();
}
else
{
    // Se for Produção/Staging, usa a página de erro padrão
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// -------------------------------------------------------------
// 3. Middlewares Padrão
// -------------------------------------------------------------

app.UseHttpsRedirection();
app.UseStaticFiles(); // Habilita o uso de arquivos estáticos (CSS, JS, Imagens)

app.UseRouting(); // Determina onde a requisição deve ir

app.UseAuthorization(); // Verifica permissões do usuário

// -------------------------------------------------------------
// 4. Mapeamento de Rotas
// -------------------------------------------------------------

// Rota padrão (Controller, Action, ID opcional)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 💡 Dica: Se quiser rotas específicas da API (como as que criamos no controlador), 
// você pode adicioná-las aqui ou usar atributos no Controller (o mais comum).
// Exemplo de mapeamento para as rotas do Estado (opcional, mas recomendado para MVC):
// app.MapControllerRoute(
//     name: "estados",
//     pattern: "estados/{action}/{sigla?}",
//     defaults: new { controller = "Estado" });

app.Run();
