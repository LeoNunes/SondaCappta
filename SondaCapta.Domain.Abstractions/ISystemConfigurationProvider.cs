using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain.Abstractions
{
    public interface ISystemConfigurationProvider
    {
        ISystemConfigurationBuilder ConfigurationBuilder { get; }

        bool IsConfigured { get; }
        ISystemConfiguration Configuration { get; }
    }
}
