
using AtlanticProductDesing.Application.Contracts.Services;
using AtlanticProductDesing.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Linq.Expressions;

namespace AtlanticProductDesing.Application.Features.People.Queries.GetPeople
{
    public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, IReadOnlyList<Person>>
    {
        private readonly IBaseService<Person> _personService;
        private readonly IMapper _mapper;

        public GetPeopleQueryHandler(IBaseService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            // Aquí puedes decidir cómo llenar los demás parámetros
            var predicate = (Expression<Func<Person, bool>>?)null;
            var orderBy = (Func<IQueryable<Person>, IOrderedQueryable<Person>>?)null;
            var includeString = (string?)null;
            var includes = (List<Expression<Func<Person, object>>>?)null;
            var DisableTracking = true;

            var people = await _personService.GetAsync(
                    predicate,
                    orderBy,
                    includeString,
                    includes,
                    request.Skip,
                    request.Limit,
                    DisableTracking
                );

            return people;
        }
    }
}

