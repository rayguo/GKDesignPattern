using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sudoku;

namespace WinSudoku
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Board board = BoardSerializer.DeSerialize(@"..\..\..\Puzzles\Hard\1.skd");

            Application.Run(new SudokuForm(board));
        }
    }
}