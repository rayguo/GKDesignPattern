using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class UndoInvoker
    {
        private Stack<Command> history = new Stack<Command>();

        public void Execute(Command command)
        {
            command.Execute();

            history.Push(command);
        }

        public void UndoLast()
        {
            Command cmd= history.Pop();

            cmd.Undo();
        }
    }
}
