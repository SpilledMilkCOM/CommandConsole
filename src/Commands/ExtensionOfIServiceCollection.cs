using Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Commands {

    public static class ExtensionOfIServiceCollection {

        public static IServiceCollection AddCommands(this IServiceCollection services) {

            services.AddTransient<IDelayCommand, DelayCommand>();

            return services;
        }
    }
}