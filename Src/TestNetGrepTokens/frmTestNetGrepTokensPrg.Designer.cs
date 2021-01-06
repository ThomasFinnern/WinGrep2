namespace NetGrep
{
    partial class frmTestNetGrepTokenPrg
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
            this.lblSearchParameterTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.cmdTestAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(569, 435);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 25);
            this.cmdExit.TabIndex = 0;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // lblSearchParameterTitle
            // 
            this.lblSearchParameterTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblSearchParameterTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchParameterTitle.BackColor = System.Drawing.Color.Gold;
            this.lblSearchParameterTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchParameterTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSearchParameterTitle.Location = new System.Drawing.Point(26, 30);
            this.lblSearchParameterTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearchParameterTitle.Name = "lblSearchParameterTitle";
            this.lblSearchParameterTitle.Size = new System.Drawing.Size(618, 25);
            this.lblSearchParameterTitle.TabIndex = 57;
            this.lblSearchParameterTitle.Text = "Test Net grep tokens";
            this.lblSearchParameterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Result";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Location = new System.Drawing.Point(30, 105);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(513, 319);
            this.textBoxResult.TabIndex = 55;
            // 
            // cmdTestAll
            // 
            this.cmdTestAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestAll.Location = new System.Drawing.Point(569, 105);
            this.cmdTestAll.Name = "cmdTestAll";
            this.cmdTestAll.Size = new System.Drawing.Size(75, 31);
            this.cmdTestAll.TabIndex = 54;
            this.cmdTestAll.Text = "Test all";
            this.cmdTestAll.UseVisualStyleBackColor = true;
            this.cmdTestAll.Click += new System.EventHandler(this.cmdTestAll_Click);
            // 
            // frmTestNetGrepTokenPrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 472);
            this.Controls.Add(this.lblSearchParameterTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.cmdTestAll);
            this.Controls.Add(this.cmdExit);
            this.Name = "frmTestNetGrepTokenPrg";
            this.Text = "Test Net Grep tokens";
            this.Load += new System.EventHandler(this.frmTestNetGrepTokenPrg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label lblSearchParameterTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button cmdTestAll;
    }
}

