using WebAppUF.Domain;




namespace WebAppUF.Infrastructure
{
    public class EstadoRepository: IEstadoRepository
    {
        // Campo privado que guarda os estados em memória
        private readonly List<EstadoModel> _estados;
        public EstadoRepository()
        {
            _estados = new List<EstadoModel>
            {
                new EstadoModel(1, "AC", "Acre", "Estado na Região Norte, conhecido pela Floresta Amazônica e pela extração de borracha.", "Norte", "Rio Branco"),
                new EstadoModel(2, "AL", "Alagoas", "Estado do Nordeste, famoso pelas praias de águas claras e coqueirais.", "Nordeste", "Maceió"),
                new EstadoModel(3, "AP", "Amapá", "Estado na Região Norte, com grande biodiversidade e atravessado pela linha do Equador.", "Norte", "Macapá"),
                new EstadoModel(4, "AM", "Amazonas", "O maior estado do Brasil, coberto em grande parte pela Floresta Amazônica e cortado pelo Rio Amazonas.", "Norte", "Manaus"),
                new EstadoModel(5, "BA", "Bahia", "Estado do Nordeste, centro da cultura afro-brasileira, com forte influência na culinária e música.", "Nordeste", "Salvador"),
                new EstadoModel(6, "CE", "Ceará", "Estado nordestino conhecido pelas suas famosas dunas e praias, como Jericoacoara.", "Nordeste", "Fortaleza"),
                new EstadoModel(7, "DF", "Distrito Federal", "Onde se localiza Brasília, capital federal do Brasil, planejada por Lúcio Costa e Oscar Niemeyer.", "Centro-Oeste", "Brasília"),
                new EstadoModel(8, "ES", "Espírito Santo", "Estado da Região Sudeste, possui litoral extenso e é um grande produtor de café e minério.", "Sudeste", "Vitória"),
                new EstadoModel(9, "GO", "Goiás", "Localizado no Centro-Oeste, conhecido pelo ecoturismo na Chapada dos Veadeiros e forte agropecuária.", "Centro-Oeste", "Goiânia"),
                new EstadoModel(10, "MA", "Maranhão", "Estado do Nordeste com o Parque Nacional dos Lençóis Maranhenses, de beleza singular.", "Nordeste", "São Luís"),
                new EstadoModel(11, "MT", "Mato Grosso", "Estado do Centro-Oeste que abriga parte da Amazônia, Cerrado e a região do Pantanal.", "Centro-Oeste", "Cuiabá"),
                new EstadoModel(12, "MS", "Mato Grosso do Sul", "Famoso pela região do Pantanal, um dos maiores centros de biodiversidade do planeta.", "Centro-Oeste", "Campo Grande"),
                new EstadoModel(13, "MG", "Minas Gerais", "Estado da Região Sudeste, conhecido pela culinária, cidades históricas coloniais e serras.", "Sudeste", "Belo Horizonte"),
                new EstadoModel(14, "PA", "Pará", "Estado da Região Norte, importante polo de recursos minerais e com forte presença da cultura amazônica.", "Norte", "Belém"),
                new EstadoModel(15, "PB", "Paraíba", "Estado nordestino famoso pelo ponto mais oriental das Américas, a Ponta do Seixas.", "Nordeste", "João Pessoa"),
                new EstadoModel(16, "PR", "Paraná", "Estado da Região Sul, onde estão localizadas as famosas Cataratas do Iguaçu.", "Sul", "Curitiba"),
                new EstadoModel(17, "PE", "Pernambuco", "Estado do Nordeste, berço de cidades históricas como Olinda e o Porto Digital no Recife.", "Nordeste", "Recife"),
                new EstadoModel(18, "PI", "Piauí", "Estado do Nordeste, conhecido pelo Parque Nacional Serra da Capivara, patrimônio da UNESCO.", "Nordeste", "Teresina"),
                new EstadoModel(19, "RJ", "Rio de Janeiro", "Famoso no mundo todo por suas praias, o Cristo Redentor e o Pão de Açúcar. Sede de grande metrópole.", "Sudeste", "Rio de Janeiro"),
                new EstadoModel(20, "RN", "Rio Grande do Norte", "Estado nordestino com o litoral repleto de dunas e salinas, com destaque para Natal.", "Nordeste", "Natal"),
                new EstadoModel(21, "RS", "Rio Grande do Sul", "Estado da Região Sul, com forte influência da cultura gaúcha e grande produção de vinhos.", "Sul", "Porto Alegre"),
                new EstadoModel(22, "RO", "Rondônia", "Estado da Região Norte com grande desenvolvimento da agropecuária e fronteira com a Bolívia.", "Norte", "Porto Velho"),
                new EstadoModel(23, "RR", "Roraima", "O estado mais setentrional do Brasil, conhecido pelo Monte Roraima e áreas indígenas.", "Norte", "Boa Vista"),
                new EstadoModel(24, "SC", "Santa Catarina", "Estado da Região Sul, com belas praias e forte influência da colonização europeia.", "Sul", "Florianópolis"),
                new EstadoModel(25, "SP", "São Paulo", "O estado mais populoso e rico do Brasil, centro financeiro e industrial da América Latina.", "Sudeste", "São Paulo"),
                new EstadoModel(26, "SE", "Sergipe", "O menor estado do Brasil, conhecido pelas praias e pela cultura ribeirinha no Rio São Francisco.", "Nordeste", "Aracaju"),
                new EstadoModel(27, "TO", "Tocantins", "O estado mais jovem do Brasil, criado em 1988, com o Parque Estadual do Jalapão.", "Norte", "Palmas")
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
        public List<EstadoModel> GetByRegion(string regiao)
        {
            List<EstadoModel> estadosRegiao = new List<EstadoModel>();
            for(int i = 0; i < _estados.Count; i++)
            {
                if (_estados[i].Regiao.Equals(regiao, StringComparison.OrdinalIgnoreCase))
                {
                    estadosRegiao.Add(_estados[i]);
                }
            }
            return estadosRegiao;
        }
    }
}
