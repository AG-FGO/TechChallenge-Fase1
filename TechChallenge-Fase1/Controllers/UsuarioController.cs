using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallenge_Fase1.Enums;
using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Model;
using TechChallenge_Fase1.Repository;
using TechChallenge_Fase1.Requests.Usuario;

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
        [Authorize(Roles = $"{Permissao.Administrador}")]
        [HttpGet]
        [Route(nameof(ObterUsuario))]
        public ActionResult ObterUsuario(int id) 
        {
            try
            {
                _logger.LogInformation($"Buscado usuário por id: {id}");

                var usuario = _usuarioRepository.ObterPorId(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception: {ex.Message}");
                return BadRequest("Houve um erro durante a busca");
            }
        }

        [HttpPost]
        [Route(nameof(CadastrarUsuario))]
        public ActionResult CadastrarUsuario([FromBody] UsuarioCadastroRequest usuarioRequest)
        {
            try
            {
                _logger.LogInformation($"Cadastrando usuário {usuarioRequest.Nome}");

                _usuarioRepository.CadastroSimples(new Usuario
                {
                    Nome = usuarioRequest.Nome,
                    Senha = usuarioRequest.Senha
                });

                return Ok("Usuario cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception: {ex.Message}");
                return BadRequest("Houve um erro durante o cadastro");
            }
        }

        [Authorize]
        [Authorize(Roles = $"{Permissao.Administrador}")]
        [HttpDelete("{id}")]
        [Route(nameof(DeletarUsuario))]
        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            try
            {
                _logger.LogInformation($"Deletando usuário de id: {id}");
                _usuarioRepository.Excluir(id);
                return Ok("Usuario deletado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception: {ex.Message}");
                return BadRequest("Houve um erro durante a exclusão");
            }
        }
    }
}
