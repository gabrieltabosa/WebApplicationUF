using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationUF.Frontend.Services;
using WebApplicationUF.Frontend.ViewModel;
using System.Collections.Generic; // Para List

namespace WebApplicationUF.Frontend.Controllers
{
    // A Controller agora usa o ApiClient e o ViewModel.
    public class EstadoController : Controller
    {
        private readonly EstadoApiClient _apiClient;

        // Construtor com Injeção de Dependência
        public EstadoController(EstadoApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        // Rota Convencional: /Estado/Index
        public async Task<IActionResult> Index()
        {
            List<EstadoViewModel> estados;

            try
            {
                // Corrigido: GetAllAsync retorna EstadoViewModel, não List<EstadoViewModel>
                var resultado = await _apiClient.GetAllAsync();
                estados = resultado?.ListaEstados ?? new List<EstadoViewModel>();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro ao carregar estados da API: {ex.Message}");
                ViewBag.ErroApi = "Não foi possível carregar os dados. A API do Core pode estar offline.";
                estados = new List<EstadoViewModel>();
            }

            var pageViewModel = new EstadoViewModel
            {
                ListaEstados = estados
            };

            return View(pageViewModel);
        }

        // Rota Convencional: /Estado/Detalhes/{sigla}
        public async Task<IActionResult> Detalhes(string sigla)
        {
            try
            {
                var estado = await _apiClient.GetBySiglaAsync(sigla);

                if (estado == null)
                {
                    return NotFound();
                }
                return View(estado);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro ao buscar estado por sigla: {ex.Message}");
                ViewBag.ErroApi = "Falha na comunicação ao buscar o estado.";
                return View("Error"); // Retorna uma view de erro
            }
        }

        // 3. Verificação de Existência (Melhoria de Roteamento)
        // Rota: /Estado/VerificarExistencia/{sigla}
        [HttpGet("Estado/VerificarExistencia/{sigla}")]
        public async Task<IActionResult> VerificarExistencia(string sigla)
        {
            try
            {
                bool existe = await _apiClient.EstadoExistsAsync(sigla);
                return Json(new { existe = existe, sigla = sigla });
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro durante a verificação de existência: {ex.Message}");
                // Retornar um status de erro claro para o AJAX no frontend
                return StatusCode(500, new { erro = "Falha na comunicação com o serviço." });
            }
        }

        // 4. Recebimento de Dados (POST /Estado/Cadastrar)
        [HttpPost]
        public IActionResult Cadastrar(EstadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Lógica de cadastro...
            return RedirectToAction("Index");
        }
    }
}
