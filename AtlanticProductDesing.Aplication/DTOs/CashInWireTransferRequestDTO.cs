using AutoMapper.Configuration.Annotations;

namespace AtlanticProductDesing.Application.DTOs
{
    public class CashInWireTransferRequestDTO
    {
        public string? NumberReferenc { get; set; }
        public string Identification { get; set; }
        public double Amount { get; set; }
        public double AmountToPay { get; set; }
        public DateTime DateOperation { get; set; }

        [Ignore]
        public ImageDto Support { get; set; }
    }
}