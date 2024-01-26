using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallenge_Fase1.Enums;
using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Repository;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraController : ControllerBase
    {

        private readonly ILogger<CarteiraController> _logger;
        private readonly ICarteiraRepository _carteiraRepository;

        public CarteiraController(ILogger<CarteiraController> logger, ICarteiraRepository carteiraRepository)
        {
            _logger = logger;
            _carteiraRepository = carteiraRepository;
        }

        [Authorize]
        [Authorize(Roles = $"{Permissao.Administrador}, {Permissao.UsuarioComum}")]
        [HttpGet]
        public IActionResult GetCarteiraByUsuarioId(int id)
        {
            try
            {
                _logger.LogInformation($"Buscado carteira pelo id do usuário: {id}");
                var carteira = _carteiraRepository.GetCarteiraByUsuarioID(id);
                return Ok(carteira);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception: {ex.Message}");
                return BadRequest("Houve um erro durante a busca");
            }
        }

        [Authorize]
        [Authorize(Roles = $"{Permissao.Administrador}, {Permissao.UsuarioComum}")]
        [HttpPost]
        [Route(nameof(AdicionarValorCarteira))]
        public IActionResult AdicionarValorCarteira(int id, float valor)
        {
            try
            {
                _logger.LogInformation($"Adicionando valor {valor} na carteira do usuário {id}");
                _carteiraRepository.AdicionarValorCarteira(id, valor);
                return Ok("Valor adicionado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception: {ex.Message}");
                return BadRequest("Houve um erro durante a adição de valor");
            }
        }
    }
}
