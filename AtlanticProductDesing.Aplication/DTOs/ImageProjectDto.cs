namespace AtlanticProductDesing.Application.DTOs
{
    public class ImageProjectDto
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public ImageDto Image { get; set; }
        public int ProjectId { get; set; }
    }
}
