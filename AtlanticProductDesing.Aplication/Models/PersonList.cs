namespace AtlanticProductDesing.Application.Models
{
    public class PersonList
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public bool Verified { get; set; } = false;
        public bool isDocumentsUploaded { get; set; } = false;
        public DateTime? CreateDate { get; set; }
    }
}
