namespace AtlanticProductDesing.Application.Models
{
    public class FileBase64
    {
        public string Data { get; set; }
        public string Uri { get; set; }
        public string Ext { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}
