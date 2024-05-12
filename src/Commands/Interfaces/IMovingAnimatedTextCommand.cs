using Commands.Interfaces;

namespace CommandConsole.Interaces {

    internal interface IMovingAnimatedTextCommand : ICommand {

        double ColumnsPerSecond { get; set; }

        double RowsPerSecond { get; set; }

        string Text {  get; set; }
    }
}