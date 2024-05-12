using Commands.Interfaces;
using ConsoleOutput;
using Microsoft.Extensions.DependencyInjection;

namespace Commands {

    public static class ExtensionOfIServiceCollection {

        public static IServiceCollection AddCommands(this IServiceCollection services) {

            services.AddTransient<IAnimatedTextCommand, AnimatedTextCommand>();
            services.AddTransient<IDelayCommand, DelayCommand>();
            services.AddTransient<ILoopCounterCommand, LoopCounterCommand>();

            services.AddConsoleOutput();

            return services;
        }
    }
}