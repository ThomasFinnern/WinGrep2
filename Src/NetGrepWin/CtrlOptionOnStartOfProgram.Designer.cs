namespace NetGrep
{
    partial class CtrlOptionOnStartOfProgram
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
            this.lblPopUpSearchOnStart = new System.Windows.Forms.Label();
            this.checkBoxDoPopUpSearchOnStart = new System.Windows.Forms.CheckBox();
            this.checkBoxDoRepeatLastSearchOnStart = new System.Windows.Forms.CheckBox();
            this.checkBoxDoLoadLastOpenSearches = new System.Windows.Forms.CheckBox();
            this.checkBoxDoViewLastUsedSearchResult = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPopUpSearchOnStart
            // 
            this.lblPopUpSearchOnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPopUpSearchOnStart.Location = new System.Drawing.Point(14, 150);
            this.lblPopUpSearchOnStart.Name = "lblPopUpSearchOnStart";
            this.lblPopUpSearchOnStart.Size = new System.Drawing.Size(198, 20);
            this.lblPopUpSearchOnStart.TabIndex = 1;
            this.lblPopUpSearchOnStart.Text = "Pop up search on start";
            this.lblPopUpSearchOnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPopUpSearchOnStart.Visible = false;
            // 
            // checkBoxDoPopUpSearchOnStart
            // 
            this.checkBoxDoPopUpSearchOnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxDoPopUpSearchOnStart.AutoSize = true;
            this.checkBoxDoPopUpSearchOnStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoPopUpSearchOnStart.Location = new System.Drawing.Point(103, 49);
            this.checkBoxDoPopUpSearchOnStart.Name = "checkBoxDoPopUpSearchOnStart";
            this.checkBoxDoPopUpSearchOnStart.Size = new System.Drawing.Size(149, 17);
            this.checkBoxDoPopUpSearchOnStart.TabIndex = 3;
            this.checkBoxDoPopUpSearchOnStart.Text = "Do pop up search on start";
            this.checkBoxDoPopUpSearchOnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoPopUpSearchOnStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoRepeatLastSearchOnStart
            // 
            this.checkBoxDoRepeatLastSearchOnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxDoRepeatLastSearchOnStart.AutoSize = true;
            this.checkBoxDoRepeatLastSearchOnStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoRepeatLastSearchOnStart.Location = new System.Drawing.Point(87, 72);
            this.checkBoxDoRepeatLastSearchOnStart.Name = "checkBoxDoRepeatLastSearchOnStart";
            this.checkBoxDoRepeatLastSearchOnStart.Size = new System.Drawing.Size(165, 17);
            this.checkBoxDoRepeatLastSearchOnStart.TabIndex = 4;
            this.checkBoxDoRepeatLastSearchOnStart.Text = "Do repeat last search on start";
            this.checkBoxDoRepeatLastSearchOnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoRepeatLastSearchOnStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoLoadLastOpenSearches
            // 
            this.checkBoxDoLoadLastOpenSearches.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxDoLoadLastOpenSearches.AutoSize = true;
            this.checkBoxDoLoadLastOpenSearches.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoLoadLastOpenSearches.Location = new System.Drawing.Point(47, 95);
            this.checkBoxDoLoadLastOpenSearches.Name = "checkBoxDoLoadLastOpenSearches";
            this.checkBoxDoLoadLastOpenSearches.Size = new System.Drawing.Size(205, 17);
            this.checkBoxDoLoadLastOpenSearches.TabIndex = 5;
            this.checkBoxDoLoadLastOpenSearches.Text = "Do load last opened searches on start";
            this.checkBoxDoLoadLastOpenSearches.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoLoadLastOpenSearches.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoViewLastUsedSearchResult
            // 
            this.checkBoxDoViewLastUsedSearchResult.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxDoViewLastUsedSearchResult.AutoSize = true;
            this.checkBoxDoViewLastUsedSearchResult.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoViewLastUsedSearchResult.Location = new System.Drawing.Point(79, 118);
            this.checkBoxDoViewLastUsedSearchResult.Name = "checkBoxDoViewLastUsedSearchResult";
            this.checkBoxDoViewLastUsedSearchResult.Size = new System.Drawing.Size(173, 17);
            this.checkBoxDoViewLastUsedSearchResult.TabIndex = 5;
            this.checkBoxDoViewLastUsedSearchResult.Text = "Do view last used search result";
            this.checkBoxDoViewLastUsedSearchResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDoViewLastUsedSearchResult.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Action on startup of program";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlOptionOnStartOfProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxDoViewLastUsedSearchResult);
            this.Controls.Add(this.checkBoxDoLoadLastOpenSearches);
            this.Controls.Add(this.checkBoxDoRepeatLastSearchOnStart);
            this.Controls.Add(this.checkBoxDoPopUpSearchOnStart);
            this.Controls.Add(this.lblPopUpSearchOnStart);
            this.Name = "CtrlOptionOnStartOfProgram";
            this.Size = new System.Drawing.Size(274, 352);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPopUpSearchOnStart;
        public System.Windows.Forms.CheckBox checkBoxDoPopUpSearchOnStart;
        public System.Windows.Forms.CheckBox checkBoxDoRepeatLastSearchOnStart;
        public System.Windows.Forms.CheckBox checkBoxDoLoadLastOpenSearches;
        public System.Windows.Forms.CheckBox checkBoxDoViewLastUsedSearchResult;
        private System.Windows.Forms.Label label2;
    }
}
