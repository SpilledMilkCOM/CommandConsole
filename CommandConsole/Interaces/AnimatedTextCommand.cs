namespace CommandConsole.Interaces {

    internal class AnimatedTextCommand : IAnimatedTextCommand {

        private readonly IConsoleText _text;
        private DateTime _lastFrame;

        public AnimatedTextCommand(IConsoleText text) {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public double ColumnsPerSecond { get; set; }

        public double RowsPerSecond { get; set; }

        public string Test { get; set; }

        public Task<bool> ExecuteAsync() {
            throw new NotImplementedException();
        }
    }
}