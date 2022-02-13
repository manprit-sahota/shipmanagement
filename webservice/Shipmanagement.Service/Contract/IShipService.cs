using Shipmanagement.ViewModels;

namespace Shipmanagement.Service.Contract
{
    /// <summary>
    /// Ship interface
    /// </summary>
    public interface IShipService
    {
        /// <summary>
        /// Get all ships
        /// </summary>
        /// <returns></returns>
        List<ShipViewModel> GetAll();

        /// <summary>
        /// Get ship by unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AddEditShipViewModel GetById(Guid id);

        /// <summary>
        /// Add new ships
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Insert(AddEditShipViewModel model);

        /// <summary>
        /// Update existing ship
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Guid id, AddEditShipViewModel model);

        /// <summary>
        /// Delete ship by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(Guid id);

        /// <summary>
        /// Check if Ship code is unique or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        bool IsShipCodeUnique(Guid id, string code);

        /// <summary>
        /// Check if ship has been modified by any other user (Concurrency check)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastModifiedDate"></param>
        /// <returns></returns>
        bool IsShipModifiedAlready(Guid id, DateTime? lastModifiedDate);
    }
}
