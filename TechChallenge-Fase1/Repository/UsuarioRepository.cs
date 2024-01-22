using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class UsuarioRepository : ComumRepository<Usuario>, IUsuarioRepository
    {
        
        public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
