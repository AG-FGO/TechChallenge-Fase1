using Microsoft.AspNetCore.Mvc;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloAcaoController : ControllerBase
    {

        private readonly ILogger<TituloAcaoController> _logger;

        [HttpGet]
        public IActionResult ListarAcoesDisponiveis()
        {
            return null;
        }

    }
}
