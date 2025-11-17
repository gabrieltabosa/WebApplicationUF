namespace WebAppUF.Domain
{
    public class EstadoModel
    {
        public int Id { get; init; }
        public string Sigla { get; init; }
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public string Regiao { get; init; }
        public string Capital { get; init; }

        public EstadoModel(int id, string sigla, string nome, string descricao, string regiao, string capital)
        {
            Id = id;
            Sigla = sigla;
            Nome = nome;
            Descricao = descricao;
            Regiao = regiao;
            Capital = capital;

        }
    }
}
