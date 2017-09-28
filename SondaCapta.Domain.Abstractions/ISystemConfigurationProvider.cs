namespace SondaCapta.Domain.Abstractions
{
    public interface ISystemConfigurationProvider
    {
        ISystemConfigurationBuilder ConfigurationBuilder { get; }

        bool IsConfigured { get; }
        ISystemConfiguration Configuration { get; }
    }
}
