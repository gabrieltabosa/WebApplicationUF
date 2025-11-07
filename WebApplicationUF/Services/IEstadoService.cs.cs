using WebApplicationUF.Models;
using System.Collections.Generic;

namespace WebApplicationUF.Services
{
    public interface IEstadoService
    {
        // Método que o Controller usará para listar todos
        List<EstadoModel> GetAll();

        // Método que o Controller usará para verificar a existência
        bool EstadoExists(string sigla);
        EstadoModel? GetBySigla(string sigla);
        EstadoModel? GetByName(string nome);

    }
}
