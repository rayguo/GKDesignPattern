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
        private UndoRedoBoardDecorator board;
        private Solver solver;

        public SudokuForm(Board board)
        {
            this.board = new UndoRedoBoardDecorator(board);
            
            InitializeComponent();
            
            solver = new BasicSolver(this.board);

            boardView.Board = this.board;              
        }

        private void assistButton_Click(object sender, EventArgs e)
        {
            solver.Assist();
        }

        private void SolveBoard(object sender, EventArgs e)
        {
            solver.Solve();
        }

        private void Undo(object sender, EventArgs e)
        {
            board.UndoLastStep();
        }

        private void Redo(object sender, EventArgs e)
        {
            board.RedoLastUndo();
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}