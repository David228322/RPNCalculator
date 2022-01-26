using BLL;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<StartApp>().UserInput();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRPNExpressionCalculator, RPNExpressionCalculator>();
            services.AddScoped<StartApp>();
        }
    }
}
