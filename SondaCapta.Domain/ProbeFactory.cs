using SondaCapta.Domain.Abstractions;
using System;
using SondaCapta.Common;

namespace SondaCapta.Domain
{
    public class ProbeFactory : IProbeFactory
    {
        private ISystemConfigurationProvider _configProvider;

        public ProbeFactory(ISystemConfigurationProvider configurationProvider)
        {
            _configProvider = configurationProvider;
        }

        public IProbe CreateProbe(Position position)
        {
            if (!_configProvider.IsConfigured)
                throw new InvalidOperationException("The system must be configured to create a probe");

            return new Probe(_configProvider.Configuration.Land, position);
        }
    }
}
