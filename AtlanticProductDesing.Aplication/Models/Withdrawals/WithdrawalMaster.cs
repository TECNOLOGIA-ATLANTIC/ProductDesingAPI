namespace AtlanticProductDesing.Application.Models.Withdrawals
{
    public class WithdrawalMaster
    {
        public string Currency { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string To { get; set; } = string.Empty;
    }
}
