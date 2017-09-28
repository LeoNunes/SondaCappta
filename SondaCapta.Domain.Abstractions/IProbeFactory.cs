using SondaCapta.Common;

namespace SondaCapta.Domain.Abstractions
{
    public interface IProbeFactory
    {
        IProbe CreateProbe(Position position);
    }
}
