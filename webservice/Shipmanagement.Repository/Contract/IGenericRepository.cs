using Shipmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipmanagement.Repository.Contract
{
    public interface IGenericRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();


        /// <summary>
        /// Get item by Uniqueidentifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True if added successfully else false</returns>
        bool Insert(T entity);

        /// <summary>
        /// Update existing item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True if updated successfully else false</returns>
        bool Update(T entity);

        /// <summary>
        /// Delete existing item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True if deleted successfully else false</returns>
        bool Delete(T entity);
    }
}
