using AtlanticProductDesing.Domain.Common;
using System.Linq.Expressions;

namespace AtlanticProductDesing.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        string? includeString = null,
                                        List<Expression<Func<T, object>>>? includes = null,
                                        int? skip = null,
                                        int? limit = null,
                                        bool disableTracking = true);

        Task<T> GetByIdAsync(long id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        void DeleteEntityRange(List<T> entity);

        Task<T> GetFirstAsync(Expression<Func<T, bool>>? predicate = null,
                              List<Expression<Func<T, object>>>? includes = null,
                              bool disableTracking = true);

        Task<T> DetachUpdateAsync(T entity);
    }
}
