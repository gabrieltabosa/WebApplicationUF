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

            

            // Retorna a View com uma lista vazia, pois a View espera List<EstadoViewModel>
            return View(response);
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
                return View("index", response.Data);
            }

            // Falha: Armazena a mensagem de erro e retorna para a tela inicial


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
            Console.WriteLine(response.Data);
            if (response.Sucesso)
            {
                if (response.Data == true)
                {
                    return Ok(); // Opcional, pode retornar algo útil
                }
                else
                {
                    // Retorna mensagem diretamente
                    return BadRequest("Estado não encontrado.");
                }
            }
            else
            {
                return BadRequest($"Erro: {response.Erro}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> buscarRegiao(string regiao)
        {
            var response = await _api.GetRegiaoAsync(regiao);
            
            // Sucesso: Retorna a View com a lista (de 1 ou mais estados, dependendo da API)
            return View("index", response.Data);
            
            
        }
        [HttpPost]
        public async Task<IActionResult> GetById(string id)
        {
            Console.WriteLine("ID recebido: " + id);
            var response = await _api.GetByIdAsync(id);
            Console.WriteLine(response.Data);
            return PartialView("_ModalDescricao", response.Data);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
