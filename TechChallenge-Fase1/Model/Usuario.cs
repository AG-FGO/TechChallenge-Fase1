namespace TechChallenge_Fase1.Model
{
    public class Usuario : Comum
    {
        public string Nome { get; set; }
        public Carteira Carteira { get; set; }

        public Usuario() { }
    }
}
