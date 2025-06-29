using AtlanticProductDesing.Domain.Entities;
using MediatR;

namespace AtlanticProductDesing.Application.Features.People.Queries.GetPeople
{
    public class GetPeopleQuery : IRequest<IReadOnlyList<Person>>
    {
        public GetPeopleQuery(int? skip, int? limit)
        {
            Skip = skip;
            Limit = limit;
        }

        public int? Skip { get; set; }
        public int? Limit { get; set; }

    }
}

