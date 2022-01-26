using GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GenericRepository.Implementations
{
    public abstract class Repository : IRepository
    {
        public Repository(DbContext dbContext) =>
            _dbContext = dbContext;

        private readonly DbContext _dbContext;

        public async Task<IEnumerable<T>> ToListAsync<T>(int quantity = 10, CancellationToken cancellationToken = default) where T : class =>
            await _dbContext
                .Set<T>()
                .AsNoTracking()
                .Take(quantity)
                .ToListAsync(cancellationToken);

        public IEnumerable<T> ToList<T>(int quantity = 10) where T : class =>
            _dbContext
                .Set<T>()
                .AsNoTracking()
                .Take(quantity)
                .ToList();

        public async Task<T> FindAsync<T, U>(U id, CancellationToken cancellationToken) where T : class
        {
            var entity = await _dbContext
                .Set<T>()
                .FindAsync(new object[] { id }, cancellationToken);

            if (entity != null)
                _dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public T Find<T, U>(U id) where T : class
        {
            var entity = _dbContext
                .Set<T>()
                .Find(id);

            if (entity != null)
                _dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class =>
            await _dbContext
                .Set<T>()
                .AddAsync(entity, cancellationToken);

        public void Add<T>(T entity) where T : class =>
            _dbContext
                .Set<T>()
                .Add(entity);

        public void Update<T>(T entity) where T : class =>
            _dbContext
                .Set<T>()
                .Update(entity);

        public void Remove<T>(T entity) where T : class =>
            _dbContext
                .Set<T>()
                .Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken) =>
            await _dbContext.SaveChangesAsync(cancellationToken);

        public void SaveChanges() =>
            _dbContext.SaveChanges();
    }
}
