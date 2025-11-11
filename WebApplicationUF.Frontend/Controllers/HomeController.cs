using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationUF.Frontend.Services;
using WebApplicationUF.Frontend.ViewModel;

namespace WebApplicationUF.Controllers
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
            Console.WriteLine("HomeController.Index -> total estados: " + (model?.ListaEstados?.Count ?? 0));
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
