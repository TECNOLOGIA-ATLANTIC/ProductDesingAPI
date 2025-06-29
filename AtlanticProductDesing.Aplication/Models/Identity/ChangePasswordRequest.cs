namespace AtlanticProductDesing.Application.Models.Identity
{
    public class ChangePasswordRequest
    {
        public string Password { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
    }
}
