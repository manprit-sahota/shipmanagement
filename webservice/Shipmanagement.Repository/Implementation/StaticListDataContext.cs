using Microsoft.Extensions.Logging;
using Shipmanagement.Models;
using Shipmanagement.Repository.Contract;

namespace Shipmanagement.Repository.Implementation
{
    public class StaticListDataContext : IDataContext
    {
        private readonly ILogger<StaticListDataContext> _logger;

        public static Dictionary<Type, IEnumerable<BaseEntity>> Database = new()
        {
            { typeof(Ship), new List<Ship>() }
        };

        public StaticListDataContext(ILogger<StaticListDataContext> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Returns list of all data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>()
            where T : BaseEntity
        {
            return Database[typeof(T)] as IEnumerable<T>;
        }

        /// <summary>
        /// Return single object based on unique id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById<T>(object id)
            where T : BaseEntity
        {
            return GetAll<T>().FirstOrDefault(s => s.Id.ToString() == Convert.ToString(id));
        }

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>True if inserted successfully else false</returns>
        public bool Insert<T>(T entity)
            where T : BaseEntity
        {
            try
            {
                var data = GetAll<T>().ToList();
                data.Add(entity);
                Database[typeof(T)] = data;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to add record");
            }
            return false;
        }

        /// <summary>
        /// Updates existing object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>True if updated successfully else false</returns>
        public bool Update<T>(T entity)
            where T : BaseEntity
        {
            try
            {
                var data = GetAll<T>().Where(s => s.Id != entity.Id).ToList();
                data.Add(entity);
                Database[typeof(T)] = data;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to add record");
            }
            return false;
        }

        /// <summary>
        /// Remove item from list of item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>True if deleted successfully else false</returns>
        public bool Delete<T>(T entity)
            where T : BaseEntity
        {
            try
            {
                Database[typeof(T)] = GetAll<T>().Where(s => s != entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to add record");
            }
            return false;
        }
    }
}
