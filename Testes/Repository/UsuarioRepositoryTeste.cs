using Microsoft.Extensions.Logging;
using Moq;
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
    public class UsuarioRepositoryTeste
    {

        [Theory]
        [InlineData("teste","teste")]
        [InlineData("teste231","teste321")]
        [InlineData("a","a")]
        public void ObterPorNomeESenhaTeste(string nome, string senha) 
        {
            var teste = new Mock<IUsuarioRepository>().Setup(service => service.ObterPorNomeESenha(nome, senha));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ObterUsuarioDadosCompletosTeste(int id)
        {
            var teste = new Mock<IUsuarioRepository>().Setup(service => service.ObterUsuarioDadosCompletos(id));
        }
    }
}
