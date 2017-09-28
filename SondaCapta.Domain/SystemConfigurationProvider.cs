using SondaCapta.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain
{
    public class SystemConfigurationProvider : ISystemConfigurationProvider
    {
        public ISystemConfigurationBuilder ConfigurationBuilder => throw new NotImplementedException();

        public bool IsConfigured => throw new NotImplementedException();

        public ISystemConfiguration Configuration => throw new NotImplementedException();
    }
}
