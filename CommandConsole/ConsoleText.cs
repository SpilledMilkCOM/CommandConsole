namespace CommandConsole {

    internal class ConsoleText {

        internal void Write(string message, int row, int col) {

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);

            // Move the text

            Console.MoveBufferArea(0, 0, message.Length, 1, col, row);

            // Move cursor back to 0,0

            var backspaces = new string('\b', message.Length);
            Console.Write(backspaces);
        }
    }
}
