using Microsoft.AspNetCore.Identity;


namespace AtlanticProductClient.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        // public DateTime? DateOfBirth { get; set; } = null;
        public bool Verified { get; set; } = false;
        public DateTime? DateOfVerification { get; set; } = null;
        public string? VerifiedBy { get; set; } = string.Empty;
        //public string UrlDocumentId { get; set; } = string.Empty;
        //public string UrlDocumentIdBack { get; set; } = string.Empty;
        //public string IdDocument { get; set; } = string.Empty;
        //public string? DocumentFrontImage { get; set; }
        //public string? DocumentBackImage { get; set; }
        //public string? Address { get; set; } = string.Empty;
        //public string? ProfileImage { get; set; } = string.Empty;
        //public DateTime? CreateDate { get; set; }
        //public bool EventOrganizer { get; set; }
        public bool AcceptNewsLetter { get; set; } = false;
        public ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}
