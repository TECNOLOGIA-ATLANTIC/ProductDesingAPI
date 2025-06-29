using AtlanticProductDesing.Application.Contracts.Persistence;
using AtlanticProductDesing.Domain.Entities;
using AtlanticProductDesing.Infrastruture.Persistence;

namespace AtlanticProductDesing.Infrastruture.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IAsyncRepository<Person>
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
