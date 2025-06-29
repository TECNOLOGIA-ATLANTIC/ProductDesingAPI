namespace AtlanticProductDesing.API.Dtos.DeliveryType
{
    public class DeliveryTypeBaseDto
    {
        public required int DeliveryCode { get; set; }
        public required string Description { get; set; }
        public required int DaysFrom { get; set; }
        public required int DaysTo { get; set; }
        public required bool ValidBusinessDay { get; set; }
        public required decimal TolerancePercentage { get; set; }
        public required string Status { get; set; }
    }
}
