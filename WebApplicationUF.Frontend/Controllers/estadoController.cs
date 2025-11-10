using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationUF.Core;
using WebApplicationUF.Frontend.Services;

namespace WebApplicationUF.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly EstadoApiClient _apiClient;
        public HomeController(EstadoApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            var estados = _apiClient.GetAllAsync().Result;
            return View(estados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
