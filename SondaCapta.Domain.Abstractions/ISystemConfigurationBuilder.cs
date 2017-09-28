namespace SondaCapta.Domain.Abstractions
{
    public interface ISystemConfigurationBuilder
    {
        ISystemConfigurationBuilder SetLand(ILand land);

        ISystemConfiguration Build();
    }
}