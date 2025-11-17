using WebAppUF.Domain;

namespace WebAppUF.Infrastructure
{
    public interface IEstadoRepository
    {
        List<Domain.EstadoModel> GetAll();
        Domain.EstadoModel? GetBySigla(string sigla);
        Domain.EstadoModel? GetByName(string nome);
        List<EstadoModel> GetByRegion(string regiao);

        bool EstadoExists(string sigla);
    }
}
