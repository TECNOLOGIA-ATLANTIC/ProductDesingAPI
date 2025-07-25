﻿using AtlanticProductDesing.Application.Contracts.Persistence;
using AtlanticProductDesing.Domain.Common;
using AtlanticProductDesing.Domain.Entities;
using AtlanticProductDesing.Infrastruture.Persistence;
using System.Collections;

namespace AtlanticProductDesing.Infrastruture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly ApplicationDbContext _context;


        private IAsyncRepository<Person> _personRepository;



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDbContext ApplicationDbContext => _context;

        public IAsyncRepository<Person> PersonRepository => _personRepository ??= new PersonRepository(_context);



        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);

            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }

}
