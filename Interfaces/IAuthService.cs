using System.Threading.Tasks;

namespace EtulasAPI.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task<string> RefreshTokenAsync(string token);
    }
}
