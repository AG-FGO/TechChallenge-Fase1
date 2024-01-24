namespace TechChallenge_Fase1.Model
{
    public class Ativos
    {
        public int Id { get; set; }
        public int IdCarteira { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        public Acao Acao { get; set; }
    }
}
