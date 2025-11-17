using System.Net;
using System.Text.Json;
using WebUF.ViewModel;


using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;


namespace WebUF.Services
{
    public class EstadoApiClient
    {
        private readonly HttpClient _httpClient;

        public EstadoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            System.Diagnostics.Debug.WriteLine($"HttpClient Base Address: {_httpClient.BaseAddress}");
        }

        // --------------------------------------------------------------------------
        // NOVO: Deserializador Genérico
        // Esta função encapsula a lógica de sucesso, erro e desserialização
        // para qualquer tipo de dado (TData) retornado pela API.
        // --------------------------------------------------------------------------
        private async Task<ApiResponse<TData>> Deseralizador<TData>(HttpResponseMessage response)
        {
            // 1. Configuração do Serializador
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string jsonContent = await response.Content.ReadAsStringAsync();

            // 2. Verifica se a operação foi bem-sucedida (Status Code 200-299)
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    if (typeof(TData) == typeof(List<EstadoViewModel>) && !jsonContent.StartsWith("["))
                        jsonContent = "[" + jsonContent + "]";
                    // Tenta desserializar o conteúdo diretamente para o tipo TData.
                    // A lógica de forçar a lista/objeto singular (que estava no código original)
                    // foi simplificada. Se a API retornar uma lista, TData deve ser List<EstadoViewModel>.
                    // Se a API retornar um bool, TData deve ser bool.
                    var data = JsonSerializer.Deserialize<TData>(jsonContent, options);
                    Console.WriteLine($"Conteúdo JSON desserializado: {jsonContent}");

                    // Retorna um ApiResponse de sucesso
                    return new ApiResponse<TData>(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na desserialização: {ex.Message}");
                    // Erro na desserialização do JSON (o JSON recebido não bate com TData)
                    return new ApiResponse<TData>(
                        $"Erro de Desserialização (Sucesso HTTP): O conteúdo JSON não pôde ser convertido para {typeof(TData).Name}. Conteúdo: {jsonContent}. Detalhe: {ex.Message}"
                    );
                }
            }
            else // Status Code de Erro (4xx ou 5xx)
            {
                // Retorna um ApiResponse de erro
                return new ApiResponse<TData>(
                    $"Erro ({response.StatusCode}): {jsonContent}"
                );
            }
        }

    
        public async Task<ApiResponse<List<EstadoViewModel>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/Estado");
            return await Deseralizador<List<EstadoViewModel>>(response);
        }

    
        public async Task<ApiResponse<List<EstadoViewModel>>> GetBySiglaAsync(string sigla)
        {
            var retorno = await _httpClient.GetAsync($"api/Estado/sigla/{WebUtility.UrlEncode(sigla)}");
            return await Deseralizador<List<EstadoViewModel>>(retorno);
        }


        public async Task<ApiResponse<bool>> EstadoExistsAsync(string sigla)
        {
            var response = await _httpClient.GetAsync($"api/Estado/exists/{WebUtility.UrlEncode(sigla)}");

            if (!response.IsSuccessStatusCode)
            {
                return new ApiResponse<bool>
                {
                    Data = false
                };
            }

            return await Deseralizador<bool>(response);
        }
    }
}

