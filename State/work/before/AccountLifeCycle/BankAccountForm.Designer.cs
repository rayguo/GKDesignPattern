namespace AccountLifeCycle
{
    partial class BankAccountForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label5;
            this.creditButton = new System.Windows.Forms.Button();
            this.debitButton = new System.Windows.Forms.Button();
            this.freezeButton = new System.Windows.Forms.Button();
            this.unfreezeButton = new System.Windows.Forms.Button();
            this.closeAccount = new System.Windows.Forms.Button();
            this.amountTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.confirmIdentityButton = new System.Windows.Forms.Button();
            this.showWorkflowButton = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // creditButton
            // 
            this.creditButton.Location = new System.Drawing.Point(111, 73);
            this.creditButton.Name = "creditButton";
            this.creditButton.Size = new System.Drawing.Size(75, 23);
            this.creditButton.TabIndex = 0;
            this.creditButton.Text = "Credit";
            this.creditButton.UseVisualStyleBackColor = true;
            this.creditButton.Click += new System.EventHandler(this.creditButton_Click);
            // 
            // debitButton
            // 
            this.debitButton.Location = new System.Drawing.Point(30, 73);
            this.debitButton.Name = "debitButton";
            this.debitButton.Size = new System.Drawing.Size(75, 23);
            this.debitButton.TabIndex = 1;
            this.debitButton.Text = "Debit";
            this.debitButton.UseVisualStyleBackColor = true;
            this.debitButton.Click += new System.EventHandler(this.debitButton_Click);
            // 
            // freezeButton
            // 
            this.freezeButton.Location = new System.Drawing.Point(6, 58);
            this.freezeButton.Name = "freezeButton";
            this.freezeButton.Size = new System.Drawing.Size(75, 23);
            this.freezeButton.TabIndex = 2;
            this.freezeButton.Text = "Freeze";
            this.freezeButton.UseVisualStyleBackColor = true;
            this.freezeButton.Click += new System.EventHandler(this.freezeButton_Click);
            // 
            // unfreezeButton
            // 
            this.unfreezeButton.Location = new System.Drawing.Point(87, 58);
            this.unfreezeButton.Name = "unfreezeButton";
            this.unfreezeButton.Size = new System.Drawing.Size(75, 23);
            this.unfreezeButton.TabIndex = 3;
            this.unfreezeButton.Text = "UnFreeze";
            this.unfreezeButton.UseVisualStyleBackColor = true;
            this.unfreezeButton.Click += new System.EventHandler(this.unfreezeButton_Click);
            // 
            // closeAccount
            // 
            this.closeAccount.Location = new System.Drawing.Point(6, 105);
            this.closeAccount.Name = "closeAccount";
            this.closeAccount.Size = new System.Drawing.Size(156, 23);
            this.closeAccount.TabIndex = 4;
            this.closeAccount.Text = "Close Account";
            this.closeAccount.UseVisualStyleBackColor = true;
            this.closeAccount.Click += new System.EventHandler(this.closeAccount_Click);
            // 
            // amountTextbox
            // 
            this.amountTextbox.Location = new System.Drawing.Point(76, 44);
            this.amountTextbox.Name = "amountTextbox";
            this.amountTextbox.Size = new System.Drawing.Size(100, 20);
            this.amountTextbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Amount";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.amountTextbox);
            this.groupBox1.Controls.Add(this.creditButton);
            this.groupBox1.Controls.Add(this.debitButton);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 134);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Actions";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.confirmIdentityButton);
            this.groupBox2.Controls.Add(this.freezeButton);
            this.groupBox2.Controls.Add(this.unfreezeButton);
            this.groupBox2.Controls.Add(this.closeAccount);
            this.groupBox2.Location = new System.Drawing.Point(293, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 134);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bank Actions";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.showWorkflowButton);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 60);
            this.panel1.TabIndex = 11;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(526, 25);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "Close";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.statusLabel);
            this.groupBox3.Controls.Add(label5);
            this.groupBox3.Controls.Add(this.balanceLabel);
            this.groupBox3.Controls.Add(label2);
            this.groupBox3.Location = new System.Drawing.Point(22, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(587, 97);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Account Info";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(30, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 13);
            label2.TabIndex = 0;
            label2.Text = "Balance";
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Location = new System.Drawing.Point(82, 33);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(71, 13);
            this.balanceLabel.TabIndex = 1;
            this.balanceLabel.Text = "balanceLabel";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(82, 69);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(61, 13);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "statusLabel";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(30, 69);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(37, 13);
            label5.TabIndex = 2;
            label5.Text = "Status";
            // 
            // confirmIdentityButton
            // 
            this.confirmIdentityButton.Location = new System.Drawing.Point(6, 19);
            this.confirmIdentityButton.Name = "confirmIdentityButton";
            this.confirmIdentityButton.Size = new System.Drawing.Size(156, 23);
            this.confirmIdentityButton.TabIndex = 5;
            this.confirmIdentityButton.Text = "Confirmed Identity";
            this.confirmIdentityButton.UseVisualStyleBackColor = true;
            this.confirmIdentityButton.Click += new System.EventHandler(this.ConfirmIdentity);
            // 
            // showWorkflowButton
            // 
            this.showWorkflowButton.Location = new System.Drawing.Point(344, 25);
            this.showWorkflowButton.Name = "showWorkflowButton";
            this.showWorkflowButton.Size = new System.Drawing.Size(145, 23);
            this.showWorkflowButton.TabIndex = 1;
            this.showWorkflowButton.Text = "Show Workflow";
            this.showWorkflowButton.UseVisualStyleBackColor = true;
            this.showWorkflowButton.Click += new System.EventHandler(this.ShowWorkflow);
            // 
            // BankAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 377);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Name = "BankAccountForm";
            this.Text = "State Bank";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button creditButton;
        private System.Windows.Forms.Button debitButton;
        private System.Windows.Forms.Button freezeButton;
        private System.Windows.Forms.Button unfreezeButton;
        private System.Windows.Forms.Button closeAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox amountTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Button confirmIdentityButton;
        private System.Windows.Forms.Button showWorkflowButton;
    }
}