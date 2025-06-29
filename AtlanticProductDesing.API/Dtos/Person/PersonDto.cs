using AtlanticProductDesing.Domain.Enums;

namespace AtlanticProductDesing.API.Dtos.Person
{
    public class PersonDto
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }
        public DateOnly? Birthdate { get; set; }
        public string? Sex { get; set; }
    }
}
