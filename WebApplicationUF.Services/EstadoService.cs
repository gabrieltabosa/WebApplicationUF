

using WebAppUF.Domain;
using WebAppUF.Infrastructure;

namespace WebAppUF.Application

{
    public class EstadoService : IEstadoService
    {
        // Dependência para o repositório (injetada via construtor)
        private readonly IEstadoRepository _repository;
        public EstadoService(IEstadoRepository repository)
        {
            _repository = repository;
        }
        public List<EstadoModel> GetAll()
        {
            return _repository.GetAll();
        }
        public EstadoModel? GetBySigla(string sigla)
        {
            sigla = sigla.ToUpper().Trim();
            return _repository.GetBySigla(sigla);
        }
        public EstadoModel? GetByName(string nome)
        {
            return _repository.GetByName(nome);
        }
        public bool EstadoExists(string sigla)
        {
            sigla = sigla.ToUpper();
            return _repository.EstadoExists(sigla);
        }

    }
}
