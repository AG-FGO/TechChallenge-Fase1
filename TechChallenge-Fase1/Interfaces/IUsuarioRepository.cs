using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Interfaces
{
    public interface IUsuarioRepository : IComumRepository<Usuario>
    {
        Usuario ObterPorNomeESenha(string nome, string senha);

        Usuario ObterUsuarioDadosCompletos(int id);

        void CadastroSimples(Usuario usuario);
    }
}
