using SondaCapta.Common;

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
