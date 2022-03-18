using GenericRepository.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Identity.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public Repository(IdentityDbContext identityDbContext) =>
            _identityDbContext = identityDbContext;

        private readonly IdentityDbContext _identityDbContext;

        public async Task<IEnumerable<T>> ToListAsync(int quantity = 10, CancellationToken cancellationToken = default) =>
            await _identityDbContext
                .Set<T>()
                .AsNoTracking()
                .Take(quantity)
                .ToListAsync(cancellationToken);

        public IEnumerable<T> ToList(int quantity = 10) =>
            _identityDbContext
                .Set<T>()
                .AsNoTracking()
                .Take(quantity)
                .ToList();

        public async Task<T> FindAsync<U>(U id, CancellationToken cancellationToken)
        {
            var entity = await _identityDbContext
                .Set<T>()
                .FindAsync(new object[] { id }, cancellationToken);

            if (entity != null)
                _identityDbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public T Find<U>(U id)
        {
            var entity = _identityDbContext
                .Set<T>()
                .Find(id);

            if (entity != null)
                _identityDbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken) =>
            await _identityDbContext
                .Set<T>()
                .AddAsync(entity, cancellationToken);

        public void Add(T entity) =>
            _identityDbContext
                .Set<T>()
                .Add(entity);

        public void Update(T entity) =>
            _identityDbContext
                .Set<T>()
                .Update(entity);

        public void Remove(T entity) =>
            _identityDbContext
                .Set<T>()
                .Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken) =>
            await _identityDbContext.SaveChangesAsync(cancellationToken);

        public void SaveChanges() =>
            _identityDbContext.SaveChanges();
    }

    public abstract class Repository : IRepository
    {
        public Repository(IdentityDbContext identityDbContext) =>
            _identityDbContext = identityDbContext;

        private readonly DbContext _identityDbContext;

        public async Task<IEnumerable<T>> ToListAsync<T>(int quantity = 10, CancellationToken cancellationToken = default) where T : class =>
            await _identityDbContext
                .Set<T>()
                .AsNoTracking()
                .Take(quantity)
                .ToListAsync(cancellationToken);

        public IEnumerable<T> ToList<T>(int quantity = 10) where T : class =>
            _identityDbContext
                .Set<T>()
                .AsNoTracking()
                .Take(quantity)
                .ToList();

        public async Task<T> FindAsync<T, U>(U id, CancellationToken cancellationToken) where T : class
        {
            var entity = await _identityDbContext
                .Set<T>()
                .FindAsync(new object[] { id }, cancellationToken);

            if (entity != null)
                _identityDbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public T Find<T, U>(U id) where T : class
        {
            var entity = _identityDbContext
                .Set<T>()
                .Find(id);

            if (entity != null)
                _identityDbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class =>
            await _identityDbContext
                .Set<T>()
                .AddAsync(entity, cancellationToken);

        public void Add<T>(T entity) where T : class =>
            _identityDbContext
                .Set<T>()
                .Add(entity);

        public void Update<T>(T entity) where T : class =>
            _identityDbContext
                .Set<T>()
                .Update(entity);

        public void Remove<T>(T entity) where T : class =>
            _identityDbContext
                .Set<T>()
                .Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken) =>
            await _identityDbContext.SaveChangesAsync(cancellationToken);

        public void SaveChanges() =>
            _identityDbContext.SaveChanges();
    }
}
