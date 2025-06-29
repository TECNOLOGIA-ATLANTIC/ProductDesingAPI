using AtlanticProductDesing.Application.Contracts.Persistence;
using AtlanticProductDesing.Domain.Common;
using AtlanticProductDesing.Infrastruture.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AtlanticProductDesing.Infrastruture.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected readonly ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            // await _context.SaveChangesAsync();
            return entity;
        }

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            // await _context.SaveChangesAsync();
        }

        public void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteEntityRange(List<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                                     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                     string? includeString = null,
                                                     List<Expression<Func<T, object>>>? includes = null,
                                                     int? skip = null,
                                                     int? limit = null,
                                                     bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (skip != null) query = query.Skip((int)skip);

            if (limit != null) query = query.Take((int)limit);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>>? predicate = null,
                                      List<Expression<Func<T, object>>>? includes = null,
                                      bool disableTracking = true)
        {
            var entityList = await GetAsync(
                predicate: predicate,
                includes: includes,
                disableTracking: disableTracking
            );
            return entityList.FirstOrDefault();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            // await _context.SaveChangesAsync();
            return entity;
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> DetachUpdateAsync(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Detached;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
