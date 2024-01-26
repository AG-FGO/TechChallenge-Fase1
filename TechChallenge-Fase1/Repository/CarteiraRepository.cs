using Microsoft.EntityFrameworkCore;
using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class CarteiraRepository : ComumRepository<Carteira>, ICarteiraRepository
    {
        protected ApplicationDbContext _dbContext;

        public CarteiraRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AdicionarValorCarteira(int id, float valor)
        {
            var existeCarteira = _dbContext.Carteira.Where(c => c.UsuarioId == id).Any();

            if (!existeCarteira)
            {
                var carteira = new Carteira();
                carteira.UsuarioId = id;
                carteira.Saldo = valor;
                _dbContext.Carteira.Add(carteira);
                _dbContext.SaveChanges();
                return;
            }
            else
            {
                var carteira = _dbContext.Carteira.Where(c => c.UsuarioId == id).FirstOrDefault();
                carteira.Saldo += valor;
                _dbContext.SaveChanges();
            }
        }

        public Carteira GetCarteiraByUsuarioID(int id) 
        {
            return _dbContext.Carteira.Where(c => c.UsuarioId == id).FirstOrDefault();
        }
    }
}
