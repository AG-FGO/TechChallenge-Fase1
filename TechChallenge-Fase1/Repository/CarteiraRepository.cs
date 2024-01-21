using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class CarteiraRepository
    {
        private readonly DbContext _dbContext; // DbContext é um exemplo

        public CarteiraRepository(DbContext dbContext)
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
