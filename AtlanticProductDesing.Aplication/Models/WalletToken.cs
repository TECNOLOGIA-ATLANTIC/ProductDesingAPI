namespace AtlanticProductDesing.Application.Models
{
    public class WalletToken
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Type { get; set; } = string.Empty;
        public string TokenId { get; set; }
        public double Amount { get; set; }
        public string SenderWallet { get; set; }
        public Wallet ReceiverWallet { get; set; }
    }
}
