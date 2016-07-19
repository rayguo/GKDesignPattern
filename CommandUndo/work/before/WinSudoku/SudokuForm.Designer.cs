namespace WinSudoku
{
    partial class SudokuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SudokuForm));
            this.appMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.assistButton = new System.Windows.Forms.ToolStripButton();
            this.boardView = new WinSudoku.BoardControl();
            this.appMenuStrip.SuspendLayout();
            this.appToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // appMenuStrip
            // 
            this.appMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.appMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.appMenuStrip.Name = "appMenuStrip";
            this.appMenuStrip.Size = new System.Drawing.Size(598, 24);
            this.appMenuStrip.TabIndex = 0;
            this.appMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.AppExit);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solveToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // solveToolStripMenuItem
            // 
            this.solveToolStripMenuItem.Name = "solveToolStripMenuItem";
            this.solveToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.solveToolStripMenuItem.Text = "Solve";
            this.solveToolStripMenuItem.Click += new System.EventHandler(this.SolveBoard);
            // 
            // appToolStrip
            // 
            this.appToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.assistButton});
            this.appToolStrip.Location = new System.Drawing.Point(0, 24);
            this.appToolStrip.Name = "appToolStrip";
            this.appToolStrip.Size = new System.Drawing.Size(598, 25);
            this.appToolStrip.TabIndex = 1;
            this.appToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 22);
            this.toolStripButton1.Text = "Undo";
            this.toolStripButton1.Click += new System.EventHandler(this.Undo);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton2.Text = "Redo";
            this.toolStripButton2.Click += new System.EventHandler(this.Redo);
            // 
            // assistButton
            // 
            this.assistButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.assistButton.Image = ((System.Drawing.Image)(resources.GetObject("assistButton.Image")));
            this.assistButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.assistButton.Name = "assistButton";
            this.assistButton.Size = new System.Drawing.Size(41, 22);
            this.assistButton.Text = "Assist";
            this.assistButton.Click += new System.EventHandler(this.assistButton_Click);
            // 
            // boardView
            // 
            this.boardView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardView.EvenCellColor = System.Drawing.Color.Bisque;
            this.boardView.Location = new System.Drawing.Point(0, 49);
            this.boardView.Name = "boardView";
            this.boardView.OddCellColor = System.Drawing.Color.Linen;
            this.boardView.Size = new System.Drawing.Size(598, 477);
            this.boardView.TabIndex = 2;
            // 
            // SudokuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 526);
            this.Controls.Add(this.boardView);
            this.Controls.Add(this.appToolStrip);
            this.Controls.Add(this.appMenuStrip);
            this.MainMenuStrip = this.appMenuStrip;
            this.Name = "SudokuForm";
            this.Text = "Sudoku";
            this.appMenuStrip.ResumeLayout(false);
            this.appMenuStrip.PerformLayout();
            this.appToolStrip.ResumeLayout(false);
            this.appToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip appMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip appToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private WinSudoku.BoardControl boardView;
        private System.Windows.Forms.ToolStripButton assistButton;
        private System.Windows.Forms.ToolStripMenuItem solveToolStripMenuItem;
    }
}

