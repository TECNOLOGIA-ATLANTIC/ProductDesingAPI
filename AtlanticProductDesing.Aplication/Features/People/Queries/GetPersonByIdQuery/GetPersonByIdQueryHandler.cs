using AtlanticProductDesing.Application.Contracts.Services;
using AtlanticProductDesing.Application.Exceptions;
using AtlanticProductDesing.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtlanticProductDesing.Application.Features.People.Queries.GetPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public GetPersonByIdQueryHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _personService.GetByIdAsync(request.Id);

            if (person == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            return person;
        }
    }
}
