using Commands.Interfaces;

namespace CommandConsole.Interaces {

    internal interface IMasterControlProgram : ICommand {

        bool IsRunning { get; set; }

        void AddCommand(ICommand command);
    }
}