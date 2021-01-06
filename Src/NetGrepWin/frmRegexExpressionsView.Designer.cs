namespace NetGrep
{
    partial class frmRegexExpressionsView
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
            this.cmdExit = new System.Windows.Forms.Button();
            this.lblOperationsTitle = new System.Windows.Forms.Label();
            this.cmdTest01 = new System.Windows.Forms.Button();
            this.webbRegExInfo = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(780, 545);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(73, 21);
            this.cmdExit.TabIndex = 23;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // lblOperationsTitle
            // 
            this.lblOperationsTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblOperationsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperationsTitle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lblOperationsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationsTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOperationsTitle.Location = new System.Drawing.Point(15, 9);
            this.lblOperationsTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOperationsTitle.Name = "lblOperationsTitle";
            this.lblOperationsTitle.Size = new System.Drawing.Size(835, 25);
            this.lblOperationsTitle.TabIndex = 24;
            this.lblOperationsTitle.Text = "Regular Expression Language - Quick Reference";
            this.lblOperationsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdTest01
            // 
            this.cmdTest01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest01.Location = new System.Drawing.Point(701, 545);
            this.cmdTest01.Name = "cmdTest01";
            this.cmdTest01.Size = new System.Drawing.Size(73, 21);
            this.cmdTest01.TabIndex = 23;
            this.cmdTest01.Text = "Test 01";
            this.cmdTest01.UseVisualStyleBackColor = true;
            this.cmdTest01.Click += new System.EventHandler(this.cmdTest01_Click);
            // 
            // webbRegExInfo
            // 
            this.webbRegExInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webbRegExInfo.Location = new System.Drawing.Point(15, 54);
            this.webbRegExInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.webbRegExInfo.Name = "webbRegExInfo";
            this.webbRegExInfo.Size = new System.Drawing.Size(835, 474);
            this.webbRegExInfo.TabIndex = 25;
            // 
            // frmRegexExpressionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 578);
            this.Controls.Add(this.webbRegExInfo);
            this.Controls.Add(this.lblOperationsTitle);
            this.Controls.Add(this.cmdTest01);
            this.Controls.Add(this.cmdExit);
            this.Name = "frmRegexExpressionsView";
            this.Text = "frmRegexExpressionsView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label lblOperationsTitle;
        private System.Windows.Forms.Button cmdTest01;
        private System.Windows.Forms.WebBrowser webbRegExInfo;
    }
}