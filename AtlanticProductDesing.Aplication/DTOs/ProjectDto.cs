namespace AtlanticProductDesing.Application.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TokenDto Token { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string SecondaryAddress { get; set; } = string.Empty;
        public string Locality { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string LocationMap { get; set; } = string.Empty;
        public string CommercialContact { get; set; } = string.Empty;
        public string CommercialEmail { get; set; } = string.Empty;
        public string TokenImage { get; set; } = string.Empty;
        public List<WalletTokenDto>? Valorations { get; set; }
        public List<ImageDto>? Images { get; set; }
        public WalletDto Wallet { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ClosureDate { get; set; } = string.Empty;
    }
}
