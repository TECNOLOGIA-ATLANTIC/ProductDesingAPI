namespace AtlanticProductDesing.Domain.Interfaces
{
    public interface IUserRegisterData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EventOrganizer { get; set; }
        public bool AcceptPolicies { get; set; }
        public bool AcceptNewsLetter { get; set; }
        public string IdDocument { get; set; }
    }
}
