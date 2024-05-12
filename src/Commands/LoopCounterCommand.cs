using Commands.Interfaces;
using ConsoleOutput.Interfaces;

namespace Commands {

    internal class LoopCounterCommand : ILoopCounterCommand {

        private readonly IConsoleText _text;

        private int _counter;

        public LoopCounterCommand(IConsoleText text) {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public int Column { get { return _text.Column; } set { _text.Column = value; } }

        public int Row { get { return _text.Row; } set { _text.Row = value; } }

        public Task<bool> ExecuteAsync() {

            _text.Text = _counter.ToString();
            _text.Write();

            _counter++;

            return Task.FromResult(true);
        }
    }
}