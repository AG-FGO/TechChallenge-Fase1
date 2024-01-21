using Microsoft.AspNetCore.Mvc;
using TechChallenge_Fase1.Repository;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioController(ILogger<UsuarioController> logger, UsuarioRepository usuarioRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        [HttpGet]
        public ActionResult GetUsuario(int id) {
            var usuario = _usuarioRepository.GetUsuario(id);
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult CadastrarUsuario()
        {
            return null;
        }
    }
}
