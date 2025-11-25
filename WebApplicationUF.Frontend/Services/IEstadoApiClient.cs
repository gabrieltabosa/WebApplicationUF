using WebUF.ViewModel;

namespace WebUF.Services
{
    public interface IEstadoApiClient
    {
        // 1. Obter todos os Estados
        Task<ApiResponse<List<EstadoViewModel>>> GetAllAsync();

        // 2. Obter Estado pela sigla
        Task<ApiResponse<List<EstadoViewModel>>> GetBySiglaAsync(string sigla);

        // 3. Verificar se um Estado com a sigla existe
        Task<ApiResponse<bool>> EstadoExistsAsync(string sigla);

        // 4. Obter Estado pelo ID
        Task<ApiResponse<EstadoViewModel>> GetByIdAsync(string id);

        // 5. Obter Estados por Região
        Task<ApiResponse<List<EstadoViewModel>>> GetRegiaoAsync(string regiao);
    }
}
