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
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioRepositoryTeste(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [Theory]
        [InlineData("teste","teste")]
        [InlineData("teste231","teste321")]
        [InlineData("a","a")]
        public Usuario ObterPorNomeESenhaTeste(string nome, string senha) 
        {
            return _usuarioRepository.ObterPorNomeESenha(nome, senha);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public Usuario ObterUsuarioDadosCompletosTeste(int id)
        {
            return _usuarioRepository.ObterUsuarioDadosCompletos(id);
        }
    }
}
