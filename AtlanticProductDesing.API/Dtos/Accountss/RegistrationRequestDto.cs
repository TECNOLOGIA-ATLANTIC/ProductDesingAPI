namespace AtlanticProductDesing.API.Dtos.Accountss
{
    public class RegistrationRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //TO DO preguntarle a Jonathan
        //public DocumentTypeDto DocumentTypeDto { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
