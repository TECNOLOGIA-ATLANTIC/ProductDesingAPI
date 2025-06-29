namespace AtlanticProductDesing.Application.Models
{
    public class Wallet
    {
        public string Status { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public IEnumerable<WalletToken>? Tokens { get; set; }
    }
}
