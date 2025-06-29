namespace AtlanticProductDesing.Application.DTOs
{
    public class PrePurchaseResponseDto
    {
        public int ProjectId { get; set; }
        public int TokenProyectId { get; set; }
        public string InversorUserId { get; set; }
        public double SystemTokenAmountToDebit { get; set; }
        public double ValorationAmount { get; set; }
        public int TokenProjectAmountToBuy { get; set; }
        public int BuyTokensOrder { get; set; }
        public int TokenSystemOrder { get; set; }
    }
}
