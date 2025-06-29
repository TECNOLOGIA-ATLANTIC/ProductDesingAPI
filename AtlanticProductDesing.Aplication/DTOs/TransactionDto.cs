
namespace AtlanticProductDesing.Application.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string InversorId { get; set; }
        public string InversorName { get; set; }

        public string Account { get; set; }

        public Guid ReferenceDonc { get; set; }

        public string? ReferenceSender { get; set; }

        public string? ReferenceReceiver { get; set; }

        public string? Address { get; set; }

        public string? NameAccount { get; set; }

        public string Currency { get; set; }

        public double Amount { get; set; }

        public double AmountToPay { get; set; }

        public DateTime DateOperation { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public int? SupportId { get; set; }

        public ImageDto Support { get; set; }

        public string Type { get; set; }

        public ProjectDto Project { get; set; }

        public TokenDto TokenSender { get; set; }

        public TokenDto TokenReceiver { get; set; }
    }
}
