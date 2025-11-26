using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppUF.Domain;
using WebAppUF.Infrastructure;


namespace InfrastructureUF
{
    public class EstadosRepositorioDbEntity: IEstadoRepository
    {
        // 1. Campo privado para o AppDbContext
        private readonly AppDbContext _context;

        //Construtor para Injeção de Dependência
        // O ASP.NET Core fornecerá automaticamente uma instância do AppDbContext.
        public EstadosRepositorioDbEntity(AppDbContext context)
        {
            _context = context;
        }

        

        
        public List<EstadoModel> GetAll()
        {
            // O .ToList() executa a query SQL e retorna os dados.
            return _context.Estados.ToList();
        }

        
        public bool EstadoExists(string sigla)
        {
            // O .Any() é otimizado para retornar true/false rapidamente.
            return _context.Estados.Any(e => e.Sigla.ToUpper() == sigla.ToUpper());
        }

        
        public EstadoModel? GetById(int id)
        {
            // O .FirstOrDefault() retorna a primeira correspondência ou null.
            return _context.Estados.FirstOrDefault(e => e.Id == id);
        }

        
        public EstadoModel? GetBySigla(string sigla)
        {
            return _context.Estados.FirstOrDefault(e => e.Sigla.ToUpper() == sigla.ToUpper());
        }

        
        public EstadoModel? GetByName(string nome)
        {
            return _context.Estados.FirstOrDefault(e => e.Nome.ToUpper() == nome.ToUpper());
        }

        
        public List<EstadoModel> GetByRegion(string regiao)
        {
            // O .Where() aplica o filtro na query SQL.
            return _context.Estados
                           .Where(e => e.Regiao.ToUpper() == regiao.ToUpper())
                           .ToList();
        }
    }
}
