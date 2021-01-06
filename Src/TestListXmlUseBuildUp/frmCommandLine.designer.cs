namespace CmdLine2005
{
    partial class frmCommandLine
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.InfoBox = new System.Windows.Forms.TextBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.lblInfoCmdLineInterpreterTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InfoBox
            // 
            this.InfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoBox.Location = new System.Drawing.Point(25, 96);
            this.InfoBox.Multiline = true;
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.InfoBox.Size = new System.Drawing.Size(734, 454);
            this.InfoBox.TabIndex = 1;
            this.InfoBox.WordWrap = false;
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(660, 568);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(99, 28);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // lblInfoCmdLineInterpreterTitle
            // 
            this.lblInfoCmdLineInterpreterTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblInfoCmdLineInterpreterTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoCmdLineInterpreterTitle.BackColor = System.Drawing.Color.MediumPurple;
            this.lblInfoCmdLineInterpreterTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblInfoCmdLineInterpreterTitle.Location = new System.Drawing.Point(25, 9);
            this.lblInfoCmdLineInterpreterTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInfoCmdLineInterpreterTitle.Name = "lblInfoCmdLineInterpreterTitle";
            this.lblInfoCmdLineInterpreterTitle.Size = new System.Drawing.Size(734, 38);
            this.lblInfoCmdLineInterpreterTitle.TabIndex = 18;
            this.lblInfoCmdLineInterpreterTitle.Text = "Command line interpreter";
            this.lblInfoCmdLineInterpreterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(28, 61);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(731, 24);
            this.lblTitle.TabIndex = 19;
            // 
            // frmCommandLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 608);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInfoCmdLineInterpreterTitle);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.InfoBox);
            this.Name = "frmCommandLine";
            this.Text = "Command line interpreter";
            this.Load += new System.EventHandler(this.frmCommandLine_Load);
            this.Shown += new System.EventHandler(this.frmCommandLine_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCommandLine_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdExit;
        public System.Windows.Forms.TextBox InfoBox;
        private System.Windows.Forms.Label lblInfoCmdLineInterpreterTitle;
        private System.Windows.Forms.Label lblTitle;
    }
}