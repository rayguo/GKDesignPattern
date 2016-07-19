using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CommandPattern
{
    public class UndoRedoInvoker
    {
        private Stack<Command> commandsToUndo = new Stack<Command>();
        private Stack<Command> commandsToRedo = new Stack<Command>();

        public void Execute(Command command)
        {
            commandsToRedo.Clear();

            command.Execute();
            commandsToUndo.Push(command);
        }

        public bool HasCommandsToUndo
        {
            get { return commandsToUndo.Count > 0; }
        }

        public void UndoLastCommand()
        {
            Command cmd = commandsToUndo.Pop();

            cmd.Undo();

            commandsToRedo.Push(cmd);
        }

        public bool HasCommandsToRedo
        {
            get { return commandsToRedo.Count > 0; }
        }

        public void RedoLastUndo()
        {
            Command cmd = commandsToRedo.Pop();

            cmd.Execute();

            commandsToUndo.Push(cmd);

        }
    }
}
