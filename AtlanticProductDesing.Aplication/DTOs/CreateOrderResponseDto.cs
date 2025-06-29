

namespace AtlanticProductDesing.Application.DTOs
{
    public class CreateOrderResponseDto
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Network { get; set; }
        public string Warning { get; set; }
        public string Address { get; set; }
        public double Fee { get; set; }
    }
}
