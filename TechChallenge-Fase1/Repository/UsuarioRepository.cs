using Microsoft.EntityFrameworkCore;
using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class UsuarioRepository : ComumRepository<Usuario>, IUsuarioRepository
    {
        protected ApplicationDbContext _dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void CadastroSimples(Usuario usuario)
        {
            usuario.Permissao = Enums.TipoPermissao.UsuarioComum;
            usuario.Carteira = new Carteira();
            usuario.Carteira.Saldo = 1000;

            _dbContext.Usuario.Add(usuario);
            _dbContext.SaveChanges();
        }

        public Usuario ObterPorNomeESenha(string nome, string senha)
        {
            return _dbContext.Usuario
                .Where(u => u.Nome == nome && u.Senha == senha)
                .FirstOrDefault();
        }
    }
}
