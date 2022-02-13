using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shipmanagement.Repository;
using Shipmanagement.Service.Contract;
using Shipmanagement.Tests.Core;
using System;

namespace Shipmanagement.Tests
{
    [TestClass]
    public class ShipServiceTest : BaseServiceTest
    {
        [TestMethod]
        public void Get_All_Ship_Data()
        {

            // INFO: Arrange
            var shipService = GetService<IShipService>();

            // INFO : Act
            int actual = shipService.GetAll().Count;
            int expected = 1;

            // INFO: Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Get_Ship_By_Id()
        {
            // INFO: Arrange
            var shipService = GetService<IShipService>();

            // INFO : Act
            var actual = shipService.GetById(Guid.Parse(SHIPID));
            var expected = TestingShip();

            // INFO: Assert
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.Code, expected.Code);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Width, expected.Width);
            Assert.AreEqual(actual.Length, expected.Length);
            Assert.AreEqual(actual.LastModifiedOn, expected.LastModifiedOn);
        }

        [TestMethod]
        public void Insert_Ship()
        {
            // INFO: Arrange
            var shipService = GetService<IShipService>();

            // INFO : Act
            var actual = shipService.Insert(new ViewModels.AddEditShipViewModel
            {
                Id = Guid.Parse(SHIPID),
                Code = "AAAA-1111-A1",
                LastModifiedOn = new DateTime(2022, 1, 1, 1, 1, 1),
                Length = 23,
                Name = "Ship 1",
                Width = 20
            });
            var expected = true;

            // INFO: Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Update_Ship()
        {
            // INFO: Arrange
            var shipService = GetService<IShipService>();

            // INFO : Act
            var actual = shipService.Update(Guid.Parse(SHIPID), new ViewModels.AddEditShipViewModel
            {
                Id = Guid.Parse(SHIPID),
                Code = "AAAA-1111-A1",
                LastModifiedOn = DateTime.Now,
                Length = 33,
                Width = 22,
                Name = "Ship 2"
            });
            var expected = true;

            // INFO: Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Delete_Ship()
        {
            // INFO: Arrange
            var shipService = GetService<IShipService>();

            // INFO : Act
            var actual = shipService.Delete(Guid.Parse(SHIPID));
            var expected = true;

            // INFO: Assert
            Assert.AreEqual(actual, expected);
        }
    }
}