using SondaCapta.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain
{
    internal class SystemConfiguration : ISystemConfiguration
    {
        public SystemConfiguration(ILand land)
        {
            Land = land;
        }

        public ILand Land { get; private set; }
    }
}
