using Microsoft.AspNetCore.Mvc;
using TechChallenge_Fase1.Model;
using TechChallenge_Fase1.Repository;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloAcaoController : ControllerBase
    {
        private readonly ILogger<TituloAcaoController> _logger;
        private readonly TituloAcaoRepository _tituloAcaoRepository;
        public TituloAcaoController( ILogger<TituloAcaoController> logger,TituloAcaoRepository tituloAcaoRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tituloAcaoRepository = tituloAcaoRepository ?? throw new ArgumentNullException(nameof(tituloAcaoRepository));
        }

        [HttpGet]
        public IActionResult ListarAcoesDisponiveis()
        {
            //List<TituloAcao> acoes = _tituloAcaoRepository.ListarAcoesDisponiveis();

            return Ok();
        }

    }
}
