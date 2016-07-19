using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sudoku;

namespace WinSudoku
{
    public partial class BoardControl
    {
        public BoardControl()
        {
            InitializeComponent();

            gridControl.CellSelected += CellSelected;
        }

        private TextGrid gridControl;
        private System.Windows.Forms.ContextMenu m_selectValueMenu;
        
        private Color m_oddCellColor = Color.Linen;
        private Color m_evenCellColor = Color.Bisque;
        private Board m_board;

        [Category("Appearance")]
        public Color OddCellColor
        {
            get { return m_oddCellColor; }
            set { m_oddCellColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color EvenCellColor
        {
            get { return m_evenCellColor; }
            set { m_evenCellColor = value; Invalidate(); }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (DesignMode)
            {
                Board board = new BasicBoard(3, 3);

                this.Board = board;

                for (int x = 0; x < board.MaxValue; x++)
                {
                    for (int y = 0; y < board.MaxValue; y++)
                    {
                        board[x, y] = ((x + (y * board.Width)) % board.MaxValue) + 1;
                    }
                }
            }

            base.OnLoad(e);
        }

        public Board Board
        {
            get
            {
                return m_board;
            }
            set
            {
                m_board = value;

                VisualiseBoard(m_board);
            }
        }

        private void VisualiseBoard(Board board)
        {
            gridControl.Columns = board.MaxValue;
            gridControl.Rows = board.MaxValue;


            foreach (TextGrid.Cell cell in gridControl.GetCells())
            {
                int nCell = (cell.Column / board.Width) +
                    (cell.Row / board.Height);

                bool odd = ((nCell & 1) == 1);

                if (odd)
                {
                    cell.BackColor = m_oddCellColor;
                }
                else
                {
                    cell.BackColor = m_evenCellColor;
                }

                cell.Italic = false;
                cell.Bold = !m_board.IsCellWritable(cell.Column, cell.Row);

                UpdateCellText(cell);
            }

            m_board.BoardCellUpdate += new BoardCellUpdateHandler(BoardUpdated);
            m_board.Solved += Solved;

            BuildCellValueMenu();
        }


        private int m_lastSelectedCellX;
        private int m_lastSelectedCellY;

        private void CellSelected(Object sender, CellMouseEventArgs args)
        {
            m_lastSelectedCellX = args.Column;
            m_lastSelectedCellY = args.Row;

            if (m_board.IsCellWritable(args.Column, args.Row))
            {

                if( args.MouseEventArgs.Button == MouseButtons.Left )
                {
                    m_selectValueMenu.Show(this, new Point(args.MouseEventArgs.X, args.MouseEventArgs.Y));
                }

                if ((args.MouseEventArgs.Button == MouseButtons.Right) && ( m_board[args.Column,args.Row] == 0 ))
                {
                    BuildPossibleValuesMenu(args.Column, args.Row).Show(this, new Point(args.MouseEventArgs.X, args.MouseEventArgs.Y));
                }
            }
        }

        private void BoardUpdated(object sender, BoardCellUpdateEventArgs eventArgs)
        {
            UpdateCellText(gridControl[eventArgs.X, eventArgs.Y]);

            gridControl.Invalidate();
        }

        private void UpdateCellText(TextGrid.Cell cell)
        {
            int val = m_board[cell.Column, cell.Row];

            // if no values then display any hints, 
            if (val == 0)
            {
                PopulateCellWithHints(cell);
            }
            else
            {
                PopulateCellWithValue(cell);
            }
        }

        private void PopulateCellWithValue(TextGrid.Cell cell)
        {
            cell.HorizontalAlignment = TextGrid.CellTextHorizontalAlignment.Middle;
            cell.VerticalAlignment = TextGrid.CellTextVerticalAlignment.Middle;
            cell.Italic = false;

            cell.Picture = null;
            cell.Text = m_board[cell.Column,cell.Row].ToString();

            cell.Bold = (m_board.IsCellWritable(cell.Column, cell.Row) == false);
        }

        private void PopulateCellWithHints(TextGrid.Cell cell)
        {
            StringBuilder footer = new StringBuilder();

            foreach (int hint in m_board.MarkedPossibleValues(cell.Column, cell.Row))
            {
                if (footer.Length == 0)
                {
                    footer.Append(hint);
                }
                else
                {
                    footer.Append(String.Format(",{0}", hint));
                }
            }

            cell.Picture = "XXXXXXX";
            cell.VerticalAlignment = TextGrid.CellTextVerticalAlignment.Top;
            cell.HorizontalAlignment = TextGrid.CellTextHorizontalAlignment.Left;

            cell.Italic = true;
            cell.Text = footer.ToString();
        }

        private void BuildCellValueMenu()
        {
            EventHandler itemClickHandler = new EventHandler(CellValueSelected);

            m_selectValueMenu = new ContextMenu();

            m_selectValueMenu.MenuItems.Add(0, new MenuItem("Empty", itemClickHandler));


            for (int nValue = 1; nValue <= m_board.MaxValue; nValue++)
            {
                string itemText = nValue.ToString();

                MenuItem item = new MenuItem(itemText);
                item.Click += itemClickHandler;

                m_selectValueMenu.MenuItems.Add(item);
            }
        }

        private struct PossibleValue
        {
            public PossibleValue(int x , int y , int val)
            {
                this.x = x;
                this.y = y;
                this.val = val;
            }

            private int val;

            public int Val
            {
                get { return val; }
                private set { val = value; }
            }
            private int x;

            public int X
            {
                get { return x; }
                private set { x = value; }
            }
            private int y;

            public int Y
            {
                get { return y; }
                private set { y = value; }
            }
        }

        private ContextMenu BuildPossibleValuesMenu(int column , int row)
        {
            EventHandler markPossibleValueHandler = new EventHandler(MarkPossibleValue);
            EventHandler unMarkPossibleValueHandler = new EventHandler(UnMarkPossibleValue);

            ContextMenu menu = new ContextMenu();

            MenuItem clearAllItem = new MenuItem("Remove All Possible Values");
            clearAllItem.Tag = new PossibleValue(column,row, 0 );
            clearAllItem.Click += ClearAllMarkedItems;

            menu.MenuItems.Add(clearAllItem);

            for (int nValue = 1; nValue <= m_board.MaxValue; nValue++)
            {
               MenuItem item = new MenuItem();

               item.Tag = new PossibleValue(column, row, nValue);

                if (m_board.IsPossibleMarkedValue(column , row , nValue) == false)
                {

                    item.Text = String.Format("Mark {0} is Possible", nValue.ToString());
                    item.Click += markPossibleValueHandler;
                }
                else
                {
                    item.Text = String.Format("UnMark {0} as a Possible", nValue.ToString());
                    item.Click += unMarkPossibleValueHandler;
                }

                menu.MenuItems.Add(item);
            }

            return menu;
        }

        private void MarkPossibleValue(object sender, EventArgs args)
        {
            MenuItem item = (MenuItem)sender;

            PossibleValue possibleValue = (PossibleValue)item.Tag;

            m_board.MarkPossibleValue(possibleValue.X, possibleValue.Y, possibleValue.Val);
        }


        private void UnMarkPossibleValue(object sender, EventArgs args)
        {
            MenuItem item = (MenuItem)sender;

            PossibleValue possibleValue = (PossibleValue)item.Tag;

            m_board.UnMarkPossibleValue(possibleValue.X, possibleValue.Y, possibleValue.Val);
        }

        private void ClearAllMarkedItems(object sender, EventArgs args)
        {
            MenuItem item = (MenuItem)sender;
            PossibleValue possibleValue = (PossibleValue)item.Tag;

            for (int nVal = 1; nVal <= m_board.MaxValue; nVal++)
            {
                m_board.UnMarkPossibleValue(possibleValue.X, possibleValue.Y, nVal);
            }
        }


        private void CellValueSelected(object sender, EventArgs args)
        {
            MenuItem item = (MenuItem)sender;

            int val = item.Index;

            m_board[m_lastSelectedCellX, m_lastSelectedCellY] = val;
        }

        private void Solved(object sender, EventArgs args)
        {
            MessageBox.Show("Congratulations you have solved it...");
        }

    }
}
