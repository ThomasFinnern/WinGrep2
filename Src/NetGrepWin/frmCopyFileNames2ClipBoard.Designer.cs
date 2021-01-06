namespace NetGrep
{
    partial class frmCopyFileNames2ClipBoard
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
            this.cmdAssign = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtbFileNames = new System.Windows.Forms.TextBox();
            this.lblSearchPropertiesTitle = new System.Windows.Forms.Label();
            this.rdbtFileNames = new System.Windows.Forms.RadioButton();
            this.rdbtFileNamesNoExtension = new System.Windows.Forms.RadioButton();
            this.rdbtFileNamesWithPath = new System.Windows.Forms.RadioButton();
            this.rdbtFolderNames = new System.Windows.Forms.RadioButton();
            this.chkbWordWrap = new System.Windows.Forms.CheckBox();
            this.chkbViewDoubles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdAssign
            // 
            this.cmdAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAssign.Location = new System.Drawing.Point(335, 682);
            this.cmdAssign.Name = "cmdAssign";
            this.cmdAssign.Size = new System.Drawing.Size(103, 25);
            this.cmdAssign.TabIndex = 0;
            this.cmdAssign.Text = "Copy 2 clip board";
            this.cmdAssign.UseVisualStyleBackColor = true;
            this.cmdAssign.Click += new System.EventHandler(this.cmdAssign_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(444, 682);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 25);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtbFileNames
            // 
            this.txtbFileNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbFileNames.Location = new System.Drawing.Point(22, 130);
            this.txtbFileNames.Multiline = true;
            this.txtbFileNames.Name = "txtbFileNames";
            this.txtbFileNames.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtbFileNames.Size = new System.Drawing.Size(522, 539);
            this.txtbFileNames.TabIndex = 28;
            // 
            // lblSearchPropertiesTitle
            // 
            this.lblSearchPropertiesTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblSearchPropertiesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchPropertiesTitle.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblSearchPropertiesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchPropertiesTitle.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblSearchPropertiesTitle.Location = new System.Drawing.Point(18, 9);
            this.lblSearchPropertiesTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearchPropertiesTitle.Name = "lblSearchPropertiesTitle";
            this.lblSearchPropertiesTitle.Size = new System.Drawing.Size(526, 25);
            this.lblSearchPropertiesTitle.TabIndex = 29;
            this.lblSearchPropertiesTitle.Text = "Copy files/folder names to clipboard";
            this.lblSearchPropertiesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbtFileNames
            // 
            this.rdbtFileNames.AutoSize = true;
            this.rdbtFileNames.Checked = true;
            this.rdbtFileNames.Location = new System.Drawing.Point(27, 37);
            this.rdbtFileNames.Name = "rdbtFileNames";
            this.rdbtFileNames.Size = new System.Drawing.Size(130, 17);
            this.rdbtFileNames.TabIndex = 30;
            this.rdbtFileNames.TabStop = true;
            this.rdbtFileNames.Text = "File names (name.ext))";
            this.rdbtFileNames.UseVisualStyleBackColor = true;
            this.rdbtFileNames.CheckedChanged += new System.EventHandler(this.rdbtFileNames_CheckedChanged);
            // 
            // rdbtFileNamesNoExtension
            // 
            this.rdbtFileNamesNoExtension.AutoSize = true;
            this.rdbtFileNamesNoExtension.Location = new System.Drawing.Point(27, 60);
            this.rdbtFileNamesNoExtension.Name = "rdbtFileNamesNoExtension";
            this.rdbtFileNamesNoExtension.Size = new System.Drawing.Size(195, 17);
            this.rdbtFileNamesNoExtension.TabIndex = 30;
            this.rdbtFileNamesNoExtension.Text = "File names without extension (name)";
            this.rdbtFileNamesNoExtension.UseVisualStyleBackColor = true;
            this.rdbtFileNamesNoExtension.CheckedChanged += new System.EventHandler(this.rdbtFileNames_CheckedChanged);
            // 
            // rdbtFileNamesWithPath
            // 
            this.rdbtFileNamesWithPath.AutoSize = true;
            this.rdbtFileNamesWithPath.Location = new System.Drawing.Point(27, 83);
            this.rdbtFileNamesWithPath.Name = "rdbtFileNamesWithPath";
            this.rdbtFileNamesWithPath.Size = new System.Drawing.Size(199, 17);
            this.rdbtFileNamesWithPath.TabIndex = 30;
            this.rdbtFileNamesWithPath.Text = "File names with path (path\\name.ext)";
            this.rdbtFileNamesWithPath.UseVisualStyleBackColor = true;
            this.rdbtFileNamesWithPath.CheckedChanged += new System.EventHandler(this.rdbtFileNames_CheckedChanged);
            // 
            // rdbtFolderNames
            // 
            this.rdbtFolderNames.AutoSize = true;
            this.rdbtFolderNames.Location = new System.Drawing.Point(27, 106);
            this.rdbtFolderNames.Name = "rdbtFolderNames";
            this.rdbtFolderNames.Size = new System.Drawing.Size(93, 17);
            this.rdbtFolderNames.TabIndex = 31;
            this.rdbtFolderNames.Text = "Path of all files";
            this.rdbtFolderNames.UseVisualStyleBackColor = true;
            this.rdbtFolderNames.CheckedChanged += new System.EventHandler(this.rdbtFileNames_CheckedChanged);
            // 
            // chkbWordWrap
            // 
            this.chkbWordWrap.AutoSize = true;
            this.chkbWordWrap.Location = new System.Drawing.Point(29, 684);
            this.chkbWordWrap.Name = "chkbWordWrap";
            this.chkbWordWrap.Size = new System.Drawing.Size(81, 17);
            this.chkbWordWrap.TabIndex = 32;
            this.chkbWordWrap.Text = "Word Wrap";
            this.chkbWordWrap.UseVisualStyleBackColor = true;
            this.chkbWordWrap.CheckedChanged += new System.EventHandler(this.chkbWordWrap_CheckedChanged);
            // 
            // chkbViewDoubles
            // 
            this.chkbViewDoubles.AutoSize = true;
            this.chkbViewDoubles.Location = new System.Drawing.Point(137, 686);
            this.chkbViewDoubles.Name = "chkbViewDoubles";
            this.chkbViewDoubles.Size = new System.Drawing.Size(89, 17);
            this.chkbViewDoubles.TabIndex = 33;
            this.chkbViewDoubles.Text = "View doubles";
            this.chkbViewDoubles.UseVisualStyleBackColor = true;
            this.chkbViewDoubles.CheckedChanged += new System.EventHandler(this.chkbViewDoubles_CheckedChanged);
            // 
            // frmCopyFileNames2ClipBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 719);
            this.Controls.Add(this.chkbViewDoubles);
            this.Controls.Add(this.chkbWordWrap);
            this.Controls.Add(this.rdbtFolderNames);
            this.Controls.Add(this.rdbtFileNamesWithPath);
            this.Controls.Add(this.rdbtFileNamesNoExtension);
            this.Controls.Add(this.rdbtFileNames);
            this.Controls.Add(this.lblSearchPropertiesTitle);
            this.Controls.Add(this.txtbFileNames);
            this.Controls.Add(this.cmdAssign);
            this.Controls.Add(this.btnExit);
            this.Name = "frmCopyFileNames2ClipBoard";
            this.Text = "frmCopyFileNames2ClipBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAssign;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtbFileNames;
        private System.Windows.Forms.Label lblSearchPropertiesTitle;
        private System.Windows.Forms.RadioButton rdbtFileNames;
        private System.Windows.Forms.RadioButton rdbtFileNamesNoExtension;
        private System.Windows.Forms.RadioButton rdbtFileNamesWithPath;
        private System.Windows.Forms.RadioButton rdbtFolderNames;
        private System.Windows.Forms.CheckBox chkbWordWrap;
        private System.Windows.Forms.CheckBox chkbViewDoubles;
    }
}