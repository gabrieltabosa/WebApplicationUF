using System.Net;
using System.Text.Json;
using AutoMapper;
using WebUF.ViewModel;


namespace WebUF.Services
{
    public class EstadoApiClient : IEstadoApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public EstadoApiClient(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            System.Diagnostics.Debug.WriteLine($"HttpClient Base Address: {_httpClient.BaseAddress}");
        }

        // Deserializador genérico para TData (TData aqui será EstadoDto, List<EstadoDto>, bool, etc.)
        private async Task<ApiResponse<TData>> Deseralizador<TData>(HttpResponseMessage response)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string jsonContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Conteúdo JSON recebido: {jsonContent}");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    
                    Console.WriteLine($"lista do estado: {jsonContent}");
                    var data = JsonSerializer.Deserialize<TData>(jsonContent, options);
                    Console.WriteLine($"Desserialização bem-sucedida para {data}.");
                    return new ApiResponse<TData>(data);
                }
                catch (Exception ex)
                {
                    return new ApiResponse<TData>(
                        $"Erro de Desserialização (Sucesso HTTP): O conteúdo JSON não pôde ser convertido para {typeof(TData).Name}. Conteúdo: {jsonContent}. Detalhe: {ex.Message}"
                    );
                }
            }
            else
            {
                return new ApiResponse<TData>($"Erro ({response.StatusCode}): {jsonContent}");
            }
        }

        // ---- Métodos públicos (desserializam para DTO e depois mapeiam para ViewModel) ----

        public async Task<ApiResponse<List<EstadoViewModel>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/Estado");
            var dtoResp = await Deseralizador<List<EstadoDto>>(response);
            Console.WriteLine("Response received from API.");

            if (!dtoResp.Sucesso)
                return new ApiResponse<List<EstadoViewModel>>(dtoResp.Erro);

            var vmList = _mapper.Map<List<EstadoViewModel>>(dtoResp.Data);
            
            return new ApiResponse<List<EstadoViewModel>>(vmList);
        }

        public async Task<ApiResponse<List<EstadoViewModel>>> GetBySiglaAsync(string sigla)
        {
            var response = await _httpClient.GetAsync($"api/Estado/sigla/{WebUtility.UrlEncode(sigla)}");

            
            var dtoRespSingle = await Deseralizador<EstadoDto>(response);

            // Verifica a Falha 
            if (!dtoRespSingle.Sucesso)
            {
                // Retorna o erro
                return new ApiResponse<List<EstadoViewModel>>(dtoRespSingle.Erro);
            }

            
            var vmList = new List<EstadoViewModel>();
            if (dtoRespSingle.Data != null)
            {
                var singleVm = _mapper.Map<EstadoViewModel>(dtoRespSingle.Data);
                vmList.Add(singleVm);
            }

            Console.WriteLine($"Lista de estado criada com {vmList.Count} item(s).");
            return new ApiResponse<List<EstadoViewModel>>(vmList);
        }

        public async Task<ApiResponse<bool>> EstadoExistsAsync(string sigla)
        {
            var response = await _httpClient.GetAsync($"api/Estado/exists/{WebUtility.UrlEncode(sigla)}");
            if (!response.IsSuccessStatusCode)
            {
                return new ApiResponse<bool> { Data = false };
            }

            return await Deseralizador<bool>(response);
        }

        public async Task<ApiResponse<EstadoViewModel>> GetByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/Estado/{WebUtility.UrlEncode(id)}");
            var dtoResp = await Deseralizador<EstadoDto>(response);

            if (!dtoResp.Sucesso)
                return new ApiResponse<EstadoViewModel>(dtoResp.Erro);

            var vm = _mapper.Map<EstadoViewModel>(dtoResp.Data);
            return new ApiResponse<EstadoViewModel>(vm);
        }

        public async Task<ApiResponse<List<EstadoViewModel>>> GetRegiaoAsync(string regiao)
        {
            var response = await _httpClient.GetAsync($"api/Estado/regiao/{WebUtility.UrlEncode(regiao)}");
            var dtoResp = await Deseralizador<List<EstadoDto>>(response);

            if (!dtoResp.Sucesso)
                return new ApiResponse<List<EstadoViewModel>>(dtoResp.Erro);

            var vm = _mapper.Map<List<EstadoViewModel>>(dtoResp.Data);
            return new ApiResponse<List<EstadoViewModel>>(vm);
        }
    }
}


