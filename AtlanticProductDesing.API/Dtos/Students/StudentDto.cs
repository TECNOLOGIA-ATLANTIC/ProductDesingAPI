using AtlanticProductDesing.API.Dtos.PersonContact;
using AtlanticProductDesing.Domain.Enums;

namespace AtlanticProductDesing.API.Dtos.Student
{
    public class StudentDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; }
        public IEnumerable<PersonContactMethodDto> ContactMethods { get; set; }
    }
}
