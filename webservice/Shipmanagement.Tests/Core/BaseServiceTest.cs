using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shipmanagement.Models;
using Shipmanagement.Repository;
using Shipmanagement.Repository.Contract;
using Shipmanagement.Repository.Implementation;
using Shipmanagement.Service;
using Shipmanagement.Service.Implementation;
using Shipmanagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipmanagement.Tests.Core
{
    public class BaseServiceTest
    {
        protected const string SHIPID = "6add2c45-1e18-4a89-93a7-b8b3190437c4";

        public T GetService<T>()
        {
            var services = new ServiceCollection();
            services.AddServiceLayer();
            services.AddRepositoryLayer();

            // INFO :: Setup ship mock repository
            services.AddTransient<IShipRepository, ShipRepository>(s =>
            {
                var dataContext = s.GetRequiredService<IDataContext>();
                var mockShipRepository = new Mock<ShipRepository>(new object[] { dataContext });

                mockShipRepository.Setup(ss => ss.GetAll())
                    .Returns(new List<Ship>
                    {
                        TestingShip()
                    });

                mockShipRepository.Setup(ss => ss.GetById(Guid.Parse(SHIPID)))
                    .Returns(TestingShip());

                mockShipRepository.Setup(ss => ss.Insert(It.IsAny<Ship>()))
                    .Returns(true);

                mockShipRepository.Setup(ss => ss.Update(It.IsAny<Ship>()))
                    .Returns(true);

                mockShipRepository.Setup(ss => ss.Delete(It.IsAny<Ship>()))
                    .Returns(true);

                return mockShipRepository.Object;
            });

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetRequiredService<T>();
        }

        protected Ship TestingShip()
        {
            return new Ship
            {
                Id = Guid.Parse(SHIPID),
                Code = "AAAA-1111-A1",
                LastModifiedOn = new DateTime(2022, 1, 1, 1, 1, 1),
                Length = 23,
                Name = "Ship 1",
                Width = 20
            };
        }
    }
}
