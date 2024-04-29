using Esercitazione26Aprile.DTO;
using Esercitazione26Aprile.Service;
using Microsoft.AspNetCore.Mvc;

namespace Esercitazione26Aprile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtenteController : Controller
    {
        private readonly UtenteService service;

        public UtenteController (UtenteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult RecuperaTutti() 
        {
            return Ok(service.RecuperaTutti());
        }

        [HttpGet("{codice}")]
        public IActionResult RecuperaPerCodice( string codice)
        {
            return Ok(service.RecuperaPerCodice(codice));
        }

        [HttpPost]
        public IActionResult Inserisci(UtenteDTO dto)
        {
            return Ok(service.Inserisci(dto));
        }

        [HttpPut]
        public IActionResult Modifica(UtenteDTO dto)
        {
            return Ok(service.Modifica(dto));
        }

        [HttpDelete("{codice}")]
        public IActionResult Elimina(string codice)
        {
            return Ok(service.Elimina(codice));
        }
    }
}
