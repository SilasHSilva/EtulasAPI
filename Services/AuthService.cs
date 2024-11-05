using EtulasAPI.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EtulasAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/login", new { username, password });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> RefreshTokenAsync(string token)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/refresh", new { token });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}