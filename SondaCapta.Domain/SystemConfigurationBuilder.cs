using SondaCapta.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain
{
    internal class SystemConfigurationBuilder : ISystemConfigurationBuilder
    {
        private SystemConfigurationProvider _configProvider;
        private ILand _land = null;
        private object _configLock = new object();

        public SystemConfigurationBuilder(SystemConfigurationProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public event EventHandler<ISystemConfiguration> ConfigurationBuilded;

        public ISystemConfiguration Build()
        {
            if (_configProvider.IsConfigured)
                throw new InvalidOperationException("System is already configured");

            lock (_configLock)
            {
                if (_configProvider.IsConfigured)
                    throw new InvalidOperationException("System is already configured");

                if (_land == null)
                    throw new InvalidOperationException("Land is mandatory to build this configuration");

                SystemConfiguration result = new SystemConfiguration(_land);

                ConfigurationBuilded(this, result);

                return result;
            }
        }

        public ISystemConfigurationBuilder SetLand(ILand land)
        {
            _land = land;
            return this;
        }
    }
}
