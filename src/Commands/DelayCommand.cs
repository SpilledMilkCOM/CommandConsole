using Commands.Interfaces;

namespace Commands {

    /// <summary>
    /// This is effectively a "mock" command
    /// </summary>
    internal class DelayCommand : IDelayCommand {

        internal DelayCommand() {
            DelayInMilliseconds = 100;
        }

        public int DelayInMilliseconds { get; set; }

        public Task<bool> Execute() {

            Thread.Sleep(DelayInMilliseconds);

            return Task.FromResult(true);
        }
    }
}