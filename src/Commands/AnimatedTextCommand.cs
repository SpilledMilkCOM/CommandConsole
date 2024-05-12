using Commands.Interfaces;
using ConsoleOutput.Interfaces;

namespace Commands {

    internal class AnimatedTextCommand : IAnimatedTextCommand {

        private readonly IConsoleText _text;
        private readonly List<string> _frames;

        private int _currentFrame;
        private DateTime _lastFrame;

        public AnimatedTextCommand(IConsoleText text) {
            _frames = new List<string>();
            _lastFrame = DateTime.MinValue;
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public int Column { get { return _text.Column; } set { _text.Column = value; } }

        public List<string> Frames => _frames;

        public int FramesPerSecond { get; set; }

        public int Row { get { return _text.Row; } set { _text.Row = value; } }

        public Task<bool> ExecuteAsync() {

            DateTime now = DateTime.Now;

            if (_lastFrame == DateTime.MinValue) {
                _text.Text = _frames[_currentFrame];

                _lastFrame = now;
            } else {
               int frames = (int)now.Subtract(_lastFrame).TotalMilliseconds / 1000 * FramesPerSecond;

                if (frames > 0) {
                    _currentFrame += frames;
                    _currentFrame = (_currentFrame + 1) % _frames.Count;

                    _text.Text = _frames[_currentFrame];

                    _lastFrame = now;
                }
            }

            _text.Write();

            return Task.FromResult(true);
        }
    }
}