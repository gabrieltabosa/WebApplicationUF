using Microsoft.AspNetCore.Mvc;
using WebAppUF.Application;
using System.Diagnostics;
using System.Linq; // Adicionei esta diretiva para permitir o uso de métodos de extensão como Any()

namespace WebApiUF.Controllers
{
    // Indica ao ASP.NET Core que esta classe é um controller de API.
    // Isso ativa comportamentos úteis como validação automática de modelos.
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {

        // Serviço injetado para acessar dados de estados
        private readonly IEstadoService _service;

        // Construtor com injeção de dependência
        public EstadoController(IEstadoService service)
        {
            _service = service;
        }

        // GET api/estados
        // Retorna a lista completa de estados (200 OK + JSON)
        [HttpGet]
        public IActionResult GetAll()
        {
            var estados = _service.GetAll();
            return Ok(estados);
        }

        // GET api/estado/exists/{sigla}
        [HttpGet("exists/{sigla}")]
        public IActionResult EstadoExists(string sigla)
        {
            Console.WriteLine($"chamda da sigla para analise {sigla}");

            if (sigla == null || sigla.Length != 2)
            {
                return BadRequest("A sigla deve conter exatamente 2 caracteres.");
            }
            bool existe = _service.EstadoExists(sigla);

            return Ok(existe);
        }

        // GET api/estado/sigla/{sigla}
        [HttpGet("sigla/{sigla}")]
        public IActionResult GetBySigla(string sigla)
        {
            if (sigla == null || sigla.Length != 2)
            {
                return BadRequest("A sigla deve conter exatamente 2 caracteres.");
            }
            var estado = _service.GetBySigla(sigla);
            if (estado == null)
            {
                return NotFound();
            }
            
            return Ok(estado);
        }
        [HttpGet("regiao/{regiao}")]
        public IActionResult GetByRegiao(string regiao)
        {
            if (string.IsNullOrWhiteSpace(regiao))
            {
                return BadRequest("A região não pode ser nula ou vazia.");
            }
            var estados = _service.GetByRegiao(regiao);
            // Corrigido: verifica se 'estados' é uma coleção antes de usar Any()
            if (estados == null)
            {
                return NotFound();
            }
            return Ok(estados);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id) 
        {
            if (id <= 0) 
            {
                return BadRequest("O ID deve ser um número inteiro positivo.");
            }

            var estado = _service.GetById(id);
            return Ok(estado);
        }
    }
}
