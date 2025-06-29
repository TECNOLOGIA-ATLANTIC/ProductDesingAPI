
namespace AtlanticProductDesing.Application.DTOs
{
    public class CashInDto
    {
        public string UserId { get; set; }
        public int WalletId { get; set; }
        public WalletDto Wallet { get; set; }
    }
}
