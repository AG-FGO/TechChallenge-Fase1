using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallenge_Fase1.Enums;
using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Model;
using TechChallenge_Fase1.Repository;
using TechChallenge_Fase1.Requests.Acao;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloAcaoController : ControllerBase
    {
        private readonly ILogger<TituloAcaoController> _logger;
        private readonly IAcaoRepository _acaoRepository;

        public TituloAcaoController(ILogger<TituloAcaoController> logger, IAcaoRepository acaoRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _acaoRepository = acaoRepository;
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = $"{Permissao.Administrador}, {Permissao.UsuarioComum}")]
        [Route(nameof(ListarAcoesDisponiveis))]
        public IActionResult ListarAcoesDisponiveis()
        {
            try
            {
                _logger.LogInformation($"Listando todas as Ações");
                return Ok(_acaoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception: {ex.Message}");
                return BadRequest("Houve um erro durante a busca");
            }
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = $"{Permissao.Administrador}")]
        [Route(nameof(CadastrarAcao))]
        public IActionResult CadastrarAcao([FromBody] AcaoRequest acaoRequest)
        {
            try
            {
                _logger.LogInformation($"Cadastrando Ação {acaoRequest.Nome} com valor:{acaoRequest.Valor}");
                _acaoRepository.Cadastrar(new Acao() { Nome = acaoRequest.Nome, Valor = acaoRequest.Valor });
                return Ok("Ação cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception: {ex.Message}");
                return BadRequest("Houve um erro durante o cadastro");
            }
        }
    }
}
