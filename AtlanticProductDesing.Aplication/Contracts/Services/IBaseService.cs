using System.Linq.Expressions;

namespace AtlanticProductDesing.Application.Contracts.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<long> CreateAsync(T entity);
        Task<T> GetByIdAsync(long id);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetListAsync();
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    string? includeString = null,
                                    List<Expression<Func<T, object>>>? includes = null,
                                    int? skip = null,
                                    int? limit = null,
                                    bool disableTracking = true);
    }
}
