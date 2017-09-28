using SondaCapta.Domain.Abstractions;
using System;
using SondaCapta.Common;

namespace SondaCapta.Domain
{
    public class Probe : IProbe
    {
        private ILand _land;

        public Probe(ILand land, Position startPosition)
        {
            _land = land;

            Position = startPosition;

            if (land.IsInside(startPosition.X, startPosition.Y))
                IsCrashed = false;
            else
                IsCrashed = true;
        }

        public Position Position { get; private set; }
        public bool IsCrashed { get; private set; }

        public void Move()
        {
            if (IsCrashed)
                throw new ProbeCrashedException("Probe is crashed");

            switch (Position.Orientation)
            {
                case Orientation.North:
                    Position = new Position(Position.X, Position.Y + 1, Position.Orientation);
                    break;
                case Orientation.South:
                    Position = new Position(Position.X, Position.Y - 1, Position.Orientation);
                    break;
                case Orientation.East:
                    Position = new Position(Position.X + 1, Position.Y, Position.Orientation);
                    break;
                case Orientation.West:
                    Position = new Position(Position.X - 1, Position.Y, Position.Orientation);
                    break;
                default:
                    throw new NotImplementedException("Orientation not implemented");
            }

            if (!_land.IsInside(Position.X, Position.Y))
            {
                IsCrashed = true;
            }
        }

        public void TurnLeft()
        {
            Position = new Position(Position.X, Position.Y, Position.Orientation.TurnLeft());
        }

        public void TurnRight()
        {
            Position = new Position(Position.X, Position.Y, Position.Orientation.TurnRight());
        }
    }
}
