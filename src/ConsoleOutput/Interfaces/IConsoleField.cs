namespace ConsoleOutput.Interfaces {

    public interface IConsoleField {

        int Column { get; set; }

        int Row { get; set; }

        string Text { get; set; }

        /// <summary>
        /// Writes the output
        /// </summary>
        void Write();
    }
}