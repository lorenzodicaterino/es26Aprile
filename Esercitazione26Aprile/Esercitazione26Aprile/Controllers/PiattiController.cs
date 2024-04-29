using Esercitazione26Aprile.Service;
using Microsoft.AspNetCore.Mvc;

namespace Esercitazione26Aprile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PiattiController : Controller
    {
        private readonly PiattoService service;
        public PiattiController(PiattoService service)
        {
                this.service = service;
        }

        [HttpGet]
        public IActionResult RecuperaTutti()
        {
            return Ok(service.RecuperaTutti());
        }

        [HttpGet("{codice}")]
        public IActionResult RecuperaPerCodice(string codice)
        {
            return Ok(service.RecuperaPerCodice(codice));
        }
    }
}
