using SondaCapta.Common;
using System;

namespace SondaCapta.Domain.Abstractions
{
    public interface IProbe
    {
        Position Position { get; }
        void Move();
        void TurnLeft();
        void TurnRight();
    }
}
