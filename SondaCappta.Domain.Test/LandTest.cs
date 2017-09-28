using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using SondaCapta.Domain;
using SondaCapta.Domain.Abstractions;
using System;

namespace SondaCappta.Domain.Test
{
    [TestClass]
    public class LandTest
    {
        IServiceProvider _serviceProvider;
        ILandFactory _landFactory;

        [TestInitialize]
        public void Initialize()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ILandFactory, LandFactory>();
            _serviceProvider = serviceCollection.BuildServiceProvider();

            _landFactory = _serviceProvider.GetService<ILandFactory>();
        }

        [TestMethod]
        public void InvalidRectangularLandCreation()
        {
            bool land1Invalid = false;
            bool land2Invalid = false;

            try
            {
                ILand land1 = _landFactory.CreateRectangularLand(maxX: 10, minX: 15, maxY: 10, minY: 0);
            }
            catch (ArgumentException)
            {
                land1Invalid = true;
            }

            try
            {
                ILand land2 = _landFactory.CreateRectangularLand(maxX: 10, minX: 5, maxY: 10, minY: 20);
            }
            catch (ArgumentException)
            {
                land2Invalid = true;
            }

            Assert.IsTrue(land1Invalid);
            Assert.IsTrue(land2Invalid);
        }

        [TestMethod]
        public void RectangularLandTest()
        {
            ILand land = _landFactory.CreateRectangularLand(maxX: 10, minX: 5, maxY: 10, minY: 0);

            Assert.IsTrue(land.IsInside(7, 5));
            Assert.IsTrue(land.IsInside(10, 10));
            Assert.IsTrue(land.IsInside(5, 0));
            Assert.IsFalse(land.IsInside(11, 5));
            Assert.IsFalse(land.IsInside(4, 5));
            Assert.IsFalse(land.IsInside(7, 11));
            Assert.IsFalse(land.IsInside(7, -1));
        }
    }
}
