using AtlanticProductDesing.Domain.Entities;
using MediatR;

namespace AtlanticProductDesing.Application.Features.People.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public long Id { get; set; }

        public GetPersonByIdQuery(long id)
        {
            Id = id;
        }
    }
}
