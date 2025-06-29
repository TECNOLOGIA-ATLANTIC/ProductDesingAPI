namespace AtlanticProductDesing.Application.DTOs
{
    public class MetaDataDto
    {
        public string Tokenize { get; set; } = string.Empty;
        public string User_id { get; set; } = string.Empty;
        public string Store_id { get; set; } = string.Empty;
        public string Order_id { get; set; } = string.Empty;
        public string Store_shortName { get; set; } = string.Empty;
        public IEnumerable<ItemMetaDataDto> Items { get; set; }
    }
}
