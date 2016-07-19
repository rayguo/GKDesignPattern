using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public abstract class Command
    {
        public abstract void Execute();

        public virtual void Undo()
        {
            throw new NotImplementedException("Undo not supported");
        }
    }
}
