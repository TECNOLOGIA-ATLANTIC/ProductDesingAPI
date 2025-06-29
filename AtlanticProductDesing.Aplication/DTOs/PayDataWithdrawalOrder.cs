namespace AtlanticProductDesing.Application.DTOs
{
    public class PayDataWithdrawalOrderRequestDto
    {
        public string Reference { get; set; }
        public string BankName { get; set; }
        public DateTime DateOperation { get; set; }
    }
}
