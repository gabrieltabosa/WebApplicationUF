using WebApplicationUF.Models;




namespace WebApplicationUF.Repositories
{
    public class EstadoRepository: IEstadoRepository
    {
        // Campo privado que guarda os estados em memória
        private readonly List<EstadoModel> _estados;
        public EstadoRepository()
        {
            _estados = new List<EstadoModel>
            {
                new EstadoModel(1, "AC", "Acre"),
                new EstadoModel(2, "AL", "Alagoas"),
                new EstadoModel(3, "AP", "Amapá"),
                new EstadoModel(4, "AM", "Amazonas"),
                new EstadoModel(5, "BA", "Bahia"),
                new EstadoModel(6, "CE", "Ceará"),
                new EstadoModel(7, "DF", "Distrito Federal"),
                new EstadoModel(8, "ES", "Espírito Santo"),
                new EstadoModel(9, "GO", "Goiás"),
                new EstadoModel(10, "MA", "Maranhão"),
                new EstadoModel(11, "MT", "Mato Grosso"),
                new EstadoModel(12, "MS", "Mato Grosso do Sul"),
                new EstadoModel(13, "MG", "Minas Gerais"),
                new EstadoModel(14, "PA", "Pará"),
                new EstadoModel(15, "PB", "Paraíba"),
                new EstadoModel(16, "PR", "Paraná"),
                new EstadoModel(17, "PE", "Pernambuco"),
                new EstadoModel(18, "PI", "Piauí"),
                new EstadoModel(19, "RJ", "Rio de Janeiro"),
                new EstadoModel(20, "RN", "Rio Grande do Norte"),
                new EstadoModel(21, "RS", "Rio Grande do Sul"),
                new EstadoModel(22, "RO", "Rondônia"),
                new EstadoModel(23, "RR", "Roraima"),
                new EstadoModel(24, "SC", "Santa Catarina"),
                new EstadoModel(25, "SP", "São Paulo"),
                new EstadoModel(26, "SE", "Sergipe"),
                new EstadoModel(27, "TO", "Tocantins")

            };
        }
        public List<EstadoModel> GetAll()
        {
            return _estados;
        }

        public bool EstadoExists(string sigla)
        {
            for(int i = 0; i < _estados.Count; i++)
            {
                if (_estados[i].Sigla.Equals(sigla, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public EstadoModel? GetBySigla(string sigla)
        {
            for(int i = 0; i < _estados.Count; i++)
            {
                if (_estados[i].Sigla.Equals(sigla, StringComparison.OrdinalIgnoreCase))
                {
                    return _estados[i];
                }
            }
            return null;

        }
        public EstadoModel? GetByName(string nome)
        {
            for(int i = 0; i < _estados.Count; i++)
            {
                if (_estados[i].Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                {
                    return _estados[i];
                }
            }
            return null;
        }
    }
}
