namespace NetGrep
{
    partial class frmOptions
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
            this.listBoxOptionWindows = new System.Windows.Forms.ListBox();
            this.panelOptionWindow = new System.Windows.Forms.Panel();
            this.lblOperationsTitle = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxOptionWindows
            // 
            this.listBoxOptionWindows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxOptionWindows.FormattingEnabled = true;
            this.listBoxOptionWindows.Items.AddRange(new object[] {
            "View Properties"});
            this.listBoxOptionWindows.Location = new System.Drawing.Point(19, 53);
            this.listBoxOptionWindows.Name = "listBoxOptionWindows";
            this.listBoxOptionWindows.Size = new System.Drawing.Size(170, 355);
            this.listBoxOptionWindows.TabIndex = 0;
            this.listBoxOptionWindows.SelectedIndexChanged += new System.EventHandler(this.listBoxOptionWindows_SelectedIndexChanged);
            // 
            // panelOptionWindow
            // 
            this.panelOptionWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptionWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptionWindow.Location = new System.Drawing.Point(195, 53);
            this.panelOptionWindow.Name = "panelOptionWindow";
            this.panelOptionWindow.Size = new System.Drawing.Size(333, 358);
            this.panelOptionWindow.TabIndex = 1;
            // 
            // lblOperationsTitle
            // 
            this.lblOperationsTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblOperationsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperationsTitle.BackColor = System.Drawing.Color.MediumVioletRed;
            this.lblOperationsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationsTitle.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblOperationsTitle.Location = new System.Drawing.Point(15, 9);
            this.lblOperationsTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOperationsTitle.Name = "lblOperationsTitle";
            this.lblOperationsTitle.Size = new System.Drawing.Size(515, 25);
            this.lblOperationsTitle.TabIndex = 19;
            this.lblOperationsTitle.Text = "Options Net grep";
            this.lblOperationsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(380, 429);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(73, 21);
            this.cmdCancel.TabIndex = 23;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(459, 429);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(73, 21);
            this.cmdExit.TabIndex = 22;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 462);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.lblOperationsTitle);
            this.Controls.Add(this.panelOptionWindow);
            this.Controls.Add(this.listBoxOptionWindows);
            this.Name = "frmOptions";
            this.Text = "frmOptions";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxOptionWindows;
        private System.Windows.Forms.Panel panelOptionWindow;
        private System.Windows.Forms.Label lblOperationsTitle;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExit;
    }
}