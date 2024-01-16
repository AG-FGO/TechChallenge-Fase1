using Microsoft.AspNetCore.Mvc;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;

        [HttpGet]
        public ActionResult GetUsuario() {
            return null;
        }

        [HttpPost]
        public ActionResult CadastrarUsuario()
        {
            return null;
        }
    }
}
