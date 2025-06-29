namespace AtlanticProductDesing.Application.DTOs
{
    public class TokenDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string TokenIdBC { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string TokenImage { get; set; }
        public string? ImageName { get; set; }
        public string ImageUri { get; set; } = string.Empty;
    }
}
