using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallenge_Fase1.Enums;
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
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        [Authorize]
        [Authorize(Roles = $"{Permissao.Administrador}, {Permissao.UsuarioComum}")]
        [HttpGet]
        public ActionResult GetUsuario(int id) 
        {
            try
            {
                var usuario = _usuarioRepository.ObterPorId(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception: {ex.Message}");
                return BadRequest();
            }
            
        }

        [Authorize]
        [Authorize(Roles = Permissao.Administrador)]
        [HttpPost]
        public ActionResult CadastrarUsuario()
        {
            _logger.LogWarning("Cadastrando usuario");
            return Ok("Usuario cadastrado com sucesso");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            _usuarioRepository.Excluir(id);
            return Ok("Usuario deletado com sucesso");
        }
    }
}
