using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain.Abstractions
{
    public interface ISystemConfiguration
    {
        ILand Land { get; }
    }
}
