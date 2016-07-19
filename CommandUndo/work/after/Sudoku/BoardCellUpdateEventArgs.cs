using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class BoardCellUpdateEventArgs : EventArgs
    {
        private int x;
        private int y;
        //private int val;
        //private bool readOnly;
        //private bool[] hints;

        internal BoardCellUpdateEventArgs(int x, int y )
        {
            this.x = x;
            this.y = y;
           // this.val = cell.val;
           // this.readOnly = cell.readOnly;
            
           //this.hints = (bool[])cell.possibleValues.Clone();
            
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }
        //public int Value { get { return val; } }
        //public bool ReadOnly { get { return readOnly; } }
        //public IEnumerable<int> Hints
        //{
        //    get
        //    {
        //        for (int nHintVal = 0; nHintVal < hints.Length; nHintVal++)
        //        {
        //            if (hints[nHintVal] == true)
        //            {
        //                yield return nHintVal + 1;
        //            }
        //        }
        //    }
        //}
    }
}
