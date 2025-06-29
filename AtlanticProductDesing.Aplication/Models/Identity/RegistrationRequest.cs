namespace AtlanticProductDesing.Application.Models.Identity
{
    public class RegistrationRequest
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool EventOrganizer { get; set; }
        public bool AcceptPolicies { get; set; } = false;
        public bool AcceptNewsLetter { get; set; } = false;
        public string DocumentId { get; set; } = string.Empty;
    }
}
