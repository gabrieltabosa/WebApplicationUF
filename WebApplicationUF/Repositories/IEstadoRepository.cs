namespace WebApplicationUF.Repositories
{
    public interface IEstadoRepository
    {
        List<Models.EstadoModel> GetAll();
        Models.EstadoModel? GetBySigla(string sigla);
        Models.EstadoModel? GetByName(string nome);
        bool EstadoExists(string sigla);
    }
}
