using Commands.Interfaces;

namespace Commands {

    /// <summary>
    /// This is effectively a "mock" command
    /// </summary>
    public class DelayCommand : IDelayCommand {

        public DelayCommand() {
            DelayInMilliseconds = 100;
        }

        public int DelayInMilliseconds { get; set; }

        public Task<bool> ExecuteAsync() {

            Thread.Sleep(DelayInMilliseconds);

            return Task.FromResult(true);
        }
    }
}