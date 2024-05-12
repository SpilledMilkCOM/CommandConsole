using Commands.Interfaces;

namespace CommandConsole.Interaces {

    internal interface IAnimatedTextCommand : ICommand {

        double ColumnsPerSecond { get; set; }

        double RowsPerSecond { get; set; }

        string Test {  get; set; }
    }
}