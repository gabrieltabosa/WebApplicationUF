namespace WebApplicationUF.Models
{
    public class EstadoModel
    {
        public int Id { get; init; }
        public string Sigla { get; init; }
        public string Nome { get; init; }

        public EstadoModel(int id, string sigla, string nome)
        {
            Id = id;
            Sigla = sigla;
            Nome = nome;
        }
    }
}
