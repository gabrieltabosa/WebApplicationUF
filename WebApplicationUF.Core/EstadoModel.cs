namespace WebApplicationUF.Core
{
    public class EstadoModel
    {
        public int Id { get; init; }
        public string Sigla { get; init; }
        public string Nome { get; init; }
        public string Descricao { get; init; }

        public EstadoModel(int id, string sigla, string nome, string descricao)
        {
            Id = id;
            Sigla = sigla;
            Nome = nome;
            Descricao = descricao;

        }
    }
}
