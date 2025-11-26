namespace WebUF.ViewModel

{

    public class EstadoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Regiao { get; set; }
        public string Capital { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; } // Campo extra do Core

    }

}
