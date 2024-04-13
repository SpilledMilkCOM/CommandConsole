namespace CommandConsole {

    internal class ConsoleDimensions {

        public ConsoleDimensions() { }

        public void Write() {

            var width = Console.WindowWidth;
            var height = Console.WindowHeight;

            // Check previous values to prevent flashing.

            var message = $"{width}x{height}";
            var messageHeight = 1;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);

            // Assuming the cursor is at 0,0

            Console.MoveBufferArea(0, 0, message.Length, messageHeight, width - message.Length, height - messageHeight);

            // Move the cursor back to where it was.

            var backspaces = new string('\b', message.Length);
            Console.Write(backspaces);
        }
    }
}