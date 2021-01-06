namespace NetGrep
{
    partial class CtrlOptionWhileSearching
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxDoViewFileNamesOnSearch = new System.Windows.Forms.CheckBox();
            this.checkBoxDoCountFoldersOnSearch = new System.Windows.Forms.CheckBox();
            this.checkBoxDoCountFilesOnSearch = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "View while searching";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxDoViewFileNamesOnSearch
            // 
            this.checkBoxDoViewFileNamesOnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxDoViewFileNamesOnSearch.AutoSize = true;
            this.checkBoxDoViewFileNamesOnSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoViewFileNamesOnSearch.Location = new System.Drawing.Point(153, 53);
            this.checkBoxDoViewFileNamesOnSearch.Name = "checkBoxDoViewFileNamesOnSearch";
            this.checkBoxDoViewFileNamesOnSearch.Size = new System.Drawing.Size(99, 17);
            this.checkBoxDoViewFileNamesOnSearch.TabIndex = 3;
            this.checkBoxDoViewFileNamesOnSearch.Text = "View file names";
            this.checkBoxDoViewFileNamesOnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoViewFileNamesOnSearch.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoCountFoldersOnSearch
            // 
            this.checkBoxDoCountFoldersOnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxDoCountFoldersOnSearch.AutoSize = true;
            this.checkBoxDoCountFoldersOnSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoCountFoldersOnSearch.Location = new System.Drawing.Point(164, 76);
            this.checkBoxDoCountFoldersOnSearch.Name = "checkBoxDoCountFoldersOnSearch";
            this.checkBoxDoCountFoldersOnSearch.Size = new System.Drawing.Size(88, 17);
            this.checkBoxDoCountFoldersOnSearch.TabIndex = 4;
            this.checkBoxDoCountFoldersOnSearch.Text = "Count folders";
            this.checkBoxDoCountFoldersOnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoCountFoldersOnSearch.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoCountFilesOnSearch
            // 
            this.checkBoxDoCountFilesOnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxDoCountFilesOnSearch.AutoSize = true;
            this.checkBoxDoCountFilesOnSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoCountFilesOnSearch.Location = new System.Drawing.Point(177, 99);
            this.checkBoxDoCountFilesOnSearch.Name = "checkBoxDoCountFilesOnSearch";
            this.checkBoxDoCountFilesOnSearch.Size = new System.Drawing.Size(75, 17);
            this.checkBoxDoCountFilesOnSearch.TabIndex = 5;
            this.checkBoxDoCountFilesOnSearch.Text = "Count files";
            this.checkBoxDoCountFilesOnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoCountFilesOnSearch.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBox4.AutoSize = true;
            this.checkBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox4.Location = new System.Drawing.Point(141, 122);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(111, 17);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "*View progressbar";
            this.checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            // 
            // CtrlOptionWhileSearching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBoxDoCountFilesOnSearch);
            this.Controls.Add(this.checkBoxDoCountFoldersOnSearch);
            this.Controls.Add(this.checkBoxDoViewFileNamesOnSearch);
            this.Name = "CtrlOptionWhileSearching";
            this.Size = new System.Drawing.Size(274, 352);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox checkBoxDoViewFileNamesOnSearch;
        public System.Windows.Forms.CheckBox checkBoxDoCountFoldersOnSearch;
        public System.Windows.Forms.CheckBox checkBoxDoCountFilesOnSearch;
        public System.Windows.Forms.CheckBox checkBox4;
    }
}
