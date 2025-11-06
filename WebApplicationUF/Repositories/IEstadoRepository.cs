namespace WebApplicationUF.Repositories
{
    public interface IEstadoRepository
    {
        List<Models.EstadoModel> ObterTodos();
        Models.EstadoModel? ObterPorSigla(string sigla);
        Models.EstadoModel? ObterEstadoPorNome(string nome);

    }
}
