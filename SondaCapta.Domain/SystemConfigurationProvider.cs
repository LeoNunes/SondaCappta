using SondaCapta.Domain.Abstractions;

namespace SondaCapta.Domain
{
    public class SystemConfigurationProvider : ISystemConfigurationProvider
    {
        public SystemConfigurationProvider()
        {
            SystemConfigurationBuilder builder = new SystemConfigurationBuilder(this);
            builder.ConfigurationBuilded += ConfigurationBuilded;
            ConfigurationBuilder = builder;
        }

        public ISystemConfigurationBuilder ConfigurationBuilder { get; private set; }

        public bool IsConfigured { get; private set; }
        public ISystemConfiguration Configuration { get; private set; }

        private void ConfigurationBuilded(object sender, ISystemConfiguration e)
        {
            IsConfigured = true;
            Configuration = e;
        }
    }
}
