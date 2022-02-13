using Shipmanagement.Models;

namespace Shipmanagement.Repository.Contract
{
    /// <summary>
    /// Data context to perform operations with database
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Returns list of all data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>()
            where T : BaseEntity;

        /// <summary>
        /// Return single object based on unique id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById<T>(object id)
            where T : BaseEntity;

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>True if inserted successfully else false</returns>
        bool Insert<T>(T entity)
            where T : BaseEntity;

        /// <summary>
        /// Updates existing object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>True if updated successfully else false</returns>
        bool Update<T>(T entity)
            where T : BaseEntity;

        /// <summary>
        /// Remove item from list of item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>True if deleted successfully else false</returns>
        bool Delete<T>(T entity)
            where T : BaseEntity;
    }
}
