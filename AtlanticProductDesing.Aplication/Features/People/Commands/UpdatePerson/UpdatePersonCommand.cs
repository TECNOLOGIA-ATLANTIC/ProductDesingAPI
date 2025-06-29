using AtlanticProductDesing.Domain.Enums;
using MediatR;

namespace AtlanticProductDesing.Application.Features.People.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }
        public DateOnly Birthdate { get; set; }
        public string? Sex { get; set; }
    }
}
