using System.Net.Http.Json;
using WebApplicationUF.Frontend.ViewModel;
using System.Net;

namespace WebApplicationUF.Frontend.Services
{
    public class EstadoApiClient
    {
        private readonly HttpClient _httpClient;

        public EstadoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // configure BaseAddress em Program.cs
        }

        // Retorna o ViewModel que a View espera
        public async Task<EstadoViewModel> GetAllAsync()
        {
            var model = new EstadoViewModel();

            Console.WriteLine("BaseAddress: " + (_httpClient.BaseAddress?.ToString() ?? "(null)"));

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync("api/Estado"); // corresponde ao Swagger
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao chamar API de estados: " + ex);
                return model;
            }

            Console.WriteLine("Status: " + response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API devolveu {response.StatusCode}. Body: {body}");
                return model;
            }

            var dtos = await response.Content.ReadFromJsonAsync<List<EstadoApiDto>>();
            if (dtos == null || dtos.Count == 0) return model;

            model.ListaEstados = dtos.Select(d => new EstadoViewModel
            {
                Id = d.Id,
                Sigla = d.Sigla,
                Nome = d.Nome,
                Descricao = d.Descricao
            }).ToList();

            return model;
        }


        public async Task<EstadoViewModel?> GetBySiglaAsync(string sigla)
        {
            if (string.IsNullOrWhiteSpace(sigla)) return null;

            var esc = Uri.EscapeDataString(sigla.Trim().ToUpperInvariant());
            var response = await _httpClient.GetAsync($"api/estado/sigla/{esc}");

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound) return null;
                return null;
            }

            var dto = await response.Content.ReadFromJsonAsync<EstadoApiDto>();
            if (dto == null) return null;

            return new EstadoViewModel
            {
                Id = dto.Id,
                Sigla = dto.Sigla,
                Nome = dto.Nome,
                Descricao = dto.Descricao
            };
        }

        public async Task<bool> EstadoExistsAsync(string sigla)
        {
            if (string.IsNullOrWhiteSpace(sigla)) return false;
            var esc = Uri.EscapeDataString(sigla.Trim().ToUpperInvariant());

            // Log BaseAddress para debug
            Console.WriteLine("HttpClient.BaseAddress = " + (_httpClient.BaseAddress?.ToString() ?? "(null)"));

            // Constrói a URI completa de forma defensiva (apenas para LOG; não assume correção automática)
            var triedUri = (_httpClient.BaseAddress == null)
                ? $"api/estado/exists/{esc}"
                : new Uri(_httpClient.BaseAddress, $"api/estado/exists/{esc}").ToString();
            Console.WriteLine("Tentativa de URL (resolvida): " + triedUri);

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync($"api/estado/exists/{esc}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("HttpClient Exception: " + ex);
                throw; // para não mascarar — durante debug é útil propagar; depois você pode tratar/logar
            }

            Console.WriteLine("StatusCode: " + response.StatusCode);

            if (!response.IsSuccessStatusCode)
            {
                string body = string.Empty;
                try { body = await response.Content.ReadAsStringAsync(); } catch { /* ignore */ }
                Console.WriteLine($"Resposta não-Sucesso. Status: {response.StatusCode}. Body: {body}");
                return false;
            }

            try
            {
                var existe = await response.Content.ReadFromJsonAsync<bool?>();
                return existe ?? false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desserializar resposta: " + ex);
                throw;
            }
        }
    }
}

