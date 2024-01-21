using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class TituloAcaoRepository
    {
        private readonly DbContext _dbContext; // DbContext é um exemplo

        public TituloAcaoRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<TituloAcao> ListarAcoesDisponiveis() 
        {
            return _dbContext.Set<TituloAcao>().ToList();
        }
    }
}
