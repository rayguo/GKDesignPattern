namespace LogoApp
{
    partial class LogoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogoForm));
            this.applicationMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRecordingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRecordingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.logoActionControl1 = new LogoApp.LogoActionControl();
            this.logoActionControl2 = new LogoApp.LogoActionControl();
            this.logoActionControl3 = new LogoApp.LogoActionControl();
            this.turtleView = new LogoApp.TurtleView();
            this.applicationMenuStrip.SuspendLayout();
            this.applicationToolStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // applicationMenuStrip
            // 
            this.applicationMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.macroToolStripMenuItem});
            this.applicationMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.applicationMenuStrip.Name = "applicationMenuStrip";
            this.applicationMenuStrip.Size = new System.Drawing.Size(786, 24);
            this.applicationMenuStrip.TabIndex = 0;
            this.applicationMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // macroToolStripMenuItem
            // 
            this.macroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startRecordingMenuItem,
            this.stopRecordingItem});
            this.macroToolStripMenuItem.Name = "macroToolStripMenuItem";
            this.macroToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.macroToolStripMenuItem.Text = "Macro";
            // 
            // startRecordingMenuItem
            // 
            this.startRecordingMenuItem.Name = "startRecordingMenuItem";
            this.startRecordingMenuItem.Size = new System.Drawing.Size(155, 22);
            this.startRecordingMenuItem.Text = "Start Recording";
            this.startRecordingMenuItem.Click += new System.EventHandler(this.StartRecording);
            // 
            // stopRecordingItem
            // 
            this.stopRecordingItem.Enabled = false;
            this.stopRecordingItem.Name = "stopRecordingItem";
            this.stopRecordingItem.Size = new System.Drawing.Size(155, 22);
            this.stopRecordingItem.Text = "Stop Recording";
            this.stopRecordingItem.Click += new System.EventHandler(this.StopRecordingMacro);
            // 
            // applicationToolStrip
            // 
            this.applicationToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.applicationToolStrip.Location = new System.Drawing.Point(0, 24);
            this.applicationToolStrip.Name = "applicationToolStrip";
            this.applicationToolStrip.Size = new System.Drawing.Size(786, 25);
            this.applicationToolStrip.TabIndex = 1;
            this.applicationToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton1.Text = "Clear";
            this.toolStripButton1.Click += new System.EventHandler(this.ClearAndReset);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(40, 22);
            this.toolStripButton2.Text = "Undo";
            this.toolStripButton2.Click += new System.EventHandler(this.Undo);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.turtleView);
            this.splitContainer1.Size = new System.Drawing.Size(786, 476);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.logoActionControl1);
            this.flowLayoutPanel1.Controls.Add(this.logoActionControl2);
            this.flowLayoutPanel1.Controls.Add(this.logoActionControl3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(262, 476);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.ClearAndReset);
            // 
            // logoActionControl1
            // 
            this.logoActionControl1.ActionName = "Forward";
            this.logoActionControl1.Location = new System.Drawing.Point(3, 3);
            this.logoActionControl1.Name = "logoActionControl1";
            this.logoActionControl1.Size = new System.Drawing.Size(256, 35);
            this.logoActionControl1.TabIndex = 2;
            this.logoActionControl1.DoAction += new System.EventHandler<LogoApp.RepeatActionEventArgs>(this.Forward);
            // 
            // logoActionControl2
            // 
            this.logoActionControl2.ActionName = "Rotate";
            this.logoActionControl2.Location = new System.Drawing.Point(3, 44);
            this.logoActionControl2.Name = "logoActionControl2";
            this.logoActionControl2.Size = new System.Drawing.Size(256, 35);
            this.logoActionControl2.TabIndex = 3;
            this.logoActionControl2.DoAction += new System.EventHandler<LogoApp.RepeatActionEventArgs>(this.Rotate);
            // 
            // logoActionControl3
            // 
            this.logoActionControl3.ActionName = "Macro";
            this.logoActionControl3.Location = new System.Drawing.Point(3, 85);
            this.logoActionControl3.Name = "logoActionControl3";
            this.logoActionControl3.Size = new System.Drawing.Size(237, 35);
            this.logoActionControl3.TabIndex = 4;
            this.logoActionControl3.DoAction += new System.EventHandler<LogoApp.RepeatActionEventArgs>(this.RunMacro);
            // 
            // turtleView
            // 
            this.turtleView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.turtleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.turtleView.Location = new System.Drawing.Point(0, 0);
            this.turtleView.Name = "turtleView";
            this.turtleView.Size = new System.Drawing.Size(520, 476);
            this.turtleView.TabIndex = 0;
            this.turtleView.Text = "turtleView1";
            this.turtleView.Turtle = null;
            // 
            // LogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 525);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.applicationToolStrip);
            this.Controls.Add(this.applicationMenuStrip);
            this.MainMenuStrip = this.applicationMenuStrip;
            this.Name = "LogoForm";
            this.Text = "Logo.NET";
            this.applicationMenuStrip.ResumeLayout(false);
            this.applicationMenuStrip.PerformLayout();
            this.applicationToolStrip.ResumeLayout(false);
            this.applicationToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip applicationMenuStrip;
        private System.Windows.Forms.ToolStrip applicationToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private TurtleView turtleView;
        private LogoActionControl logoActionControl1;
        private LogoActionControl logoActionControl2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRecordingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopRecordingItem;
        private LogoActionControl logoActionControl3;
    }
}

