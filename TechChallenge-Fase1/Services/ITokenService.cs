using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Services
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
