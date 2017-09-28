using SondaCapta.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using SondaCapta.Common;

namespace SondaCapta.Domain
{
    public class ProbeFactory : IProbeFactory
    {
        private ISystemConfiguration _config;

        public ProbeFactory(ISystemConfiguration configuration)
        {
            _config = configuration;
        }

        public IProbe CreateProbe(Position position)
        {
            return new Probe(_config.Land, position);
        }
    }
}
