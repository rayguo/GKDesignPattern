using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class BoardDecorator : Board
    {
        protected Board wrappedBoard;

        public BoardDecorator(Board board)
        {
            this.wrappedBoard = board;
        }

        public override event BoardCellUpdateHandler BoardCellUpdate
        {
            add { wrappedBoard.BoardCellUpdate += value; }
            remove { wrappedBoard.BoardCellUpdate -= value; }
        }

        public override event EventHandler<EventArgs> Solved
        {
            add { wrappedBoard.Solved += value; }
            remove { wrappedBoard.Solved -= value; }
        }

        public override int MaxValue
        {
            get { return wrappedBoard.MaxValue; }
        }

        public override int Width
        {
            get { return wrappedBoard.Width; }
        }

        public override int Height
        {
            get { return wrappedBoard.Height; }
        }

        public override bool IsCellWritable(int x, int y)
        {
            return wrappedBoard.IsCellWritable(x, y);
        }

        public override int this[int x, int y]
        {
            get
            {
                return wrappedBoard[x, y];
            }
            set
            {
                wrappedBoard[x, y] = value;
            }
        }

        public override void MarkPossibleValue(int x, int y, int val)
        {
            wrappedBoard.MarkPossibleValue(x, y, val);
        }

        public override void UnMarkPossibleValue(int x, int y, int val)
        {
            wrappedBoard.UnMarkPossibleValue(x, y, val);
        }

        public override bool IsPossibleMarkedValue(int x, int y, int val)
       {
           return wrappedBoard.IsPossibleMarkedValue(x, y, val);
        }

        public override IEnumerable<int> MarkedPossibleValues(int x, int y)
        {
            return wrappedBoard.MarkedPossibleValues(x, y);
        }

        public override bool IsSolved
        {
            get { return wrappedBoard.IsSolved;  }
        }
    }
}
