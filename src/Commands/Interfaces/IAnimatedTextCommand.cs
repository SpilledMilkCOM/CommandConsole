namespace Commands.Interfaces {

    public interface IAnimatedTextCommand : ICommand {

        int Column { get; set; }

        List<string> Frames { get; }

        int FramesPerSecond { get; set; }

        int Row { get; set; }
    }
}