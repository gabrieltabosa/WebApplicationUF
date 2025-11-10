using WebApplicationUF.Core;

namespace WebApplicationUF.Repositories
{
    public interface IEstadoRepository
    {
        List<Core.EstadoModel> GetAll();
        Core.EstadoModel? GetBySigla(string sigla);
        Core.EstadoModel? GetByName(string nome);
        bool EstadoExists(string sigla);
    }
}
