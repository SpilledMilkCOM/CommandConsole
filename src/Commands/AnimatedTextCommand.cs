using Commands.Interfaces;
using ConsoleOutput.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Commands {

    internal class AnimatedTextCommand : IAnimatedTextCommand {

        private readonly IConsoleText _text;
        private readonly List<string> _frames;

        private int _currentFrame;

        // The last time things were changed.

        private DateTime _lastColumn;
        private DateTime _lastFrame;
        private DateTime _lastRow;

        public AnimatedTextCommand(IConsoleText text) {
            _frames = new List<string>();
            _lastColumn = DateTime.MinValue;
            _lastFrame = DateTime.MinValue;
            _lastRow = DateTime.MinValue;
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public int Column { get { return _text.Column; } set { _text.Column = value; } }

        public double ColumnsPerSecond { get; set; }

        public List<string> Frames => _frames;

        public double FramesPerSecond { get; set; }

        public int Row { get { return _text.Row; } set { _text.Row = value; } }

        public double RowsPerSecond { get; set; }

        public string Text {
            get {
                return _frames[_currentFrame];
            }
            set {
                _frames.Clear();
                _frames.Add(value);
            }
        }

        public Task<bool> ExecuteAsync() {

            DateTime now = DateTime.Now;

            // TODO: collapse this stuff into a method

            if (_lastFrame == DateTime.MinValue) {
                _text.Text = _frames[_currentFrame];

                _lastFrame = now;

                _text.Write();
            } else {
                int frames = (int)(now.Subtract(_lastFrame).TotalMilliseconds / 1000 * FramesPerSecond);

                if (Math.Abs(frames) > 0) {
                    _currentFrame += frames;
                    _currentFrame %= _frames.Count;

                    _text.Text = _frames[_currentFrame];

                    _lastFrame = now;

                    _text.Write();
                }
            }

            var oldColumn = _text.Column;
            var oldRow = _text.Row;

            // If the text is moving, then you have to "move" it from the current spot, you can't just write the frame.
            // This will "erase" the old position.

            if (_lastColumn == DateTime.MinValue) {

                _lastColumn = now;
            } else {
                int columns = (int)(now.Subtract(_lastColumn).TotalMilliseconds / 1000 * ColumnsPerSecond);

                if (Math.Abs(columns) > 0) {
                    _text.Column += columns;

                    _lastColumn = now;
                }
            }

            if (_lastRow == DateTime.MinValue) {

                _lastRow = now;
            } else {
                int rows = (int)(now.Subtract(_lastRow).TotalMilliseconds / 1000 * RowsPerSecond);

                if (Math.Abs(rows) > 0) {
                    _text.Row += rows;

                    _lastRow = now;
                }
            }

            if ((oldColumn != _text.Column || oldRow != _text.Row)
            && Column >= 0
            && Row >= 0) {
                // If the position has changed, then move it.

                Console.MoveBufferArea(oldColumn, oldRow, _text.Text.Length, 1, Column, Row);
            }

            return Task.FromResult(true);
        }
    }
}