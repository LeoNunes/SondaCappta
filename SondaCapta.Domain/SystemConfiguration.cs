using SondaCapta.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain
{
    public class SystemConfiguration : ISystemConfiguration
    {
        public ILand Land { get; set; }
    }
}
