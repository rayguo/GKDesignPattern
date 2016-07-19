using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinSudoku
{
	/// <summary>
	/// Summary description for TextGrid.
	/// </summary>
	public class TextGrid : System.Windows.Forms.Control
	{
		public event EventHandler<CellMouseEventArgs> CellSelected;

        public enum CellTextVerticalAlignment
        {
            Top,
            Bottom,
            Middle
        }

        public enum CellTextHorizontalAlignment
        {
            Left,
            Middle,
            Right
        }

		public class Cell
		{
			private string		m_text;
            private string      m_picture; // alternative string used to determine font size for cell
			private Color		m_backColour;
			private TextGrid	m_owner;
			private int			m_x;
			private int			m_y;
            private bool        m_bold;
            private bool        m_italic;
           
            

			internal Cell( TextGrid owner , int column , int row)
			{
				m_owner = owner;
				m_x = column;
				m_y = row;

                m_horizontalAlignment = CellTextHorizontalAlignment.Middle;
                m_verticalAlignment = CellTextVerticalAlignment.Middle;
                
			}

            private CellTextHorizontalAlignment m_horizontalAlignment;

            public CellTextHorizontalAlignment HorizontalAlignment
            {
                get { return m_horizontalAlignment; }
                set { m_horizontalAlignment = value; }
            }

            private CellTextVerticalAlignment m_verticalAlignment;

            public CellTextVerticalAlignment VerticalAlignment
            {
                get { return m_verticalAlignment; }
                set { m_verticalAlignment = value; }
            }

            public FontStyle TextStyle
            {
                get
                {
                    FontStyle style = FontStyle.Regular;

                    if (m_bold)
                    {
                        style |= FontStyle.Bold;
                    }

                    if (m_italic)
                    {
                        style |= FontStyle.Italic;
                    }

                    return style;
                }
            }

			public bool Bold
			{
				get
				{
                    return m_bold;
				}
				set
				{
                    m_bold = value;
				}
			}


            public  bool Italic
            {
                get { return m_italic; }
                set { m_italic = value; }
            }


			public int Column
			{
				get { return m_x; }
			}

			public int Row
			{
				get { return m_y; }
			}

			public string Text
			{
				get
				{
					return m_text;
				}
				set
				{
					m_text = value;
					m_owner.DrawCell( m_x , m_y);
				}
			}

            public string Picture
            {
                get
                {
                    if (m_picture == null)
                    {
                        return m_text;
                    }
                    else
                    {
                        return m_picture;
                    }

                }
                set
                {
                    m_picture = value;
                }
            }


			public Color BackColor
			{
				get { return m_backColour; }
				set 
				{
					m_backColour = value; 
					m_owner.DrawCell( m_x , m_y);
				}
			}
		}

		private int			m_nColumns	= 3;
		private int			m_nRows		= 3;
		private float		m_rowHeight = 0;
		private float		m_columnWidth = 0;
		private int			m_lineWidth = 1;
		private Cell[,]		m_cells;
		private Font		m_cellFont;



		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private FontCache fontCache = new FontCache();

		public TextGrid()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

			m_cellFont = (Font) this.Font.Clone();

			ResetCells();

		}

		[Category("Layout")]
		public int Columns
		{
			get { return m_nColumns; }
			set 
			{
				m_nColumns = value;

				ResetCells();

				Scale();

				Invalidate();
			}
		}

		[Category("Layout")]
		public int Rows
		{
			get { return m_nRows; }
			set
			{
				m_nRows = value;
			
				ResetCells();

				Scale();
				 
				Invalidate();
			}
		}


		public Cell this[int x , int y]
		{
			get { return m_cells[x,y]; }
		}

		public void SetCellColor( int x , int y , Color colour)
		{
			m_cells[x,y].BackColor = colour;
		}


        public IEnumerable<Cell> GetCells()
        {
            for (int nCol = 0; nCol < this.Columns; nCol++)
            {
                for (int nRow = 0; nRow < this.Rows; nRow++)
                {
                    yield return m_cells[nCol, nRow];
                }
            }
        }


		protected override void OnResize(EventArgs e)
		{
			Scale();

			Invalidate();

			base.OnResize (e);
		}

		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			int column =  e.X / (int) m_columnWidth;
			int row =  e.Y / (int) m_rowHeight;

			OnCellSelected( new CellMouseEventArgs( e , column , row ) );

			base.OnMouseDown (e);
		}


		protected virtual void OnCellSelected( CellMouseEventArgs args )
		{
			if ( CellSelected != null )
			{
				CellSelected( this , args );
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		protected override void OnPaint(PaintEventArgs pe)
		{
			using ( System.Drawing.Pen pen = new Pen( ForeColor , m_lineWidth ) )
			{				
				DrawCells( pe.Graphics , pen );


			}
			
			base.OnPaint(pe);
		}

        private void Scale()
        {
            m_rowHeight = Size.Height / m_nRows;
            m_columnWidth = Size.Width / m_nColumns;

            // Reset any cached fonts as the size of the board
            // has changed and thus we will need to recalc the font sizes
            fontCache.Dispose();
            fontCache = new FontCache();
        }

		private void ResetCells()
		{
			m_cells = new Cell[ m_nColumns , m_nRows ];
			
			for ( int x = 0 ; x < m_nColumns ; x++ )
			{
				for ( int y = 0 ; y < m_nRows ; y++ )
				{
					m_cells[x,y] = new Cell( this , x , y );

					m_cells[x,y].BackColor = BackColor;
				}
			}
		}

		private void DrawCells( Graphics gc , Pen pen )
		{	
			for ( int x = 0 ; x < m_nColumns ; x++ )
			{
				for ( int y = 0 ; y < m_nRows ; y++ )
				{
					DrawCell( gc , x , y );
				}
			}
		}

		private void DrawCell( int x , int y )
		{
			using ( Graphics gc = CreateGraphics() )
			{
				DrawCell( gc , x , y );
			}
		}


        /// <summary>
        /// The font has changed for the board, so we will need to rebuild the font cache
        /// </summary>
        /// <param name="e"></param>
		protected override void OnFontChanged(EventArgs e)
		{
            fontCache.Dispose();
            fontCache = new FontCache();

			base.OnFontChanged (e);

            Invalidate();
		}

		private void DrawCell( Graphics gc , int x , int y )
		{
            using (Brush solidBrush = new SolidBrush(m_cells[x, y].BackColor),
                    textBrush = new SolidBrush(ForeColor))
            {
                gc.FillRectangle(solidBrush,
                                  (float)x * m_columnWidth,
                                  (float)y * m_rowHeight,
                                   m_columnWidth,
                                   m_rowHeight);



                string cellText = m_cells[x, y].Text;

                if (cellText != null)
                {
                    Font font = GetFontByStyle(m_cells[x, y].TextStyle, m_cells[x,y].Picture);

                    SizeF textSize = gc.MeasureString(cellText, font);

                    int cellHPadding = 0;
                    int cellVPadding = 0;

                    switch (m_cells[x, y].HorizontalAlignment)
                    {
                        case CellTextHorizontalAlignment.Middle:
                            {
                                cellHPadding = (int)(m_columnWidth - textSize.Width) / 2;
                            }
                            break;

                        case CellTextHorizontalAlignment.Right:
                            {
                                cellHPadding = (int)(m_columnWidth - textSize.Width);
                            }
                            break;
                    }

                    switch (m_cells[x, y].VerticalAlignment)
                    {
                        case CellTextVerticalAlignment.Bottom:
                            {
                                cellVPadding = (int)(m_rowHeight - textSize.Height);
                            }
                            break;

                        case CellTextVerticalAlignment.Middle:
                            {
                                cellVPadding = (int)(m_rowHeight - textSize.Height) / 2;
                            }
                            break;
                    }

                    gc.DrawString(cellText,
                        font,
                        textBrush,
                        x * m_columnWidth + cellHPadding,
                        y * m_rowHeight + cellVPadding);
                }

                using (System.Drawing.Pen pen = new Pen(ForeColor, m_lineWidth))
                {
                    gc.DrawRectangle(pen, (float)x * m_columnWidth,
                        (float)y * m_rowHeight,
                        m_columnWidth,
                        m_rowHeight);
                }
            }

		}

        private Font GetFontByStyle(FontStyle fontStyle, string text)
        {
            Font font = fontCache.GetFont(fontStyle, text.Length);

            if (font == null)
            {
                font = ComputeFont(Font.FontFamily, fontStyle, text, (int)m_columnWidth, (int)m_rowHeight);
                fontCache.AddFont(font, text.Length);
            }

            return font;
        }


        private Font ComputeFont( FontFamily family , FontStyle style , string text , int maxWidth , int maxHeight )
        {
            if ((maxWidth <= 0) || ( text == null ) || ( text.Length == 0 ))
            {
                return this.Font;
            }

            int pointSize = 6;

            using( Graphics gc = CreateGraphics() )
				{
					
					bool fontTooBig = false;
                    Font trialFont = null;

					do
					{
                        if (trialFont != null)
						{
                            trialFont.Dispose();
						}

                        trialFont = new Font(family, pointSize, style);

						SizeF	textSize = gc.MeasureString( text , trialFont );

						fontTooBig = ( textSize.Width > maxWidth );
						fontTooBig |= ( textSize.Height > maxHeight );

						pointSize+=2;
					}
					while( fontTooBig == false );

                    trialFont.Dispose();
            }
         
            return new Font( family , pointSize-4,style );
        }

	
	}

    public class CellMouseEventArgs : EventArgs
    {
        public CellMouseEventArgs(MouseEventArgs mouseArgs, int column, int row)
        {
            Column = column;
            Row = row;
            MouseEventArgs = mouseArgs;
        }

        private int column;

        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        private int row;

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        private MouseEventArgs mouseEventArgs;

        public MouseEventArgs MouseEventArgs
        {
            get { return mouseEventArgs; }
            set { mouseEventArgs = value; }
        }

    }
}
