using AtlanticProductDesing.Domain.Entities;
using AtlanticProductDesing.Domain.Enums;

namespace AtlanticProductDesing.Application.Contracts.Services
{
    public interface IPersonService : IBaseService<Person>
    {
        Task<Person> GetByDocumentAsync(string documentId, DocumentType documentType);
        // Puedes agregar otros métodos específicos si es necesario
    }
}
