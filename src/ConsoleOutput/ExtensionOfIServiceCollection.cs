using CommandConsole;
using ConsoleOutput.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleOutput {

    public static class ExtensionOfIServiceCollection {

        public static IServiceCollection AddConsoleOutput(this IServiceCollection services) {

            services.AddTransient<IConsoleText, ConsoleText>();

            return services;
        }
    }
}