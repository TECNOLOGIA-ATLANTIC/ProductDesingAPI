namespace AtlanticProductDesing.Application.Models.Withdrawals
{
    public class WithdrawalR
    {
        public string Currency { get; set; } = string.Empty;
        public string AccountId { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string Network { get; set; } = string.Empty;
        public string CallbackUrl { get; set; } = string.Empty;
    }
}
