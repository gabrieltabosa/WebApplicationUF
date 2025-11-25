using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppUF.Infrastructure;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using WebAppUF.Domain;

namespace InfrastructureUF
{
    public class EstadoRepositoryDapper: IEstadoRepository
    {
        private readonly string _connectionString;

        // Construtor que recebe a string de conexão via injeção
        public EstadoRepositoryDapper(IConfiguration configuration)
        {
            // Lê a string de conexão diretamente do appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            // Validação simples
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi configurada.");
            }
        }
        public List<EstadoModel> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT *  " +
                    "FROM Estados";
                var estados = connection.Query<EstadoModel>(sql).ToList();
                return estados;
            }
        }

        public bool EstadoExists(string sigla)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT COUNT(1) " +
                    "FROM Estados " +
                    "WHERE UPPER(Sigla) = UPPER(@Sigla)";
                int count = connection.ExecuteScalar<int>(sql, new { Sigla = sigla });
                return count > 0;
            }
        }

        public EstadoModel? GetBySigla(string sigla)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * " +
                    "FROM Estados " +
                    "WHERE UPPER(sigla) = UPPER(@sigla)";
                var estado = connection.QueryFirstOrDefault<EstadoModel>(sql, new { sigla = sigla });
                if (estado != null)
                {
                    return estado;
                }
                else
                {
                    return null;
                }
            }
        }

        public EstadoModel? GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * " +
                    "FROM Estados " +
                    "WHERE Id = @Id";
                var estado = connection.QueryFirstOrDefault<EstadoModel>(sql, new { Id = id });
                if (estado != null)
                {
                    return estado;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<EstadoModel> GetByRegion(string region)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT *" +
                    "FROM Estados " +
                    "WHERE UPPER(Regiao) = UPPER(@region)";
                var estados = connection.Query<EstadoModel>(sql, new { region = region }).ToList();
                return estados;
            }
        }
        public EstadoModel? GetByName(string nome)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * " +
                    "FROM Estados " +
                    "WHERE UPPER(Nome) = UPPER(@Nome)";
                var estado = connection.QueryFirstOrDefault<EstadoModel>(sql, new { Nome = nome });
                if (estado != null)
                {
                    return estado;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
