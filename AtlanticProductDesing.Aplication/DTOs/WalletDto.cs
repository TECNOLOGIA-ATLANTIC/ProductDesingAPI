
namespace AtlanticProductDesing.Application.DTOs
{
    public class WalletDto
    {
        public int Id { get; set; }
        public string WalletIdBC { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        public List<WalletTokenDto> Tokens { get; set; }
    }
}
