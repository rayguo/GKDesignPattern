using System;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{

	/// <summary>
	/// Represents a sudoko board
	/// </summary>
	public class BasicBoard : Board
	{
		public override event BoardCellUpdateHandler BoardCellUpdate;
        public override event EventHandler<EventArgs> Solved;

		internal struct Cell
		{
			public int		val;
			public bool		readOnly;
			public bool[]	possibleValues;
		}
		
		private int			m_boxWidth;
		private int			m_boxHeight;
		private int			m_cellsPerDimension;
		private Cell[,]		m_board;

		public BasicBoard( int boxWidth , int boxHeight )				  
		{
			m_boxWidth = boxWidth;
			m_boxHeight = boxHeight;

			m_cellsPerDimension = boxWidth * boxHeight;

			m_board = new Cell[ m_cellsPerDimension , m_cellsPerDimension ];


            InitialisePossibleValueStorage();
		}

		public BasicBoard( BoardDescription description ) : this( description.boxWidth , description.boxHeight )
		{
            foreach (BoardDescription.Cell cell in description.layout)
            {
                m_board[cell.x, cell.y].val = cell.val;
                m_board[cell.x, cell.y].readOnly = true;
            }
		}

		public override  int MaxValue
		{
			get
			{
				return m_cellsPerDimension;
			}
		}

        public override int Width
		{
			get { return m_boxWidth; }
		}

        public override int Height
		{
			get { return m_boxHeight; }
		}

        public override bool IsCellWritable(int x, int y)
		{
			ValidateBoardCoordinates( x , y );

			return !m_board[x,y].readOnly;
		}

		// Returns the value at the specific location
        public override int this[int x, int y]
		{
			get
			{
				ValidateBoardCoordinates( x , y );

				return m_board[x , y ].val;
			}
			set
			{
                ValidateSetCellRequest(x, y, value);

                m_board[x, y].possibleValues = new bool[MaxValue - 1];

				m_board[x , y].val  = value;

                OnBoardCellUpdate(new BoardCellUpdateEventArgs(x, y));

                if (HasBeenSolved())
                {
                    OnSolved(EventArgs.Empty);
                }
			}
		}



        public override void MarkPossibleValue(int x, int y, int val)
        {
            SetUnSetPossibleValue(x, y, val,true);
        }

        public override  void UnMarkPossibleValue(int x, int y, int val)
        {
            SetUnSetPossibleValue(x, y, val,false);
        }

        public override bool IsPossibleMarkedValue(int x, int y, int val)
        {
            return m_board[x, y].possibleValues[val - 1];
        }


        public override IEnumerable<int> MarkedPossibleValues(int x, int y)
        {
            if (m_board[x, y].possibleValues == null)
            {
                yield break;
            }

            for (int nPossibleValue = 0; nPossibleValue < m_board[x, y].possibleValues.Length; nPossibleValue++)
            {
                if (m_board[x, y].possibleValues[nPossibleValue])
                {
                    yield return nPossibleValue + 1;
                }
            }
        }

        public override bool IsSolved
        {
            get { return HasBeenSolved(); }
        }

        protected virtual void OnBoardCellUpdate(BoardCellUpdateEventArgs eventArgs)
        {
            if (BoardCellUpdate != null)
            {
                BoardCellUpdate(this, eventArgs);
            }
        }

        protected virtual void OnSolved(EventArgs eventArgs)
        {
            if (Solved != null)
            {
                Solved(this, eventArgs);
            }
        }

        private void ValidateSetCellRequest(int x, int y, int value)
        {
            ValidateBoardCoordinates(x, y);

            if (IsCellWritable(x, y) == false)
            {
                throw new ArgumentException("Cell is not writable", "x,y");
            }

            if ((value > MaxValue) || (value < 0))
            {
                throw new ArgumentOutOfRangeException("value", value, "Must be less than " + MaxValue);
            }
        }


        private void SetUnSetPossibleValue(int x, int y, int val, bool setting)
        {
            ValidateSetCellRequest(x, y, val);

            if (m_board[x, y].possibleValues == null)
            {
                m_board[x, y].possibleValues = new bool[MaxValue];
            }

            m_board[x, y].possibleValues[val - 1] = setting;

            OnBoardCellUpdate(new BoardCellUpdateEventArgs(x, y));

        }
		
		private void ValidateBoardCoordinates( int x , int y )
		{
			if (( x < 0 ) || ( x >= m_cellsPerDimension ))
			{
				throw new ArgumentOutOfRangeException( "x" , x , "Must be less than " + m_cellsPerDimension+1 );
			}

			if (( y < 0 ) || ( y >= m_cellsPerDimension ))
			{
				throw new ArgumentOutOfRangeException( "y" , y , "Must be less than " + m_cellsPerDimension+1 );
			}
		}


        private bool HasBeenSolved()
        {
            if (ValidateRowColumns() == false)
            {
                return false;
            }

           
            return ValidateBlocks();

        }

        private bool ValidateRowColumns()
        {
            for (int nColumn = 0; nColumn < m_cellsPerDimension; nColumn++)
            {
                int columnValsFound = 0;
                int rowValsFound = 0;

                for (int nRow = 0; nRow < m_cellsPerDimension; nRow++)
                {
                    if (m_board[nColumn, nRow].val > 0)
                    {
                        columnValsFound |= 1 << (m_board[nColumn, nRow].val - 1);
                    }

                    if (m_board[nRow, nColumn].val > 0)
                    {
                        rowValsFound |= 1 << (m_board[nRow, nColumn].val - 1);
                    }
                }

                if ((  columnValsFound != (1 << MaxValue) - 1) ||
                    ( rowValsFound != (1 << MaxValue) - 1) )
                {
                    return false;
                }
            }

            return true;
        }

       

        private bool ValidateBlocks()
        {
            for (int nBlockColumn = 0; nBlockColumn < m_boxWidth; nBlockColumn++)
            {
                for (int nBlockRow = 0; nBlockRow < m_boxHeight; nBlockRow++)
                {
                    int valsFoundMask = 0;

                    foreach (int val in ValuesInBlock(nBlockColumn, nBlockRow))
                    {
                        if (val > 0)
                        {
                            valsFoundMask |= 1 << (val - 1);
                        }
                    }

                    if (valsFoundMask != (1 << MaxValue) - 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private IEnumerable<int> ValuesInBlock(int x, int y)
        {
            int startColumn = x * m_boxWidth;
            int startRow = y * m_boxHeight;

            for (int nCol = 0; nCol < m_boxWidth; nCol++)
            {
                for (int nRow = 0; nRow < m_boxHeight; nRow++)
                {
                    yield return m_board[startColumn + nCol, startRow + nRow].val;
                }
            }
        }
		

        private void InitialisePossibleValueStorage()
        {
            for (int nColumn = 0; nColumn < m_cellsPerDimension; nColumn++)
            {
                for (int nRow = 0; nRow < m_cellsPerDimension; nRow++)
                {
                    m_board[nColumn, nRow].possibleValues = new bool[m_cellsPerDimension];
                }
            }
        }
	}
}
