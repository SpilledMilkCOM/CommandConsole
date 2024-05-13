namespace Commands.Interfaces {

    public interface IAnimatedTextCommand : ICommand {

        int Column { get; set; }

        double ColumnsPerSecond { get; set; }

        List<string> Frames { get; }

        double FramesPerSecond { get; set; }

        double RowsPerSecond { get; set; }

        int Row { get; set; }

        string Text { get; set; }
    }
}