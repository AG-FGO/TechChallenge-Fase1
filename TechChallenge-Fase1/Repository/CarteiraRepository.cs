using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class CarteiraRepository
    {
        private readonly ApplicationDbContext _dbContext; // DbContext é um exemplo

        public CarteiraRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public Carteira GetCarteiraByUsuarioID(int id) 
        {
            //get carteira database
            return new Carteira { Id = id };
        }
    }
}
