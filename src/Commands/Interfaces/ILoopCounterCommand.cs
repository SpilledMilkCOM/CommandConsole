namespace Commands.Interfaces {

    public interface ILoopCounterCommand : ICommand {

        int Column { get; set; }

        int Row { get; set; }
    }
}