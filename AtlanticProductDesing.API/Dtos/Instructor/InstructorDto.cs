using AtlanticProductDesing.API.Dtos.InstructorSkill;
using AtlanticProductDesing.API.Dtos.PersonContact;
using AtlanticProductDesing.Domain.Enums;

namespace AtlanticProductDesing.API.Dtos.Instructor
{
    public class InstructorDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; }
        public string Specialty { get; set; }
        public IEnumerable<InstructorSkillDto> Skills { get; set; }
        public IEnumerable<PersonContactMethodDto> ContactMethods { get; set; }
    }
}
