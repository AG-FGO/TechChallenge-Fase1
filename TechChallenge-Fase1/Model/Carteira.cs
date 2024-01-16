namespace TechChallenge_Fase1.Model
{
    public class Carteira
    {
        public int Id { get; set; }
        public float Saldo { get; set; }

        public List<TituloAcao> Acoes { get; set; }

        public Carteira() { }
    }
}
