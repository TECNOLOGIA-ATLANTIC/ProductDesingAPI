using AtlanticProductDesing.Application.Contracts.Persistence;
using AtlanticProductDesing.Application.Contracts.Services;
using AtlanticProductDesing.Domain.Common;
using System.Linq.Expressions;

namespace AtlanticProductDesing.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseDomainModel
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IAsyncRepository<T> _repository;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<T>();
        }

        public virtual async Task<long> CreateAsync(T entity)
        {
            var result = await _repository.AddAsync(entity);
            return result.Id;
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }



        public virtual async Task<T> UpdateAsync(T entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return result;
        }

        public virtual async Task<IEnumerable<T>> GetListAsync()
        {
            return await _repository.GetAllAsync();
        }



        public virtual async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);

        }

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeString = null, List<Expression<Func<T, object>>>? includes = null, int? skip = null, int? limit = null, bool disableTracking = true)
        {
            return await _repository.GetAsync(predicate, orderBy, includeString, includes, skip, limit, disableTracking);
        }
    }
}
