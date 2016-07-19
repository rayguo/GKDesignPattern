using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class MacroCommand : Command
    {
        private List<Command> commands = new List<Command>();

        public void AddCommand(Command command)
        {
            commands.Add(command);
        }

        public override void Execute()
        {
            foreach (Command command in commands)
            {
                command.Execute();
            }
        }
    }
}
