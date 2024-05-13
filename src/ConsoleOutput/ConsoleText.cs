using ConsoleOutput.Interfaces;

namespace CommandConsole {

    public class ConsoleText : IConsoleText {

        public ConsoleText() {
            Text = string.Empty;
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public string Text { get; set; }

        public void Write() {

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Text);

            // Move the text

            if (Column >= 0 && Row >= 0) {
                Console.MoveBufferArea(0, 0, Text.Length, 1, Column, Row);
            }

            // Move cursor back to 0,0

            var backspaces = new string('\b', Text.Length);
            Console.Write(backspaces);
        }
    }
}
