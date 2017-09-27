using SondaCapta.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain.Abstractions
{
    public interface IProbeFactory
    {
        IProbe CreateProbe(Position position);
    }
}
