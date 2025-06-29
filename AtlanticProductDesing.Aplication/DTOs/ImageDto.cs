namespace AtlanticProductDesing.Application.DTOs
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string? Name { get; set; }
        public string ProjectId { get; set; } = string.Empty;
    }
}
