using CommandConsole.Interaces;
using Commands.Interfaces;

namespace CommandConsole {

    internal class MasterControlProgram : IMasterControlProgram {

        private readonly List<ICommand> _commands;

        public MasterControlProgram() {
            _commands = new List<ICommand>();
            IsRunning = true;
        }

        public bool IsRunning { get; set; }

        public void AddCommand(ICommand command) {
            _commands.Add(command);
        }

        public async Task<bool> ExecuteAsync() {

            var result = true;

            // TODO: Run these in parallel
            // TODO: Need a CancellationToken

            while (IsRunning) {

                foreach (var command in _commands) {
                    IsRunning = await command.ExecuteAsync();

                    if (!IsRunning) {
                        break;
                    }
                }
            }

            return result;
        }
    }
}