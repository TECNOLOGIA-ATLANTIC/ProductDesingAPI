namespace AtlanticProductDesing.Application.DTOs
{
    public class CashOutWireTransferRejectRequestDTO
    {
        public int TransactionId { get; set; }
        public string RejectedReason { get; set; }
    }
}