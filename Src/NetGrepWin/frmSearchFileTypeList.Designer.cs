namespace NetGrep
{
    partial class frmSearchFileTypeList
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
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelTextList = new System.Windows.Forms.Label();
            this.textBoxFileTypeList = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
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
            this.lblSearchPropertiesTitle.TabIndex = 8;
            this.lblSearchPropertiesTitle.Text = "Search file types";
            this.lblSearchPropertiesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.Location = new System.Drawing.Point(276, 65);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(201, 200);
            this.labelInfo.TabIndex = 13;
            this.labelInfo.Text = "One file type per line";
            // 
            // labelTextList
            // 
            this.labelTextList.AutoSize = true;
            this.labelTextList.Location = new System.Drawing.Point(15, 46);
            this.labelTextList.Name = "labelTextList";
            this.labelTextList.Size = new System.Drawing.Size(95, 13);
            this.labelTextList.TabIndex = 12;
            this.labelTextList.Text = "Search file type list";
            // 
            // textBoxFileTypeList
            // 
            this.textBoxFileTypeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileTypeList.Location = new System.Drawing.Point(15, 62);
            this.textBoxFileTypeList.Multiline = true;
            this.textBoxFileTypeList.Name = "textBoxFileTypeList";
            this.textBoxFileTypeList.Size = new System.Drawing.Size(237, 359);
            this.textBoxFileTypeList.TabIndex = 11;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(313, 433);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(73, 21);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(407, 433);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(73, 21);
            this.cmdExit.TabIndex = 15;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // frmSearchFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 466);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelTextList);
            this.Controls.Add(this.textBoxFileTypeList);
            this.Controls.Add(this.lblSearchPropertiesTitle);
            this.Name = "frmSearchFileList";
            this.Text = "frmSearchFileList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchPropertiesTitle;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelTextList;
        private System.Windows.Forms.TextBox textBoxFileTypeList;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExit;
    }
}