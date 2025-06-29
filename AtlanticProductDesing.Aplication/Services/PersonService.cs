using AtlanticProductDesing.Application.Contracts.Persistence;
using AtlanticProductDesing.Application.Contracts.Services;
using AtlanticProductDesing.Domain.Entities;
using AtlanticProductDesing.Domain.Enums;
using System.Linq.Expressions;

namespace AtlanticProductDesing.Application.Services
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public async Task<Person> GetByDocumentAsync(string documentId, DocumentType documentType)
        {
            Expression<Func<Person, bool>> predicate = p => p.DocumentId == documentId && p.DocumentType == documentType;
            return await _repository.GetFirstAsync(predicate, includes: null);
        }

    }
}
