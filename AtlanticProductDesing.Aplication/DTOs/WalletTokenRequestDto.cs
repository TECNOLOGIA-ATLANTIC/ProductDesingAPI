namespace AtlanticProductDesing.Application.DTOs
{
    public class WalletTokenRequestDto
    {
        public string Token { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string WalletId { get; set; } = string.Empty;
        public string CallBack { get; set; } = string.Empty;
    }
}
