using Microsoft.VisualStudio.TestTools.UnitTesting;
using SondaCapta.Domain;
using SondaCapta.Domain.Abstractions;

namespace SondaCappta.Domain.Test
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void NotConfiguredTest()
        {
            ISystemConfigurationProvider provider = new SystemConfigurationProvider();

            Assert.IsFalse(provider.IsConfigured);
        }

        [TestMethod]
        public void ConfiguringTest()
        {
            ISystemConfigurationProvider provider = new SystemConfigurationProvider();

            ILandFactory landFactory = new LandFactory();
            ILand land = landFactory.CreateRectangularLand(10, 0, 10, 0);

            ISystemConfiguration config = provider.ConfigurationBuilder.SetLand(land).Build();

            Assert.IsTrue(provider.IsConfigured);
            Assert.AreEqual(config, provider.Configuration);
            Assert.AreEqual(land, provider.Configuration.Land);
        }
    }
}
