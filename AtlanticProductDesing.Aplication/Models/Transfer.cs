namespace AtlanticProductDesing.Application.Models
{
    public class Transfer
    {
        public string id { get; set; } = string.Empty;
        public string tokenId { get; set; } = string.Empty;
        public double amount { get; set; }
        public string senderWalletId { get; set; } = string.Empty;
        public string receiverWalletId { get; set; } = string.Empty;
        public string senderAddress { get; set; } = string.Empty;
        public string callback { get; set; } = string.Empty;

    }
}
