using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class AcaoRepository : ComumRepository<Acao>, IAcaoRepository
    {
        protected ApplicationDbContext _dbContext;

        public AcaoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
