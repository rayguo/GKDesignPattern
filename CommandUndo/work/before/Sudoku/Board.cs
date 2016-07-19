using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public delegate void BoardCellUpdateHandler(object sender, BoardCellUpdateEventArgs eventArgs);

    public abstract class Board
    {
        public abstract event BoardCellUpdateHandler BoardCellUpdate;
        public abstract event EventHandler<EventArgs> Solved;

        public abstract int MaxValue { get; }
 
        public abstract int Width { get; }
        public abstract int Height {get;}

        public abstract bool IsCellWritable(int x, int y);
        public abstract int this[int x, int y] { get;set; }
                 
        public abstract void MarkPossibleValue(int x, int y, int val);
        public abstract void UnMarkPossibleValue(int x, int y, int val);
        public abstract bool IsPossibleMarkedValue(int x, int y, int val);
        public abstract IEnumerable<int> MarkedPossibleValues(int x, int y);
       
        public abstract  bool IsSolved { get; }
    }
}
