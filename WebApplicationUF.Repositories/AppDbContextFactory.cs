using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace InfrastructureUF
{
    public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // O comando Add-Migration é executado na pasta: ...\WebApplicationUF\WebApplicationUF.Repositories
            // Para encontrar o appsettings.json, precisamos subir um nível (..) e entrar na pasta WebApplicationUF.

            // 1. Obtém o diretório atual (onde o comando está sendo executado)
            var currentDirectory = Directory.GetCurrentDirectory();

            // 2. Constrói o caminho para a pasta do projeto Startup (WebApplicationUF)
            var startupProjectPath = Path.Combine(currentDirectory, "..", "WebApplicationUF");

            // 3. Constrói a Configuração
            IConfigurationRoot configuration = new ConfigurationBuilder()
                // Define o caminho base como o diretório do projeto Startup
                .SetBasePath(startupProjectPath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    "A string de conexão 'DefaultConnection' não foi encontrada. " +
                    "Verifique se o arquivo appsettings.json está no diretório 'WebApplicationUF'."
                );
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
