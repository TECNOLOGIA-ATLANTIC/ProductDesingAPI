namespace AtlanticProductDesing.Application.Models
{
    public class BaseApiResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Callback { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string Token { get; set; }
        public Wallet SenderWallet { get; set; }
        public Wallet ReceiverWallet { get; set; }
    }
}
