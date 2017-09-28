using SondaCapta.Common;
using System;

namespace SondaCapta.Domain.Abstractions
{
    public interface IProbe
    {
        Position Position { get; }
        bool IsCrashed { get; }

        void Move();
        void TurnLeft();
        void TurnRight();
    }
}
