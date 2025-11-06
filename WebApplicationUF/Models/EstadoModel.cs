namespace WebApplicationUF.Models
{
    public class EstadoModel
    {
        protected int Id { get; init; }
        public string Sigla { get; set; }
        public string Nome { get; init; }

        public EstadoModel(int id, string sigla, string nome)
        {
            Id = id;
            Sigla = sigla;
            Nome = nome;
        }
    }
}
