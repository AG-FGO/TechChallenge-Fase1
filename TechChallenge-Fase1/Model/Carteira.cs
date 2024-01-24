namespace TechChallenge_Fase1.Model
{
    public class Carteira
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public float Saldo { get; set; }
        public List<Ativos> Acoes { get; set; }

        public Carteira() { }
    }
}
