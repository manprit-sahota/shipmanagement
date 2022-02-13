using Shipmanagement.Models;
using Shipmanagement.Repository.Contract;

namespace Shipmanagement.Repository.Implementation
{
    public class ShipRepository : GenericRepository<Ship>, IShipRepository
    {
        public ShipRepository(IDataContext dataContext) 
            : base(dataContext)
        {
        }

        /// <summary>
        /// Check if ship code is unique or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <returns>True if ship code is unque else false</returns>
        public virtual bool IsShipCodeUnique(Guid id, string code)
        {
            return GetAll().Any(s => s.Id != id && Convert.ToString(s.Code).Trim().ToLower() == Convert.ToString(code).Trim().ToLower()) == false;
        }

        /// <summary>
        /// Check if ship is modified by any other user. (Concurrency check)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastModifiedOn"></param>
        /// <returns></returns>
        public virtual bool IsShipModifiedAlready(Guid id, DateTime lastModifiedOn)
        {
            var ship = GetById(id);
            if (ship == null)
                return true;
            return ship.LastModifiedOn != lastModifiedOn;
        }
    }
}
