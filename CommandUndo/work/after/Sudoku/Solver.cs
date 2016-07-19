using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public abstract class Solver
    {
        protected Board board;

        public Solver(Board board)
        {
            this.board = board;
        }

        public abstract void Solve();
        public abstract void Assist();
     
    }
}
