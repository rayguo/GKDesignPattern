using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sudoku
{
    public sealed class BasicSolver : Solver
    {
        public BasicSolver(Board board) : base(board)
        {
            this.board = board;
        }

        public override void Assist()
        {
            for (int nColumn = 0; nColumn < board.MaxValue; nColumn++)
            {
                for (int nRow = 0; nRow < board.MaxValue; nRow++)
                {
                    if (board[nColumn, nRow] == 0)
                    {
                        ComputeAndMarkPossibleValues(nColumn, nRow);
                    }
                }
            }
        }

        public override void Solve()
        {
            while (board.IsSolved == false)
            {
                bool progressMade = false;

                progressMade |= ForeachCellTry(TrySinglePossibleValue);
                progressMade |= ForeachCellTry(DetermineValueUsingBoxConstraints);
                progressMade |= ForeachCellTry(TryIsUniqueColumnValue);
                progressMade |= ForeachCellTry(TryIsUniqueRowValue);

                if ( progressMade == false )
                {
                    // This algo can't solve it...
                    return;
                }

                
            }
        }

        delegate bool SolveBehaviour(int nColumn , int nRow );
       

        private bool ForeachCellTry(SolveBehaviour behaviour)
        {
            bool success = false;

            for (int nColumn = 0; nColumn < board.MaxValue; nColumn++)
            {
                for (int nRow = 0; nRow < board.MaxValue; nRow++)
                {
                    if (board[nColumn, nRow] == 0)
                    {
                        ComputeAndMarkPossibleValues(nColumn, nRow);

                        success |= behaviour(nColumn, nRow);
                    }
                }
            }

            return success;
        }

        private bool TrySinglePossibleValue(int nColumn, int nRow)
        {
            ComputeAndMarkPossibleValues(nColumn, nRow);


           List<int> possibleValues = new List<int>(board.MarkedPossibleValues(nColumn, nRow));

            if (possibleValues.Count == 1)
            {
                board[nColumn, nRow] = possibleValues[0];
                return true;
            }
            
            return false;
        }

        private bool DetermineValueUsingBoxConstraints(int nColumn, int nRow)
        {
            int boxColumn = nColumn / board.Width;
            int boxRow = nRow / board.Height;

            foreach (int val in board.MarkedPossibleValues(nColumn, nRow))
            {
                if (NumberOfPossiblePlacesInBox(val, boxColumn, boxRow) == 1)
                {
                    board[nColumn, nRow] = val;
                    return true;
                }
            }

            return false;
        }

        private bool TryIsUniqueColumnValue(int column, int row)
        {
            List<int> otherCellsPossibleValues = new List<int>();
           
            for (int nRow = 0; nRow < board.MaxValue ; nRow++)
            {
                if ( nRow != row )
                {
                    otherCellsPossibleValues.AddRange( board.MarkedPossibleValues(column, nRow));
                }
            }

            List<int> thisCellsPossibleValueSet = new List<int>(board.MarkedPossibleValues(column, row));

            List<int> uniqueValues = SubtractList( thisCellsPossibleValueSet , otherCellsPossibleValues );

            if ( uniqueValues.Count == 1 )
            {
                board[column,row] = uniqueValues[0];
                return true;
            }

            return false;
        }

        private bool TryIsUniqueRowValue(int column, int row)
        {
            List<int> otherCellsPossibleValues = new List<int>();

            for (int nColumn = 0; nColumn < board.MaxValue; nColumn++)
            {
                if (nColumn != column)
                {
                    otherCellsPossibleValues.AddRange(board.MarkedPossibleValues(nColumn, row));
                }
            }

            List<int> thisCellsPossibleValueSet = new List<int>(board.MarkedPossibleValues(column, row));

            List<int> uniqueValues = SubtractList(thisCellsPossibleValueSet, otherCellsPossibleValues);

            if (uniqueValues.Count == 1)
            {
                board[column, row] = uniqueValues[0];
                return true;
            }

            return false;
        }

        private List<int> SubtractList(List<int> lhsList, List<int> rhsList)
        {
            List<int> result = new List<int>();

            foreach (int val in lhsList)
            {
                if (rhsList.Contains(val) == false )
                {
                    result.Add(val);
                }
            }

            return result;
        }

        private void ComputeAndMarkPossibleValues(int nColumn, int nRow)
        {
            foreach (int possible in board.MarkedPossibleValues(nColumn, nRow))
            {
                board.UnMarkPossibleValue(nColumn, nRow, possible);
            }

            for (int valueToTry = 1; valueToTry <= board.MaxValue; valueToTry++)
            {
                if (IsPossibleValue(nColumn, nRow, valueToTry))
                {
                    board.MarkPossibleValue(nColumn, nRow, valueToTry);
                }
            }
        }

        public bool IsPossibleValue(int column, int row, int val)
        {
            for (int nRow = 0; nRow < board.MaxValue; nRow++)
            {
                if (board[column, nRow] == val)
                {
                    return false;
                }
            }

            for (int nColumn = 0; nColumn < board.MaxValue; nColumn++)
            {
                if (board[nColumn, row] == val)
                {
                    return false;
                }
            }

            // integer maths means we re-align on the block boundaries
            int blockStartColumn = (column / board.Width) * board.Width;
            int blockStartRow = (row / board.Height) * board.Height;

            for (int nColumn = 0; nColumn < board.Width; nColumn++)
            {
                for (int nRow = 0; nRow < board.Height; nRow++)
                {
                    if (board[nColumn + blockStartColumn, nRow + blockStartRow] == val)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int NumberOfPossiblePlacesInBox(int val, int boxColumn, int boxRow)
        {
            int nPossiblePlaces = 0;
            int blockStartColumn = boxColumn * board.Width;
            int blockStartRow = boxRow * board.Height;

            for (int nColumn = 0; nColumn < board.Width; nColumn++)
            {
                for (int nRow = 0; nRow < board.Height; nRow++)
                {
                    if (board[nColumn + blockStartColumn, nRow + blockStartRow] == 0)
                    {
                        if (IsPossibleValue(nColumn + blockStartColumn, nRow + blockStartRow, val))
                        {
                            nPossiblePlaces++;
                        }
                    }
                }
            }

            return nPossiblePlaces;
        }
    }
}
