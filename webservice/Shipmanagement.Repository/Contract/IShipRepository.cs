using Shipmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipmanagement.Repository.Contract
{
    public interface IShipRepository  : IGenericRepository<Ship>
    {
        /// <summary>
        /// Check if ship code is unique or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <returns>True if ship code is unque else false</returns>
        bool IsShipCodeUnique(Guid id, string code);

        /// <summary>
        /// Check if ship is modified by any other user. (Concurrency check)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastModifiedOn"></param>
        /// <returns></returns>
        bool IsShipModifiedAlready(Guid id, DateTime lastModifiedOn);
    }
}
