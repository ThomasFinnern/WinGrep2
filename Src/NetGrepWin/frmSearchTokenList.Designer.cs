namespace NetGrep
{
    partial class frmSearchTokenList
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
            this.lblSearchPropertiesTitle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelTextList = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSearchPropertiesTitle
            // 
            this.lblSearchPropertiesTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblSearchPropertiesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchPropertiesTitle.BackColor = System.Drawing.Color.DarkGreen;
            this.lblSearchPropertiesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchPropertiesTitle.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblSearchPropertiesTitle.Location = new System.Drawing.Point(9, 9);
            this.lblSearchPropertiesTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearchPropertiesTitle.Name = "lblSearchPropertiesTitle";
            this.lblSearchPropertiesTitle.Size = new System.Drawing.Size(471, 25);
            this.lblSearchPropertiesTitle.TabIndex = 7;
            this.lblSearchPropertiesTitle.Text = "Search token";
            this.lblSearchPropertiesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(18, 70);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 359);
            this.textBox1.TabIndex = 8;
            // 
            // labelTextList
            // 
            this.labelTextList.AutoSize = true;
            this.labelTextList.Location = new System.Drawing.Point(18, 54);
            this.labelTextList.Name = "labelTextList";
            this.labelTextList.Size = new System.Drawing.Size(53, 13);
            this.labelTextList.TabIndex = 9;
            this.labelTextList.Text = "Token list";
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.Location = new System.Drawing.Point(279, 73);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(201, 200);
            this.labelInfo.TabIndex = 10;
            this.labelInfo.Text = "One token per line";
            // 
            // frmSearchTokenList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 466);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelTextList);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblSearchPropertiesTitle);
            this.Name = "frmSearchTokenList";
            this.Text = "frmSearchTokenList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchPropertiesTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelTextList;
        private System.Windows.Forms.Label labelInfo;
    }
}