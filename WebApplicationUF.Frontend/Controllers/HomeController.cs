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

            
            
            // Sucesso: Retorna a View com a lista (de 1 ou mais estados, dependendo da API)
            return PartialView("_TabelaEstados", response.Data);
            

            


            
        }

        // Método chamado via AJAX do JavaScript para verificar a existência da sigla
        [HttpPost]
        public async Task<IActionResult> Verificador(string sigla)
        {
            // Renomeei de Verificar para Verificador para bater com o AJAX na View
            
            var response = await _api.EstadoExistsAsync(sigla);
            Console.WriteLine($"Verificador chamado para sigla: {response}");

            if (response.Sucesso)
            {
                // Se o retorno da API for sucesso (200 OK), mas o payload diz false/true
                Console.WriteLine($"Verificador resultado: {response.Data}");
                Console.WriteLine($"Verificador erro: {response.Erro}");
                if (response.Data == true)
                    return Ok();
                else
                    return BadRequest(response.Data);
            }
            else
                Console.WriteLine($"Verificador erro: {response.Erro}");
            return BadRequest(response.Data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
