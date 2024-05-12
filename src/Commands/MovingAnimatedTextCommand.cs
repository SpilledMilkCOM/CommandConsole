using CommandConsole.Interaces;
using ConsoleOutput.Interfaces;

namespace Commands {

    public class MovingAnimatedTextCommand : IMovingAnimatedTextCommand {

        private readonly IConsoleText _text;
        private DateTime _lastFrame;

        public MovingAnimatedTextCommand(IConsoleText text) {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public double ColumnsPerSecond { get; set; }

        public double RowsPerSecond { get; set; }

        public string Text { get; set; }

        public Task<bool> ExecuteAsync() {

            // How much time has elapsed since last called?

            DateTime now = DateTime.Now;



            return Task.FromResult(true);
        }
    }
}