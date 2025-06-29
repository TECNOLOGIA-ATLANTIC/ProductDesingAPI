namespace AtlanticProductDesing.Application.Models.Identity
{
    public class AuthUser
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public bool Verified { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IdDocumentImageLoaded { get; set; }
        public IEnumerable<string>? Roles { get; set; }

        public string Address { get; set; } = string.Empty;

    }
}
