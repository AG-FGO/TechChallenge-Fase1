using Microsoft.EntityFrameworkCore;
using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Model;
using System.Linq;

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

        public Usuario ObterUsuarioDadosCompletos(int id)
        {
            return _dbContext.Usuario
                .Include(u => u.Carteira)
                .ThenInclude(a => a.Acoes)
                .ThenInclude(q => q.Acao)
                .Where(u => u.Id == id)
                .ToList()
                .Select(usuario =>
                {
                    if(usuario.Carteira != null)
                        usuario.Carteira = new Carteira
                        {
                            Id = usuario.Carteira.Id,
                            Saldo = usuario.Carteira.Saldo,
                            UsuarioId = usuario.Carteira.UsuarioId,
                            Acoes = usuario.Carteira.Acoes?.Select(a => new Ativos
                            {
                                Id = a.Quantidade,
                                DataCompra = a.DataCompra,
                                Quantidade = a.Quantidade,
                                IdCarteira = a.IdCarteira,
                                Acao = new Acao
                                {
                                    Id = a.Acao.Id,
                                    Nome = a.Acao.Nome,
                                    Valor = a.Acao.Valor
                                }
                            }).ToList()
                        };

                    return usuario;
                })
                .FirstOrDefault();
        }
    }
}
