using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sudoku;
using System.Threading;

namespace WinSudoku
{
    public partial class SudokuForm : Form
    {
        private Board m_board;
        private Solver solver;

        public SudokuForm(Board board)
        {
           m_board = board;

            InitializeComponent();
            
            solver = new BasicSolver(m_board);

            boardView.Board = m_board;              
        }

        private void assistButton_Click(object sender, EventArgs e)
        {
            solver.Assist();
        }

        private void SolveBoard(object sender, EventArgs e)
        {
            solver.Solve();
        }

        private void AppExit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Undo(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented yet");
        }

        private void Redo(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet");
        }
    }
}