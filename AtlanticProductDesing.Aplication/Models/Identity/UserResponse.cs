namespace AtlanticProductDesing.Application.Models.Identity
{
    public class UserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public bool Verified { get; set; } = false;
        public bool isDocumentsUpload { get; set; } = false;
        public string DocumentFrontImage { get; set; } = string.Empty;
        public string DocumentBackImage { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public IList<string>? Roles { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? ProfileImage { get; set; } = string.Empty;



    }
}
