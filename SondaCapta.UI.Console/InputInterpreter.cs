using System;
using System.Collections.Generic;
using System.Text;
using SondaCapta.Domain.Abstractions;

namespace SondaCapta.UI.Console
{
    public class InputInterpreter
    {
        private ISystemConfigurationProvider _configProvider;
        private ILandFactory _landFactory;
        private IProbeFactory _probeFactory;

        public InputInterpreter(ISystemConfigurationProvider configurationProvider, ILandFactory landFactory, IProbeFactory probeFactory)
        {
            _configProvider = configurationProvider;
            _landFactory = landFactory;
            _probeFactory = probeFactory;
        }

        public void Configure(string configurationString)
        {
            throw new NotImplementedException();
        }

        public IProbe CreateProbe(string creationProbeString)
        {
            throw new NotImplementedException();
        }

        public void CommandProbe(IProbe probe, string v)
        {
            throw new NotImplementedException();
        }
    }
}
