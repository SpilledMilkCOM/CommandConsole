namespace Commands.Interfaces {

    public interface ICommand {

        Task<bool> Execute();
    }
}