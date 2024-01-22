using Microsoft.AspNetCore.Mvc;
using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Repository;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public ActionResult GetUsuario(int id) {
            var usuario = _usuarioRepository.ObterPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult CadastrarUsuario()
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            _usuarioRepository.Excluir(id);
            return Ok("Usuario deletado com sucesso");
        }
    }
}
