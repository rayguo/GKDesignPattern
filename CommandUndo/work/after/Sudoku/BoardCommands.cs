using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern;

namespace Sudoku
{
    class SetCellCommand : Command
    {
        private Board target;
        private int x;
        private int y;
        private int val;

        private int prevVal;
        private List<int> possibleMarkedValues;

        public SetCellCommand(Board board , int x , int y , int val)
        {
            target = board;
            this.x = x;
            this.y = y;
            this.val = val;
        }

        public override void Execute()
        {
            prevVal = target[x, y];

            if (prevVal == Board.EMPTY_CELL)
            {
                possibleMarkedValues = new List<int>(target.MarkedPossibleValues(x, y));
            }

            target[x, y] = val;
        }

        public override void Undo()
        {
            target[x, y] = prevVal;

            if (prevVal == 0)
            {
                foreach (int possibleValue in possibleMarkedValues)
                {
                    target.MarkPossibleValue(x, y, possibleValue);
                }
            }
        }
    }

    class MarkPossibleValueCommand : Command
    {
        private Board target;
        private int x;
        private int y;
        private int val;

        private bool? prevValue;

        public MarkPossibleValueCommand(Board board , int x , int y, int val)
        {
            target = board;
            this.x = x;
            this.y = y;
            this.val = val;

        }

        public override void Execute()
        {
            if (target.IsPossibleMarkedValue(x, y, val) == false)
            {
                prevValue = false;
                target.MarkPossibleValue(x, y, val);
            }
        }

        public override void Undo()
        {
            if (prevValue != null)
            {
                target.UnMarkPossibleValue(x, y, val);
            }
        }
    }

    class UnMarkPossibleValueCommand : Command
    {
        private Board target;
        private int x;
        private int y;
        private int val;

        private bool? prevValue;

        public UnMarkPossibleValueCommand(Board board, int x, int y, int val)
        {
            target = board;
            this.x = x;
            this.y = y;
            this.val = val;

        }

        public override void Execute()
        {
            if (target.IsPossibleMarkedValue(x, y, val) == true)
            {
                prevValue = true;
                target.UnMarkPossibleValue(x, y, val);
            }
        }

        public override void Undo()
        {
            if (prevValue != null)
            {
                target.MarkPossibleValue(x, y, val);
            }
        }
    }
}
