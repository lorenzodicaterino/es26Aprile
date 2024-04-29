using Esercitazione26Aprile.Service;
using Microsoft.AspNetCore.Mvc;

namespace Esercitazione26Aprile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RistoranteController : Controller
    {
        private readonly RistoranteService service;
        public RistoranteController (RistoranteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult RecuperaTutti()
        {
            return Ok(service.RecuperaTutti());
        }

        [HttpGet("{codice}")]
        public IActionResult RecuperaPerCodice( string codice )
        {
            return Ok(service.RecuperaPerCodice(codice));
        }

        [HttpGet("piatti/{codice}")]
        public IActionResult RecuperaPiattiPerRistorante(string codice)
        {
            return Ok(service.RecuperaPiattiPerRistorante(codice));
        }

    }
}
