namespace Commands.Interfaces {

    public interface IDelayCommand : ICommand {

        int DelayInMilliseconds { get; set; }
    }
}