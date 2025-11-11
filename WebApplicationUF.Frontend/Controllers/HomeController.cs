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
            var model = await _api.GetAllAsync();
            Console.WriteLine("HomeController.Index -> total estados: " + (model?.Count ?? 0));
            return View(model);
        }

        [HttpPost]
        public IActionResult ConsultaSigla(string sigla)
        {
            var model = _api.GetBySiglaAsync(sigla).Result;
            return View("Index" , model);
        }

        public IActionResult Verificcar(string sigla) {
            var model = _api.EstadoExistsAsync(sigla).Result;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
