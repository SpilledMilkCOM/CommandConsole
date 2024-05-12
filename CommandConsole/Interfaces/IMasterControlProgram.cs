using Commands.Interfaces;

namespace CommandConsole.Interfaces {

    internal interface IMasterControlProgram : ICommand {

        bool IsRunning { get; set; }

        void AddCommand(ICommand command);
    }
}