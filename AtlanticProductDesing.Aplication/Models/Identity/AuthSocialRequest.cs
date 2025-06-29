namespace AtlanticProductDesing.Application.Models.Identity
{
    public class AuthSocialRequest
    {
        public string Id { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Provider { get; set; }

    }
}
