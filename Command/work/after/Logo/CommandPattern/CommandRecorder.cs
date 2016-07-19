using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class CommandRecorder
    {
        private List<Command> commands = new List<Command>();

        public void Execute(Command command)
        {
            command.Execute();

            commands.Add(command);
        }

        public bool IsEmpty { get { return commands.Count == 0; } }

        public void DeleteLastCommand()
        {
            if (commands.Count > 0)
            {
                commands.RemoveAt(commands.Count - 1);
            }
        }

        public IEnumerable<Command> GetCommands()
        {
            return commands;
        }
    }
}
