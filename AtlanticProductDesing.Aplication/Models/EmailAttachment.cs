namespace AtlanticProductDesing.Application.Models
{
    public class EmailAttachment
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Type { get; set; }
        public string? Disposition { get; set; }
        public string? ContentId { get; set; }

    }
}
