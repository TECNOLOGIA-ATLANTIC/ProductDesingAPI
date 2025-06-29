namespace AtlanticProductDesing.Application.DTOs
{
    public class CredentialsRequestDto
    {
        public string ApiId { get; set; } = string.Empty;
        public int PrivateKey { get; set; }
        public string PublicKey { get; set; } = string.Empty;
    }
}
