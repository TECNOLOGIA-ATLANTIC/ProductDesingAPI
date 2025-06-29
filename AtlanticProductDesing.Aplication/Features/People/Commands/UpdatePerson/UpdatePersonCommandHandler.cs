using AtlanticProductDesing.Application.Contracts.Persistence;
using AtlanticProductDesing.Application.Contracts.Services;
using AtlanticProductDesing.Application.Exceptions;
using AtlanticProductDesing.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtlanticProductDesing.Application.Features.People.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IPersonService _personService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IPersonService personService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personService = personService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var personToUpdate = await _personService.GetByIdAsync(request.Id);

            if (personToUpdate == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            var existingPerson = await _personService.GetByDocumentAsync(request.DocumentId, request.DocumentType);

            if (existingPerson != null && existingPerson.Id != request.Id)
            {
                throw new ConflictException("Una persona con el mismo documento ya existe.");
            }

            _mapper.Map(request, personToUpdate);

            await _personService.UpdateAsync(personToUpdate);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
