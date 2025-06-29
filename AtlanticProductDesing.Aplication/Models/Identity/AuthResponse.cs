
namespace AtlanticProductDesing.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public AuthUser? User { get; set; }
    }
}
