using System;
using System.Collections.Generic;
using System.Text;
using SondaCapta.Domain.Abstractions;
using SondaCapta.Common;

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
            string[] splited = configurationString.Split(' ');

            if (splited.Length != 2)
                throw new ArgumentException("Invalid string format", nameof(configurationString));

            int maxX;
            int maxY;

            if (!int.TryParse(splited[0], out maxX) || !int.TryParse(splited[1], out maxY))
                throw new ArgumentException("Both numbers must be an integer");

            ILand land = _landFactory.CreateRectangularLand(maxX, 0, maxY, 0);
            _configProvider.ConfigurationBuilder.SetLand(land).Build();
        }

        public IProbe CreateProbe(string creationProbeString)
        {
            string[] splited = creationProbeString.Split(' ');

            if (splited.Length != 3)
                throw new ArgumentException("Invalid string format", nameof(creationProbeString));

            int x;
            int y;
            Orientation orientation;

            if (!int.TryParse(splited[0], out x) || !int.TryParse(splited[1], out y) || !TryParseOrientation(splited[2], out orientation))
                throw new ArgumentException("Invalid creation probe string", nameof(creationProbeString));

            return _probeFactory.CreateProbe(new Position(x, y, orientation));
        }

        public void CommandProbe(IProbe probe, string commandString)
        {
            foreach (char singleCommand in commandString)
            {
                SingleCommandProbe(probe, singleCommand);
            }
        }

        private void SingleCommandProbe(IProbe probe, char singleCommand)
        {
            switch (singleCommand)
            {
                case 'M':
                    probe.Move();
                    break;
                case 'L':
                    probe.TurnLeft();
                    break;
                case 'R':
                    probe.TurnRight();
                    break;
                default:
                    throw new ArgumentException($"{singleCommand} is not a valid command");
            }
        }

        private bool TryParseOrientation(string s, out Orientation orientation)
        {
            switch (s.ToUpper())
            {
                case "N":
                    orientation = Orientation.North;
                    return true;
                case "S":
                    orientation = Orientation.South;
                    return true;
                case "E":
                    orientation = Orientation.East;
                    return true;
                case "W":
                    orientation = Orientation.West;
                    return true;
                default:
                    orientation = default(Orientation);
                    return false;
            }
        }
    }
}
