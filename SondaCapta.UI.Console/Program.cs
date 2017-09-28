using Microsoft.Extensions.DependencyInjection;

namespace SondaCapta.UI.Console
{
    class Program
    {
        private static InputInterpreter _interpreter;

        static void Main(string[] args)
        {
            ServiceConfiguration.ConfigureServices();

            ComposeServices();



            System.Console.ReadLine();
        }

        private static void ComposeServices()
        {
            _interpreter = ServiceConfiguration.ServiceProvider.GetService<InputInterpreter>();
        }
    }
}
