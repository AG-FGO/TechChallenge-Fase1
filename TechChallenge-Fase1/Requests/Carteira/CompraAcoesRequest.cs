namespace TechChallenge_Fase1.Requests.Carteira
{
    public class CompraAcoesRequest
    {
        public int IdUsuario { get; set; }
        public int IdAcao { get; set; }
        public int Quantidade { get; set; }
    }
}
