using System.Drawing;
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

        public List<Acao> ListarAcoesDisponiveis() 
        {
            var listaAcoes = new List<Acao>();

            var petro = new Acao { Id = 1, Nome = "PETRO", Valor = 50.00f };            
            listaAcoes.Add(petro);

            var sanpr = new Acao { Id = 2, Nome = "SANPR", Valor = 45.00f };
            listaAcoes.Add(sanpr);

            var apple = new Acao { Id = 3, Nome = "APPLE", Valor = 245.00f };
            listaAcoes.Add(apple);

            var aws = new Acao { Id = 4, Nome = "AWS", Valor = 345.00f };
            listaAcoes.Add(aws);

            var microsoft = new Acao { Id = 5, Nome = "MS", Valor = 445.00f };
            listaAcoes.Add(microsoft);

            return listaAcoes;
        }


    }
}
