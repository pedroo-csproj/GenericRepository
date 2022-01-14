using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    public interface IGenericRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken);
        IEnumerable<T> GetAll<T>();
        Task<T> GetByIdAsync<T, U>(U id, CancellationToken cancellationToken);
        T GetById<T, U>(U id);
        Task AddAsync<T>(T entity, CancellationToken cancellationToken);
        void Add<T>(T entity);
        void Update<T>(T entity);
        void Delete<T>(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void SaveChanges();
    }
}
