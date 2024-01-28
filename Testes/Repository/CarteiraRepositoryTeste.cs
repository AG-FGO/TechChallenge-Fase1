using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge_Fase1.Interfaces;
using TechChallenge_Fase1.Model;
using TechChallenge_Fase1.Repository;

namespace Testes.Repository
{
    public class CarteiraRepositoryTeste
    {

        private readonly ICarteiraRepository _carteiraRepository;
        public CarteiraRepositoryTeste(CarteiraRepository carteiraRepository) 
        {
            _carteiraRepository = carteiraRepository;
        }


        [Theory]
        [InlineData(1,100)]
        [InlineData(-1,200)]
        public void AdicionarValorCarteiraTeste(int id, float valor)
        {
            _carteiraRepository.AdicionarValorCarteira(id, valor);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(-1)]
        [InlineData(0)]
        public Carteira GetCarteiraByUsuarioIDTeste(int id)
        {
            return _carteiraRepository.GetCarteiraByUsuarioID(id);
        }

        [Theory]
        [InlineData(1,150)]
        [InlineData(2, 1500)]
        [InlineData(3, 9999)]
        public bool RemoverSaldoTeste(int carteiraId, float saldoRemover)
        {
            return _carteiraRepository.RemoverValorCarteira(carteiraId, saldoRemover);
        }


        [Theory]
        [InlineData(1,1, 150)]
        [InlineData(2,1, 1500)]
        [InlineData(3,3, 9999)]
        public bool ComprarAcoesTeste(int IdUsuario, int IdAcao, int quantidade)
        {
            return _carteiraRepository.ComprarAcoes(IdUsuario, IdAcao,quantidade);
        }

        [Theory]
        [InlineData(1, 1, 150)]
        [InlineData(2, 1, 1500)]
        [InlineData(3, 3, 9999)]
        public bool VenderAcoesTeste(int IdUsuario, int IdAcao, int quantidade)
        {
            return _carteiraRepository.VenderAcoes(IdUsuario, IdAcao, quantidade);
        }
    }
}
