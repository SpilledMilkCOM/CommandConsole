using CommandConsole.Interfaces;
using Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CommandConsole {

    public static class ExtensionOfIServiceCollection {

        public static IServiceCollection AddCommandConsole(this IServiceCollection services) {

            services.AddTransient<IMasterControlProgram, MasterControlProgram>();

            services.AddCommands();

            return services;
        }
    }
}