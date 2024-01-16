using Microsoft.AspNetCore.Mvc;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraController : ControllerBase
    {

        private readonly ILogger<TituloAcaoController> _logger;
        [HttpGet]
        public IActionResult GetCarteiraByUsuarioId(int id)
        {
            return null;
        }
    }
}
