using System.Net.Http.Json;
using WebApplicationUF.Core;

namespace WebApplicationUF.Frontend.Services
{
    public class EstadoApiClient
    {
        private readonly HttpClient _httpClient;
        public EstadoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<EstadoModel>> GetAllAsync()
        {
            // Chama o endpoint da sua API (ex: GET /api/Estado)
            var estados = await _httpClient.GetFromJsonAsync<List<EstadoModel>>("api/estados");
            return estados ?? new List<EstadoModel>();
        }
        // Método GET para Sigla (Retorna um estado específico)
        public async Task<EstadoModel?> GetBySiglaAsync(string sigla)
        {
            // Chama o endpoint da sua API (ex: GET /api/Estado/{sigla})
            var estado = await _httpClient.GetFromJsonAsync<EstadoModel?>($"api/estados/sigla/{sigla}");
            return estado;
        }
        public async Task<EstadoModel?> GetByNameAsync(string nome)
        {
            var estado = await _httpClient.GetFromJsonAsync<EstadoModel?>($"api/estados/nome/{nome}");
            return estado;
        }
        public async Task<bool> EstadoExistsAsync(string sigla)
        {
            var response = await _httpClient.GetAsync($"api/estados/exists/{sigla}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }
            return false;
        }
    }
}
