using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<T>> ToListAsync<T>(int quantity = 10, CancellationToken cancellationToken = new CancellationToken()) where T : class;
        IEnumerable<T> ToList<T>(int quantity = 10) where T : class;
        Task<T> FindAsync<T, U>(U id, CancellationToken cancellationToken) where T : class;
        T Find<T, U>(U id) where T : class;
        Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void SaveChanges();
    }
}
