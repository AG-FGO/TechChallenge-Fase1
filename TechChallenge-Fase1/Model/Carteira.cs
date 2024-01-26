namespace TechChallenge_Fase1.Model
{
    public class Carteira : Comum
    {
        public int UsuarioId { get; set; }
        public float Saldo { get; set; }
        public List<Ativos>? Acoes { get; set; }

        public Usuario Usuario { get; set; }

        public Carteira() { }
    }
}
