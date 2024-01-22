using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Interfaces
{
    public interface IComumRepository<T> where T : Comum
    {
        IList<T> ObterTodos();
        T ObterPorId(int id);
        void Cadastrar(T comum);
        void Alterar(T comum);
        void Excluir(int id);
    }
}
