using AtlanticProductDesing.Domain.Common;
using AtlanticProductDesing.Domain.Enums;

namespace AtlanticProductDesing.Domain.Entities
{
    public class Person : BaseDomainModel
    {
        public Person()
        {

            ContactMethods = new List<PersonContactMethod>();
        }

        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string DocumentId { get; set; }
        public required DocumentType DocumentType { get; set; }
        public DateOnly? Birthdate { get; set; }
        public string? Sex { get; set; }
        public string? UserId { get; set; }
        public IEnumerable<PersonContactMethod>? ContactMethods { get; set; }

    }
}
