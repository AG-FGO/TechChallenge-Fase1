using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class UsuarioRepository
    {
        private readonly DbContext _dbContext; // DbContext é um exemplo

        public UsuarioRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public Usuario GetUsuario(int id) 
        {
            return _dbContext.Set<Carteira>().FirstOrDefault(c => c.UsuarioId == id);
        }

        public void CadastrarUsuario(Usuario usuario) 
        {
            // Cadastro no database
        }

        public void DeletarUsuario(int id) 
        {
            var usuario = GetUsuario(id);
            _dbContext.Set<Usuario>().Remove(usuario);
            _dbContext.SaveChanges();
        }
    }
}
