using System.Windows.Forms;
namespace WinSudoku
{
    partial class BoardControl :   UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.gridControl = new WinSudoku.TextGrid();
            this.m_selectValueMenu = new System.Windows.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl.Columns = 9;
            this.gridControl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.gridControl.Location = new System.Drawing.Point(24, 24);
            this.gridControl.Name = "gridControl";
            this.gridControl.Rows = 9;
            this.gridControl.Size = new System.Drawing.Size(352, 272);
            this.gridControl.TabIndex = 0;
            this.gridControl.Text = "textGrid1";
            // 
            // BoardControl
            // 
            this.Controls.Add(this.gridControl);
            this.Name = "BoardControl";
            this.Size = new System.Drawing.Size(400, 320);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
