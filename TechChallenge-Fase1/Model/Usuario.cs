namespace TechChallenge_Fase1.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Carteira Carteira { get; set; }

        public Usuario() { }
    }
}
