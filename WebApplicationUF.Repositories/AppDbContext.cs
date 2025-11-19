using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppUF.Domain;


namespace InfrastructureUF
{
    // O DbContext é a classe principal do Entity Framework Core.
    // Ele representa a conexão com o banco e permite consultar, inserir, alterar e deletar dados.
    public class AppDbContext : DbContext
    {
        // Construtor do DbContext.
        // O "DbContextOptions" informa qual banco usar, string de conexão, etc.
        // Essas opções são configuradas no Program.cs usando AddDbContext().
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet representa uma tabela no banco de dados.
        // Cada DbSet<T> vira uma tabela, e cada T (EstadoModel) representa uma linha da tabela.
        //
        // Exemplo:
        // - DbSet<EstadoModel> Estados --> tabela "Estados"
        // - Cada EstadoModel é um registro da tabela
        public DbSet<EstadoModel> Estados { get; set; }

        // Esse método é chamado quando o EF está construindo o modelo do banco.
        // Aqui você pode configurar tabelas, nomes de colunas, relacionamentos, chaves, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sempre chama o método base primeiro.
            base.OnModelCreating(modelBuilder);

            // Aqui você pode colocar configurações personalizadas usando Fluent API.
            // Exemplo:
            // modelBuilder.Entity<EstadoModel>().ToTable("EstadosDoBrasil");
            // modelBuilder.Entity<EstadoModel>().HasKey(e => e.Id);
            //
            // No seu caso, se não precisar configurar nada, pode deixar vazio mesmo.
        }
    }
}
