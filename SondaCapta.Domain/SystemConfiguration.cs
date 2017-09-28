using SondaCapta.Domain.Abstractions;

namespace SondaCapta.Domain
{
    internal class SystemConfiguration : ISystemConfiguration
    {
        public SystemConfiguration(ILand land)
        {
            Land = land;
        }

        public ILand Land { get; private set; }
    }
}
