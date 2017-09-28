using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Common
{
    public static class OrientationExtension
    {
        public static Orientation TurnLeft(this Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.North:
                    return Orientation.West;
                case Orientation.West:
                    return Orientation.South;
                case Orientation.South:
                    return Orientation.East;
                case Orientation.East:
                    return Orientation.North;
                default:
                    throw new NotImplementedException("Orientation not implemented");
            }
        }

        public static Orientation TurnRight(this Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.North:
                    return Orientation.East;
                case Orientation.East:
                    return Orientation.South;
                case Orientation.South:
                    return Orientation.West;
                case Orientation.West:
                    return Orientation.North;
                default:
                    throw new NotImplementedException("Orientation not implemented");
            }
        }
    }
}
