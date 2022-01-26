using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    /// <summary>
    /// interface that provides useful methods for data access
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// lists a table corresponding to the provided entity limited by the quantity as asynchronous
        /// </summary>
        /// <typeparam name="T">entity corresponding to table</typeparam>
        /// <param name="quantity">quantity to limit results</param>
        /// <param name="cancellationToken"></param>
        /// <returns>returns a list of corresponding entity limited by the provided quantity</returns>
        Task<IEnumerable<T>> ToListAsync<T>(int quantity = 10, CancellationToken cancellationToken = new CancellationToken()) where T : class;
        /// <summary>
        /// lists a table corresponding to the provided entity limited by the quantity
        /// </summary>
        /// <typeparam name="T">entity corresponding to table</typeparam>
        /// <param name="quantity">quantity to limit results</param>
        /// <returns>returns a list of corresponding entity limited by the provided quantity</returns>
        IEnumerable<T> ToList<T>(int quantity = 10) where T : class;
        /// <summary>
        /// gets the row of the table that primary key matches to the provided id as asynchronous
        /// </summary>
        /// <typeparam name="T">entity corresponding to table</typeparam>
        /// <typeparam name="U">type of primary key</typeparam>
        /// <param name="id">primary key to search in table</param>
        /// <param name="cancellationToken"></param>
        /// <returns>returns a corresponding entity</returns>
        Task<T> FindAsync<T, U>(U id, CancellationToken cancellationToken) where T : class;
        /// <summary>
        /// gets the row of the table that primary key matches to the provided id
        /// </summary>
        /// <typeparam name="T">entity corresponding to table</typeparam>
        /// <typeparam name="U">type of primary key</typeparam>
        /// <param name="id">primary key to search in table</param>
        /// <returns>returns a corresponding entity<</returns>
        T Find<T, U>(U id) where T : class;
        /// <summary>
        /// add the provided entity to the table as asynchronous
        /// </summary>
        /// <typeparam name="T">entity corresponding to table</typeparam>
        /// <param name="entity">entity that will be added to the table</param>
        /// <param name="cancellationToken"></param>
        Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        /// <summary>
        /// add the provided entity to the table
        /// </summary>
        /// <typeparam name="T">entity corresponding to table</typeparam>
        /// <param name="entity">entity that will be added to the table</param>
        void Add<T>(T entity) where T : class;
        /// <summary>
        /// updates a entity in the table
        /// </summary>
        /// <typeparam name="T">entity corresponding to table</typeparam>
        /// <param name="entity">entity that will be updated in the table</param>
        void Update<T>(T entity) where T : class;
        /// <summary>
        /// deletes a entity in the table
        /// </summary>
        /// <typeparam name="T">entity corresponding to table</typeparam>
        /// <param name="entity">entity that will be deleted from the table</param>
        void Remove<T>(T entity) where T : class;
        /// <summary>
        /// save all changes as asynchronous
        /// </summary>
        /// <param name="cancellationToken"></param>
        Task SaveChangesAsync(CancellationToken cancellationToken);
        /// <summary>
        /// save all changes
        /// </summary>
        void SaveChanges();
    }
}
