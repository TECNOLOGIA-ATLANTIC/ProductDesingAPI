using AtlanticProductDesing.Application.Contracts.Persistence;
using AtlanticProductDesing.Application.Contracts.Services;
using AtlanticProductDesing.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtlanticProductDesing.Application.Features.People.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, long>
    {
        private readonly IPersonService _personService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonService personService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personService = personService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var newPerson = _mapper.Map<Person>(request);

            var existingPerson = await _personService.GetByDocumentAsync(newPerson.DocumentId, newPerson.DocumentType);
            if (existingPerson != null)
            {
                throw new Exception("Una persona con el mismo documento ya existe.");
            }

            var id = await _personService.CreateAsync(newPerson);

            await _unitOfWork.Complete();

            return newPerson.Id;
        }
    }
}
