using Microsoft.AspNetCore.Mvc;
using TechChallenge_Fase1.Repository;

namespace TechChallenge_Fase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraController : ControllerBase
    {

        private readonly ILogger<CarteiraController> _logger;
        private readonly CarteiraRepository _carteiraRepository;
        public CarteiraController(ILogger<CarteiraController> logger, CarteiraRepository carteiraRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _carteiraRepository = carteiraRepository ?? throw new ArgumentNullException(nameof(carteiraRepository));
        }
        [HttpGet]
        public IActionResult GetCarteiraByUsuarioId(int id)
        {
            var carteira = _carteiraRepository.GetCarteiraByUsuarioID(id);
            return Ok(carteira);
        }
    }
}
