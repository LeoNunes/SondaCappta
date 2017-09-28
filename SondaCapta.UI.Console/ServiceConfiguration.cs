using Microsoft.Extensions.DependencyInjection;
using SondaCapta.Domain;
using SondaCapta.Domain.Abstractions;
using System;

namespace SondaCapta.UI.Console
{
    public static class ServiceConfiguration
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ISystemConfigurationProvider, SystemConfigurationProvider>();
            serviceCollection.AddSingleton<ILandFactory, LandFactory>();
            serviceCollection.AddSingleton<IProbeFactory, ProbeFactory>();
            serviceCollection.AddSingleton<InputInterpreter>();

            ServiceProvider = serviceCollection.BuildServiceProvider();

        }
    }
}