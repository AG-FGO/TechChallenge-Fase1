using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class TituloAcaoRepository
    {
        private readonly ApplicationDbContext _dbContext; // DbContext é um exemplo

        public TituloAcaoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /*public List<TituloAcao> ListarAcoesDisponiveis() 
        {
            return _dbContext.Set<TituloAcao>().ToList();
        }*/
    }
}
