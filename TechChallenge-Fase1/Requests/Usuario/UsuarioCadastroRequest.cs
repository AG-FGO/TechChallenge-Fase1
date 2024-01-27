using System.ComponentModel.DataAnnotations;

namespace TechChallenge_Fase1.Requests.Usuario
{
    public class UsuarioCadastroRequest
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
