using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern;

namespace Sudoku
{
    public class UndoRedoBoardDecorator : BoardDecorator
    {
        private UndoRedoInvoker invoker;

        public UndoRedoBoardDecorator(Board board) : base(board)
        {
            invoker = new UndoRedoInvoker();
        }

        public override int this[int x, int y]
        {
            get
            {
                // no need to wrap this in a command
                // has it does not change state.
                return base[x, y];
            }
            set
            {
                SetCellCommand cmd = new SetCellCommand(wrappedBoard, x, y, value);

                invoker.Execute(cmd);
            }
        }

        public override void MarkPossibleValue(int x, int y, int val)
        {
            MarkPossibleValueCommand cmd = new MarkPossibleValueCommand(wrappedBoard, x, y, val);

            invoker.Execute(cmd);
        }

        public override void UnMarkPossibleValue(int x, int y, int val)
        {
            UnMarkPossibleValueCommand cmd = new UnMarkPossibleValueCommand(wrappedBoard, x, y, val);

            invoker.Execute(cmd);
        }

        public void UndoLastStep()
        {
            if (invoker.HasCommandsToUndo)
            {
                invoker.UndoLastCommand();
            }
        }

        public void RedoLastUndo()
        {
            if (invoker.HasCommandsToRedo)
            {
                invoker.RedoLastUndo();
            }
        }
    }
}
