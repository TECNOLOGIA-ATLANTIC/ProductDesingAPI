namespace AtlanticProductDesing.Application.Models.Identity
{
    public class RegistrationUpdateRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Identification { get; set; } = string.Empty;
        public string IdDocumentIdentityFrom { get; set; } = string.Empty;
        public string IdDocumentIdentityBack { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}
