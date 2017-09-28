using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using SondaCapta.Domain.Abstractions;
using SondaCapta.Common;

namespace SondaCapta.UI.Console.Test
{
    [TestClass]
    public class InterpreterTest
    {
        [TestMethod]
        public void ConfigurationTest()
        {
            ServiceConfiguration.ConfigureServices();

            ISystemConfigurationProvider configProvider = ServiceConfiguration.ServiceProvider.GetService<ISystemConfigurationProvider>();

            InputInterpreter interpreter = ServiceConfiguration.ServiceProvider.GetService<InputInterpreter>();
            interpreter.Configure("5 4");

            Assert.IsTrue(configProvider.IsConfigured);
            Assert.IsTrue(configProvider.Configuration.Land.IsInside(5, 4));
            Assert.IsTrue(configProvider.Configuration.Land.IsInside(0, 0));
            Assert.IsFalse(configProvider.Configuration.Land.IsInside(6, 3));
            Assert.IsFalse(configProvider.Configuration.Land.IsInside(4, 5));
        }

        [TestMethod]
        public void CreateProbeTest()
        {
            ServiceConfiguration.ConfigureServices();

            InputInterpreter interpreter = ServiceConfiguration.ServiceProvider.GetService<InputInterpreter>();
            interpreter.Configure("5 5");

            IProbe probe = interpreter.CreateProbe("2 3 E");

            Assert.AreEqual(2, probe.Position.X);
            Assert.AreEqual(3, probe.Position.Y);
            Assert.AreEqual(Orientation.East, probe.Position.Orientation);
        }

        [TestMethod]
        public void CommandingProbeTest()
        {
            ServiceConfiguration.ConfigureServices();

            InputInterpreter interpreter = ServiceConfiguration.ServiceProvider.GetService<InputInterpreter>();
            interpreter.Configure("5 5");

            IProbe probe = interpreter.CreateProbe("2 3 E");

            interpreter.CommandProbe(probe, "MMRMRMMLM");

            Assert.AreEqual(2, probe.Position.X);
            Assert.AreEqual(1, probe.Position.Y);
            Assert.AreEqual(Orientation.South, probe.Position.Orientation);
        }
    }
}
