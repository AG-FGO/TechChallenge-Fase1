using Microsoft.AspNetCore.Mvc;
using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Requests;
using TechChallenge_Fase1.Services;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(ITokenService tokenService, IUsuarioRepository usuarioRepository)
        {
            this._tokenService = tokenService;
            this._usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var usuarioCadastrado = _usuarioRepository.ObterPorNomeESenha(request.Nome, request.Senha);

            if (usuarioCadastrado == null)
                return Unauthorized(new {mensagem = "Usuário ou senha inválidos"});

            var token = _tokenService.GenerateToken(usuarioCadastrado);

            return Ok(new { token });
        }



    }
}
