namespace NetGrep
{
    partial class frmTestTRegularExpressionSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSearchString = new System.Windows.Forms.ComboBox();
            this.chkStopAfterFirstMatch = new System.Windows.Forms.CheckBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.chkUseRegularExpression = new System.Windows.Forms.CheckBox();
            this.chkWholeWordsOnly = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.webSearchResult = new System.Windows.Forms.WebBrowser();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkLinesWithNoMatch = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textSearchText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSave03 = new System.Windows.Forms.Button();
            this.cmdLoad03 = new System.Windows.Forms.Button();
            this.cmdSave02 = new System.Windows.Forms.Button();
            this.cmdLoad02 = new System.Windows.Forms.Button();
            this.cmdSave01 = new System.Windows.Forms.Button();
            this.cmdLoad01 = new System.Windows.Forms.Button();
            this.cmdStartSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(632, 505);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(73, 21);
            this.cmdExit.TabIndex = 26;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // lblOperationsTitle
            // 
            this.lblOperationsTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblOperationsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperationsTitle.BackColor = System.Drawing.Color.DarkGreen;
            this.lblOperationsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationsTitle.ForeColor = System.Drawing.Color.White;
            this.lblOperationsTitle.Location = new System.Drawing.Point(15, 9);
            this.lblOperationsTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOperationsTitle.Name = "lblOperationsTitle";
            this.lblOperationsTitle.Size = new System.Drawing.Size(687, 25);
            this.lblOperationsTitle.TabIndex = 28;
            this.lblOperationsTitle.Text = "Test regular expressions";
            this.lblOperationsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Search string";
            // 
            // cmbSearchString
            // 
            this.cmbSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSearchString.FormattingEnabled = true;
            this.cmbSearchString.Location = new System.Drawing.Point(19, 60);
            this.cmbSearchString.Name = "cmbSearchString";
            this.cmbSearchString.Size = new System.Drawing.Size(683, 21);
            this.cmbSearchString.TabIndex = 34;
            // 
            // chkStopAfterFirstMatch
            // 
            this.chkStopAfterFirstMatch.AutoSize = true;
            this.chkStopAfterFirstMatch.Location = new System.Drawing.Point(352, 3);
            this.chkStopAfterFirstMatch.Name = "chkStopAfterFirstMatch";
            this.chkStopAfterFirstMatch.Size = new System.Drawing.Size(124, 17);
            this.chkStopAfterFirstMatch.TabIndex = 33;
            this.chkStopAfterFirstMatch.Text = "Stop after first Match";
            this.chkStopAfterFirstMatch.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(263, 3);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(83, 17);
            this.chkMatchCase.TabIndex = 30;
            this.chkMatchCase.Text = "Match Case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // chkUseRegularExpression
            // 
            this.chkUseRegularExpression.AutoSize = true;
            this.chkUseRegularExpression.Location = new System.Drawing.Point(3, 3);
            this.chkUseRegularExpression.Name = "chkUseRegularExpression";
            this.chkUseRegularExpression.Size = new System.Drawing.Size(138, 17);
            this.chkUseRegularExpression.TabIndex = 31;
            this.chkUseRegularExpression.Text = "Use Regular expression";
            this.chkUseRegularExpression.UseVisualStyleBackColor = true;
            // 
            // chkWholeWordsOnly
            // 
            this.chkWholeWordsOnly.AutoSize = true;
            this.chkWholeWordsOnly.Location = new System.Drawing.Point(147, 3);
            this.chkWholeWordsOnly.Name = "chkWholeWordsOnly";
            this.chkWholeWordsOnly.Size = new System.Drawing.Size(110, 17);
            this.chkWholeWordsOnly.TabIndex = 29;
            this.chkWholeWordsOnly.Text = "Whole words only";
            this.chkWholeWordsOnly.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.webSearchResult, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textSearchText, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 87);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(681, 384);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // webSearchResult
            // 
            this.webSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webSearchResult.Location = new System.Drawing.Point(3, 212);
            this.webSearchResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.webSearchResult.Name = "webSearchResult";
            this.webSearchResult.Size = new System.Drawing.Size(675, 148);
            this.webSearchResult.TabIndex = 52;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.chkUseRegularExpression);
            this.flowLayoutPanel2.Controls.Add(this.chkWholeWordsOnly);
            this.flowLayoutPanel2.Controls.Add(this.chkMatchCase);
            this.flowLayoutPanel2.Controls.Add(this.chkStopAfterFirstMatch);
            this.flowLayoutPanel2.Controls.Add(this.chkLinesWithNoMatch);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(675, 23);
            this.flowLayoutPanel2.TabIndex = 45;
            // 
            // chkLinesWithNoMatch
            // 
            this.chkLinesWithNoMatch.Location = new System.Drawing.Point(482, 3);
            this.chkLinesWithNoMatch.Name = "chkLinesWithNoMatch";
            this.chkLinesWithNoMatch.Size = new System.Drawing.Size(138, 17);
            this.chkLinesWithNoMatch.TabIndex = 0;
            this.chkLinesWithNoMatch.Text = "Lines with no match";
            this.chkLinesWithNoMatch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Search text";
            // 
            // textSearchText
            // 
            this.textSearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSearchText.Location = new System.Drawing.Point(3, 45);
            this.textSearchText.Multiline = true;
            this.textSearchText.Name = "textSearchText";
            this.textSearchText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textSearchText.Size = new System.Drawing.Size(675, 148);
            this.textSearchText.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Search result";
            // 
            // cmdSave03
            // 
            this.cmdSave03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave03.Location = new System.Drawing.Point(179, 504);
            this.cmdSave03.Name = "cmdSave03";
            this.cmdSave03.Size = new System.Drawing.Size(73, 21);
            this.cmdSave03.TabIndex = 55;
            this.cmdSave03.Text = "Save 03";
            this.cmdSave03.UseVisualStyleBackColor = true;
            this.cmdSave03.Click += new System.EventHandler(this.cmdSave03_Click);
            // 
            // cmdLoad03
            // 
            this.cmdLoad03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoad03.Location = new System.Drawing.Point(179, 477);
            this.cmdLoad03.Name = "cmdLoad03";
            this.cmdLoad03.Size = new System.Drawing.Size(73, 21);
            this.cmdLoad03.TabIndex = 56;
            this.cmdLoad03.Text = "Load 03";
            this.cmdLoad03.UseVisualStyleBackColor = true;
            this.cmdLoad03.Click += new System.EventHandler(this.cmdLoad03_Click);
            // 
            // cmdSave02
            // 
            this.cmdSave02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave02.Location = new System.Drawing.Point(100, 504);
            this.cmdSave02.Name = "cmdSave02";
            this.cmdSave02.Size = new System.Drawing.Size(73, 21);
            this.cmdSave02.TabIndex = 57;
            this.cmdSave02.Text = "Save 02";
            this.cmdSave02.UseVisualStyleBackColor = true;
            this.cmdSave02.Click += new System.EventHandler(this.cmdSave02_Click);
            // 
            // cmdLoad02
            // 
            this.cmdLoad02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoad02.Location = new System.Drawing.Point(100, 477);
            this.cmdLoad02.Name = "cmdLoad02";
            this.cmdLoad02.Size = new System.Drawing.Size(73, 21);
            this.cmdLoad02.TabIndex = 58;
            this.cmdLoad02.Text = "Load 02";
            this.cmdLoad02.UseVisualStyleBackColor = true;
            this.cmdLoad02.Click += new System.EventHandler(this.cmdLoad02_Click);
            // 
            // cmdSave01
            // 
            this.cmdSave01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave01.Location = new System.Drawing.Point(21, 504);
            this.cmdSave01.Name = "cmdSave01";
            this.cmdSave01.Size = new System.Drawing.Size(73, 21);
            this.cmdSave01.TabIndex = 53;
            this.cmdSave01.Text = "Save 01";
            this.cmdSave01.UseVisualStyleBackColor = true;
            this.cmdSave01.Click += new System.EventHandler(this.cmdSave01_Click);
            // 
            // cmdLoad01
            // 
            this.cmdLoad01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoad01.Location = new System.Drawing.Point(21, 477);
            this.cmdLoad01.Name = "cmdLoad01";
            this.cmdLoad01.Size = new System.Drawing.Size(73, 21);
            this.cmdLoad01.TabIndex = 54;
            this.cmdLoad01.Text = "Load 01";
            this.cmdLoad01.UseVisualStyleBackColor = true;
            this.cmdLoad01.Click += new System.EventHandler(this.cmdLoad01_Click);
            // 
            // cmdStartSearch
            // 
            this.cmdStartSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartSearch.Location = new System.Drawing.Point(553, 504);
            this.cmdStartSearch.Name = "cmdStartSearch";
            this.cmdStartSearch.Size = new System.Drawing.Size(73, 23);
            this.cmdStartSearch.TabIndex = 52;
            this.cmdStartSearch.Text = "Start search";
            this.cmdStartSearch.UseVisualStyleBackColor = true;
            this.cmdStartSearch.Click += new System.EventHandler(this.cmdStartSearch_Click);
            // 
            // frmTestTRegularExpressionSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 538);
            this.Controls.Add(this.cmdSave03);
            this.Controls.Add(this.cmdLoad03);
            this.Controls.Add(this.cmdSave02);
            this.Controls.Add(this.cmdLoad02);
            this.Controls.Add(this.cmdSave01);
            this.Controls.Add(this.cmdLoad01);
            this.Controls.Add(this.cmdStartSearch);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSearchString);
            this.Controls.Add(this.lblOperationsTitle);
            this.Controls.Add(this.cmdExit);
            this.Name = "frmTestTRegularExpressionSearch";
            this.Text = "Test regular expressions";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTestTRegularExpressionSearch_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label lblOperationsTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSearchString;
        private System.Windows.Forms.CheckBox chkStopAfterFirstMatch;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.CheckBox chkUseRegularExpression;
        private System.Windows.Forms.CheckBox chkWholeWordsOnly;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.WebBrowser webSearchResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textSearchText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox chkLinesWithNoMatch;
        private System.Windows.Forms.Button cmdSave03;
        private System.Windows.Forms.Button cmdLoad03;
        private System.Windows.Forms.Button cmdSave02;
        private System.Windows.Forms.Button cmdLoad02;
        private System.Windows.Forms.Button cmdSave01;
        private System.Windows.Forms.Button cmdLoad01;
        private System.Windows.Forms.Button cmdStartSearch;
    }
}