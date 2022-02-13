using Shipmanagement.Models;
using Shipmanagement.Repository.Contract;

namespace Shipmanagement.Repository.Implementation
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        protected readonly IDataContext _dataContext;

        public GenericRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual bool Delete(T entity)
        {
            return _dataContext.Delete<T>(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dataContext.GetAll<T>();
        }

        public virtual T GetById(object id)
        {
            return _dataContext.GetById<T>(id);
        }

        public virtual bool Insert(T entity)
        {
            return _dataContext.Insert<T>(entity);
        }

        public virtual bool Update(T entity)
        {
            return _dataContext.Update<T>(entity);
        }
    }
}
