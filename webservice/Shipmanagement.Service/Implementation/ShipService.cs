using Shipmanagement.Models;
using Shipmanagement.Repository.Contract;
using Shipmanagement.Service.Contract;
using Shipmanagement.ViewModels;

namespace Shipmanagement.Service.Implementation
{
    public class ShipService : IShipService
    {
        private readonly IShipRepository _shipRepository;
        private readonly IDataMapper _dataMapper;

        public ShipService(IShipRepository shipRepository
            , IDataMapper dataMapper)
        {
            _shipRepository = shipRepository;
            _dataMapper = dataMapper;
        }

        /// <summary>
        /// Get all ships
        /// </summary>
        /// <returns></returns>
        public List<ShipViewModel> GetAll()
        {
            var data = _shipRepository.GetAll().ToList();
            return _dataMapper.Map<List<Ship>, List<ShipViewModel>>(data);
        }

        /// <summary>
        /// Get ship by unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AddEditShipViewModel GetById(Guid id)
        {
            var entity = _shipRepository.GetById(id);
            if (entity == null)
                return null;
            return _dataMapper.Map<Ship, AddEditShipViewModel>(entity);
        }

        /// <summary>
        /// Add new ships
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(AddEditShipViewModel model)
        {
            var entity = _dataMapper.Map<AddEditShipViewModel, Ship>(model);
            entity.LastModifiedOn = DateTime.Now;
            entity.Id = Guid.NewGuid();
            return _shipRepository.Insert(entity);
        }

        /// <summary>
        /// Update existing ship
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Guid id, AddEditShipViewModel model)
        {
            var entity = _shipRepository.GetById(id);
            if (entity == null)
                return false;
            _dataMapper.Map<AddEditShipViewModel, Ship>(model, entity);
            entity.LastModifiedOn = DateTime.Now;
            return _shipRepository.Update(entity);
        }

        /// <summary>
        /// Delete ship by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            var entity = _shipRepository.GetById(id);
            if (entity == null)
                return false;
            return _shipRepository.Delete(entity);
        }

        /// <summary>
        /// Check if Ship code is unique or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsShipCodeUnique(Guid id, string code)
        {
            return _shipRepository.IsShipCodeUnique(id, code);
        }

        /// <summary>
        /// Check if ship has been modified by any other user (Concurrency check)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastModifiedDate"></param>
        /// <returns></returns>
        public bool IsShipModifiedAlready(Guid id, DateTime? lastModifiedDate)
        {
            if (id == default)
                return false;
            return _shipRepository.IsShipModifiedAlready(id, lastModifiedDate.GetValueOrDefault());
        }
    }
}
