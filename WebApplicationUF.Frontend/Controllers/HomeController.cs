using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUF.Services;
using WebUF.ViewModel;

namespace WebUF.Controllers
{
    public class HomeController : Controller
    {
        private readonly EstadoApiClient _api;

        public HomeController(EstadoApiClient api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            // Tenta buscar todos os estados
            var response = await _api.GetAllAsync();

            if (response.Sucesso && response.Data != null)
            {
                // Sucesso: Retorna a View com a lista de estados (model.Data)
                return View(response.Data);
            }

            // Falha: Armazena a mensagem de erro no TempData
            TempData["ErrorMessage"] = response.Erro ?? "Erro desconhecido ao carregar estados.";

            // Retorna a View com uma lista vazia, pois a View espera List<EstadoViewModel>
            return View(new List<EstadoViewModel>());
        }

        // Método de requisição POST do formulário da View
        [HttpPost]
        public async Task<IActionResult> ConsultaSigla(string sigla)
        {
            // Garante que o método é assíncrono e evita .Result
            var response = await _api.GetBySiglaAsync(sigla);

            if (response.Sucesso && response.Data != null)
            {
                // Sucesso: Retorna a View com a lista (de 1 ou mais estados, dependendo da API)
                return View("Index", response.Data);
            }

            // Falha: Armazena a mensagem de erro e retorna para a tela inicial
            TempData["ErrorMessage"] = response.Erro ?? $"Erro ao consultar o estado {sigla}.";

            // Redireciona para o Index (GET) para recarregar a lista completa e mostrar o erro
            // Se preferir manter na mesma página, use View("Index", new List<EstadoViewModel>())
            return RedirectToAction("Index");
        }

        // Método chamado via AJAX do JavaScript para verificar a existência da sigla
        [HttpPost]
        public async Task<IActionResult> Verificador(string sigla)
        {
            // Renomeei de Verificar para Verificador para bater com o AJAX na View
            var response = await _api.EstadoExistsAsync(sigla);

            if (response.Sucesso)
            {
                // Se o retorno da API for sucesso (200 OK), mas o payload diz false/true
                if (response.Data == true)
                {
                    // A API confirmou a existência (Sucesso: não faz nada na tela, como pedido)
                    return Ok();
                }
                else
                {
                    // A API retornou 'false' (Não encontrado), envie uma mensagem de erro customizada
                    // O JavaScript exibirá isso como erro.
                    return BadRequest($"Estado com sigla '{sigla}' não encontrado.");
                }
            }
            else
            {
                // Falha da API (ex: 404, 500, erro de desserialização)
                // Retorna o erro da API para o JavaScript (xhr.responseText)
                return BadRequest(response.Erro ?? "Erro desconhecido na verificação.");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
