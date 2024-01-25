using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class CarteiraRepository
    {
        private readonly ApplicationDbContext _dbContext; // DbContext é um exemplo

        public CarteiraRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public Carteira GetCarteiraByUsuarioID(int id) 
        {
            //get carteira database
            return new Carteira { Id = id };
        }


        public float RecuperarSaldo(Carteira carteira) 
        {
            return carteira.Saldo;
        }

        public void AtribuirSaldo(Carteira carteira, float saldoAtribuir) 
        {
            carteira.Saldo = saldoAtribuir;
        }

        public void AdicinarSaldo(Carteira carteira, float saldoAdicionar)
        {
            carteira.Saldo += saldoAdicionar;
        }

        public void RemoverSaldo(Carteira carteira, float saldoRemover)
        {
            carteira.Saldo -= saldoRemover;
        }

        public bool VenderAcoes(Carteira carteira, Acao acao, int quantidade) 
        {
            try
            {
                //Regra: Verificar se a carteira possui a Ação especificada e quantidade maior ou igual a que está sendo vendida.
                if (carteira.Acoes.Count(item => item.Acao == acao && item.Quantidade >= quantidade) > 0)
                {
                    var acoesDaCarteira = carteira.Acoes;
                    var acaoVendida = acoesDaCarteira.First(item => item.Acao == acao);
                    var valorVendido = acaoVendida.Acao.Valor * quantidade;

                    var indiceAcaoVendida = acoesDaCarteira.IndexOf(acaoVendida);
                    if (acaoVendida.Quantidade == quantidade)
                    {
                        acoesDaCarteira.RemoveAt(indiceAcaoVendida);
                    }
                    else
                    {
                        acoesDaCarteira[indiceAcaoVendida].Quantidade -= quantidade;
                    }

                    carteira.Acoes = acoesDaCarteira; /* retira da carteira as ações vendidas. */
                    carteira.Saldo += valorVendido; /* adiciona o valorVendido no saldo da carteira. */

                    return true;
                }
                else
                {
                    // A carteira não possui a ação ou não possui a quantidade que está sendo vendida.
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ComprarAcoes(Carteira carteira, Acao acao, int quantidade) 
        {
            try
            {
                var valorComprado = acao.Valor * quantidade;

                //Regra: Possui Saldo para comprar as acões.
                if (carteira.Saldo >= valorComprado)
                {
                    var acoesDaCarteira = carteira.Acoes;
                    var novoId = new Random().Next();

                    var acaoComprada = new Ativos
                    {
                        Id = novoId,
                        IdCarteira = carteira.Id,
                        Quantidade = quantidade,
                        Acao = acao,
                        DataCompra = DateTime.Now
                    };

                    acoesDaCarteira.Add(acaoComprada);

                    carteira.Acoes = acoesDaCarteira; /* add na carteira as ações compradas. */
                    carteira.Saldo -= valorComprado; /* remove o valorComprado do saldo da carteira. */

                    return true;
                }
                else 
                {
                    /* a Carteria não possui Saldo para comprar as ações. */
                    return false;
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
