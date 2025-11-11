using System.ComponentModel.DataAnnotations;

namespace WebApplicationUF.Frontend.ViewModel

{

    public class EstadoViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Sigla { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        // Exemplo de lista para preencher um dropdown/grid
        public List<EstadoViewModel> ListaEstados { get; set; }

        public static implicit operator List<object>(EstadoViewModel v)
        {
            throw new NotImplementedException();
        }
    }

}
