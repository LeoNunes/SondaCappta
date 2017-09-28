using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SondaCapta.Domain;
using SondaCapta.Domain.Abstractions;

namespace SondaCappta.Domain.Test
{
    [TestClass]
    public class ConfigurationTest
    {
        private IServiceProvider _serviceProvider;

        [TestInitialize]
        public void Initialize()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ISystemConfigurationProvider, SystemConfigurationProvider>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [TestMethod]
        public void NotConfiguredTest()
        {
            ISystemConfigurationProvider configProvider = _serviceProvider.GetService<ISystemConfigurationProvider>();

            Assert.IsFalse(configProvider.IsConfigured);
        }

        [TestMethod]
        public void ConfiguringTest()
        {
            ISystemConfigurationProvider configProvider = _serviceProvider.GetService<ISystemConfigurationProvider>();

            ILandFactory landFactory = new LandFactory();
            ILand land = landFactory.CreateRectangularLand(10, 0, 10, 0);

            ISystemConfiguration config = configProvider.ConfigurationBuilder.SetLand(land).Build();

            Assert.IsTrue(configProvider.IsConfigured);
            Assert.AreEqual(config, configProvider.Configuration);
            Assert.AreEqual(land, configProvider.Configuration.Land);
        }
    }
}
