namespace WebApplicationUF.Frontend.ViewModel

{

    public class EstadoApiDto
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; } // Campo extra do Core

    }

}
