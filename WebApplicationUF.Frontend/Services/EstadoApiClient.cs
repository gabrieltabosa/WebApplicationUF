using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using WebUF.ViewModel;

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
        public async Task<List<EstadoViewModel?>> Deseralizador(HttpResponseMessage response)
        {
            //verifica se retorno uma operaçõa bem sucedidade( 200 a 299)
            if (response.IsSuccessStatusCode)
            {
                // extrai o conteudo JSON puro para uma string de forma assincrona, armazenando num buffer 
                string jsonContent = await response.Content.ReadAsStringAsync();

                // isso permite ignorar diferenças como maiusculo ou minusculo, Exemplo:
                // Nome: nome = NOME:nome
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                // O método Deserialize<T>() retorna o objeto desserializado
                return JsonSerializer.Deserialize<List<EstadoViewModel>>(jsonContent, options);
            }
            else
            {
                // Tratamento de erro aprimorado
                string errorDetail = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao chamar API. Status: {response.StatusCode}. Detalhe: {errorDetail}");
            }
        }
        public async Task<List<EstadoViewModel?>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/Estado");
            return await Deseralizador(response);
        }
        public async Task<List<EstadoViewModel?>> GetBySiglaAsync(string sigla)
        {
            var retorno = (await GetAllAsync());

            if (!string.IsNullOrEmpty(sigla))
                return retorno.Where(a => a.Sigla?.ToLower() == sigla?.ToLower()).ToList();
            else
                return retorno?.ToList();
        }
        public async Task<bool> EstadoExistsAsync(string sigla)
        {
            var response = await _httpClient.GetAsync($"api/Estado/exists/{WebUtility.UrlEncode(sigla)}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }
            else
            {
                throw new Exception($"Erro ao chamar API: {response.StatusCode}");
            }
        }
    }
}

