namespace AtlanticProductDesing.Application.DTOs
{
    public class PaymentCostRequestDto
    {
        public string Amount { get; set; } = string.Empty;
        public string Installments { get; set; } = string.Empty;
        public string CardHolder { get; set; } = string.Empty;
    }
}
