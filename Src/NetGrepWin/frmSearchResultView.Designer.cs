namespace NetGrep
{
    partial class frmSearchResultView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchResultView));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblTitleText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusActInfoText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelFolders = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblFolderNbrText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblFileNbrText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLbTimeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.webFileList = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webSearchResult = new System.Windows.Forms.WebBrowser();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownPostLines = new System.Windows.Forms.NumericUpDown();
            this.lblPostLines = new System.Windows.Forms.Label();
            this.numericUpDownPreLines = new System.Windows.Forms.NumericUpDown();
            this.lblPreLines = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.checkBoxDoShowTitle = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxDoShowLineNbrs = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBoxDoShowFixedFont = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.checkBoxDoShowFileNames = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.checkBoxDoShowFileContents = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxDoShowWholeLine = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBoxDoShowDoubleBlanks = new System.Windows.Forms.CheckBox();
            this.TimerUpdateInfos2 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPostLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreLines)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelTitle,
            this.toolStripStatusLblTitleText,
            this.toolStripLblInfo,
            this.toolStripStatusActInfoText,
            this.toolStripProgressBar1,
            this.toolStripStatusLabelFolders,
            this.toolStripStatusLblFolderNbrText,
            this.toolStripStatusLabelFiles,
            this.toolStripStatusLblFileNbrText,
            this.toolStripStatusLabel1,
            this.toolStripStatusLbTimeText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 626);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(981, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLabelTitle
            // 
            this.toolStripLabelTitle.Name = "toolStripLabelTitle";
            this.toolStripLabelTitle.Size = new System.Drawing.Size(35, 17);
            this.toolStripLabelTitle.Text = "Title: ";
            // 
            // toolStripStatusLblTitleText
            // 
            this.toolStripStatusLblTitleText.AutoSize = false;
            this.toolStripStatusLblTitleText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLblTitleText.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolStripStatusLblTitleText.Name = "toolStripStatusLblTitleText";
            this.toolStripStatusLblTitleText.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLblTitleText.Text = "untouched";
            // 
            // toolStripLblInfo
            // 
            this.toolStripLblInfo.Name = "toolStripLblInfo";
            this.toolStripLblInfo.Size = new System.Drawing.Size(34, 17);
            this.toolStripLblInfo.Text = "Info: ";
            // 
            // toolStripStatusActInfoText
            // 
            this.toolStripStatusActInfoText.AutoSize = false;
            this.toolStripStatusActInfoText.Name = "toolStripStatusActInfoText";
            this.toolStripStatusActInfoText.Size = new System.Drawing.Size(300, 17);
            this.toolStripStatusActInfoText.Text = "Actual Info";
            this.toolStripStatusActInfoText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.OliveDrab;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabelFolders
            // 
            this.toolStripStatusLabelFolders.Name = "toolStripStatusLabelFolders";
            this.toolStripStatusLabelFolders.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabelFolders.Text = "Folder:";
            // 
            // toolStripStatusLblFolderNbrText
            // 
            this.toolStripStatusLblFolderNbrText.AutoSize = false;
            this.toolStripStatusLblFolderNbrText.Name = "toolStripStatusLblFolderNbrText";
            this.toolStripStatusLblFolderNbrText.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLblFolderNbrText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelFiles
            // 
            this.toolStripStatusLabelFiles.Name = "toolStripStatusLabelFiles";
            this.toolStripStatusLabelFiles.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabelFiles.Text = "Files:";
            // 
            // toolStripStatusLblFileNbrText
            // 
            this.toolStripStatusLblFileNbrText.AutoSize = false;
            this.toolStripStatusLblFileNbrText.Name = "toolStripStatusLblFileNbrText";
            this.toolStripStatusLblFileNbrText.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLblFileNbrText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel1.Text = "Time:";
            // 
            // toolStripStatusLbTimeText
            // 
            this.toolStripStatusLbTimeText.AutoSize = false;
            this.toolStripStatusLbTimeText.Name = "toolStripStatusLbTimeText";
            this.toolStripStatusLbTimeText.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLbTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // webFileList
            // 
            this.webFileList.AllowWebBrowserDrop = false;
            this.webFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webFileList.IsWebBrowserContextMenuEnabled = false;
            this.webFileList.Location = new System.Drawing.Point(0, 0);
            this.webFileList.MinimumSize = new System.Drawing.Size(20, 20);
            this.webFileList.Name = "webFileList";
            this.webFileList.Size = new System.Drawing.Size(973, 251);
            this.webFileList.TabIndex = 10;
            this.webFileList.WebBrowserShortcutsEnabled = false;
            this.webFileList.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webFileList_PreviewKeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(981, 626);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 39);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.webFileList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.webSearchResult);
            this.splitContainer1.Size = new System.Drawing.Size(975, 584);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // webSearchResult
            // 
            this.webSearchResult.AllowWebBrowserDrop = false;
            this.webSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webSearchResult.IsWebBrowserContextMenuEnabled = false;
            this.webSearchResult.Location = new System.Drawing.Point(0, 0);
            this.webSearchResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.webSearchResult.Name = "webSearchResult";
            this.webSearchResult.Size = new System.Drawing.Size(973, 326);
            this.webSearchResult.TabIndex = 12;
            this.webSearchResult.WebBrowserShortcutsEnabled = false;
            this.webSearchResult.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webSearchResult_PreviewKeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(975, 30);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownPostLines);
            this.panel1.Controls.Add(this.lblPostLines);
            this.panel1.Controls.Add(this.numericUpDownPreLines);
            this.panel1.Controls.Add(this.lblPreLines);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 24);
            this.panel1.TabIndex = 13;
            // 
            // numericUpDownPostLines
            // 
            this.numericUpDownPostLines.Location = new System.Drawing.Point(175, 3);
            this.numericUpDownPostLines.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownPostLines.Name = "numericUpDownPostLines";
            this.numericUpDownPostLines.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownPostLines.TabIndex = 4;
            this.numericUpDownPostLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPostLines.ValueChanged += new System.EventHandler(this.numericUpDownPostLines_ValueChanged);
            // 
            // lblPostLines
            // 
            this.lblPostLines.AutoSize = true;
            this.lblPostLines.Location = new System.Drawing.Point(117, 5);
            this.lblPostLines.Name = "lblPostLines";
            this.lblPostLines.Size = new System.Drawing.Size(58, 13);
            this.lblPostLines.TabIndex = 3;
            this.lblPostLines.Text = "Post. lines ";
            this.lblPostLines.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // numericUpDownPreLines
            // 
            this.numericUpDownPreLines.Location = new System.Drawing.Point(66, 3);
            this.numericUpDownPreLines.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownPreLines.Name = "numericUpDownPreLines";
            this.numericUpDownPreLines.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownPreLines.TabIndex = 2;
            this.numericUpDownPreLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPreLines.ValueChanged += new System.EventHandler(this.numericUpDownPreLines_ValueChanged);
            // 
            // lblPreLines
            // 
            this.lblPreLines.AutoSize = true;
            this.lblPreLines.Location = new System.Drawing.Point(3, 5);
            this.lblPreLines.Name = "lblPreLines";
            this.lblPreLines.Size = new System.Drawing.Size(53, 13);
            this.lblPreLines.TabIndex = 0;
            this.lblPreLines.Text = "Pre. lines ";
            this.lblPreLines.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.Controls.Add(this.checkBoxDoShowTitle);
            this.panel8.Location = new System.Drawing.Point(230, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(52, 24);
            this.panel8.TabIndex = 13;
            // 
            // checkBoxDoShowTitle
            // 
            this.checkBoxDoShowTitle.AutoSize = true;
            this.checkBoxDoShowTitle.Location = new System.Drawing.Point(3, 4);
            this.checkBoxDoShowTitle.Name = "checkBoxDoShowTitle";
            this.checkBoxDoShowTitle.Size = new System.Drawing.Size(46, 17);
            this.checkBoxDoShowTitle.TabIndex = 0;
            this.checkBoxDoShowTitle.Text = "Title";
            this.checkBoxDoShowTitle.UseVisualStyleBackColor = true;
            this.checkBoxDoShowTitle.CheckedChanged += new System.EventHandler(this.checkBoxDoShowTitle_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxDoShowLineNbrs);
            this.panel2.Location = new System.Drawing.Point(288, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 24);
            this.panel2.TabIndex = 13;
            // 
            // checkBoxDoShowLineNbrs
            // 
            this.checkBoxDoShowLineNbrs.AutoSize = true;
            this.checkBoxDoShowLineNbrs.Location = new System.Drawing.Point(3, 4);
            this.checkBoxDoShowLineNbrs.Name = "checkBoxDoShowLineNbrs";
            this.checkBoxDoShowLineNbrs.Size = new System.Drawing.Size(89, 17);
            this.checkBoxDoShowLineNbrs.TabIndex = 0;
            this.checkBoxDoShowLineNbrs.Text = "Line numbers";
            this.checkBoxDoShowLineNbrs.UseVisualStyleBackColor = true;
            this.checkBoxDoShowLineNbrs.CheckedChanged += new System.EventHandler(this.checkBoxDoShowLineNbrs_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.checkBoxDoShowFixedFont);
            this.panel4.Location = new System.Drawing.Point(391, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(82, 24);
            this.panel4.TabIndex = 13;
            // 
            // checkBoxDoShowFixedFont
            // 
            this.checkBoxDoShowFixedFont.AutoSize = true;
            this.checkBoxDoShowFixedFont.Location = new System.Drawing.Point(3, 4);
            this.checkBoxDoShowFixedFont.Name = "checkBoxDoShowFixedFont";
            this.checkBoxDoShowFixedFont.Size = new System.Drawing.Size(76, 17);
            this.checkBoxDoShowFixedFont.TabIndex = 0;
            this.checkBoxDoShowFixedFont.Text = "*Fixed font";
            this.checkBoxDoShowFixedFont.UseVisualStyleBackColor = true;
            this.checkBoxDoShowFixedFont.Visible = false;
            this.checkBoxDoShowFixedFont.CheckedChanged += new System.EventHandler(this.checkBoxDoShowFixedFont_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this.checkBoxDoShowFileNames);
            this.panel6.Location = new System.Drawing.Point(479, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(86, 24);
            this.panel6.TabIndex = 13;
            // 
            // checkBoxDoShowFileNames
            // 
            this.checkBoxDoShowFileNames.AutoSize = true;
            this.checkBoxDoShowFileNames.Location = new System.Drawing.Point(3, 4);
            this.checkBoxDoShowFileNames.Name = "checkBoxDoShowFileNames";
            this.checkBoxDoShowFileNames.Size = new System.Drawing.Size(80, 17);
            this.checkBoxDoShowFileNames.TabIndex = 0;
            this.checkBoxDoShowFileNames.Text = "*File names";
            this.checkBoxDoShowFileNames.UseVisualStyleBackColor = true;
            this.checkBoxDoShowFileNames.CheckedChanged += new System.EventHandler(this.checkBoxDoShowFileNames_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.Controls.Add(this.checkBoxDoShowFileContents);
            this.panel7.Location = new System.Drawing.Point(571, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(96, 24);
            this.panel7.TabIndex = 13;
            // 
            // checkBoxDoShowFileContents
            // 
            this.checkBoxDoShowFileContents.AutoSize = true;
            this.checkBoxDoShowFileContents.Location = new System.Drawing.Point(3, 4);
            this.checkBoxDoShowFileContents.Name = "checkBoxDoShowFileContents";
            this.checkBoxDoShowFileContents.Size = new System.Drawing.Size(90, 17);
            this.checkBoxDoShowFileContents.TabIndex = 0;
            this.checkBoxDoShowFileContents.Text = "*File contents";
            this.checkBoxDoShowFileContents.UseVisualStyleBackColor = true;
            this.checkBoxDoShowFileContents.CheckedChanged += new System.EventHandler(this.checkBoxDoShowFileContents_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.checkBoxDoShowWholeLine);
            this.panel3.Location = new System.Drawing.Point(673, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(86, 24);
            this.panel3.TabIndex = 13;
            // 
            // checkBoxDoShowWholeLine
            // 
            this.checkBoxDoShowWholeLine.AutoSize = true;
            this.checkBoxDoShowWholeLine.Location = new System.Drawing.Point(3, 4);
            this.checkBoxDoShowWholeLine.Name = "checkBoxDoShowWholeLine";
            this.checkBoxDoShowWholeLine.Size = new System.Drawing.Size(80, 17);
            this.checkBoxDoShowWholeLine.TabIndex = 0;
            this.checkBoxDoShowWholeLine.Text = "*Whole line";
            this.checkBoxDoShowWholeLine.UseVisualStyleBackColor = true;
            this.checkBoxDoShowWholeLine.CheckedChanged += new System.EventHandler(this.checkBoxDoShowWholeLine_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.checkBoxDoShowDoubleBlanks);
            this.panel5.Location = new System.Drawing.Point(765, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(104, 24);
            this.panel5.TabIndex = 14;
            // 
            // checkBoxDoShowDoubleBlanks
            // 
            this.checkBoxDoShowDoubleBlanks.AutoSize = true;
            this.checkBoxDoShowDoubleBlanks.Location = new System.Drawing.Point(3, 4);
            this.checkBoxDoShowDoubleBlanks.Name = "checkBoxDoShowDoubleBlanks";
            this.checkBoxDoShowDoubleBlanks.Size = new System.Drawing.Size(98, 17);
            this.checkBoxDoShowDoubleBlanks.TabIndex = 15;
            this.checkBoxDoShowDoubleBlanks.Text = "*Double blanks";
            this.checkBoxDoShowDoubleBlanks.UseVisualStyleBackColor = true;
            // 
            // frmSearchResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(981, 648);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmSearchResultView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search results";
            this.Shown += new System.EventHandler(this.frmDoSearch_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchResultView_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPostLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreLines)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelTitle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLblInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusActInfoText;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.WebBrowser webFileList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblTitleText;
        private System.Windows.Forms.WebBrowser webSearchResult;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDownPostLines;
        private System.Windows.Forms.Label lblPostLines;
        private System.Windows.Forms.NumericUpDown numericUpDownPreLines;
        private System.Windows.Forms.Label lblPreLines;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxDoShowLineNbrs;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBoxDoShowWholeLine;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBoxDoShowFixedFont;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox checkBoxDoShowFileNames;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox checkBoxDoShowFileContents;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox checkBoxDoShowTitle;
        private System.Windows.Forms.Timer TimerUpdateInfos2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFolders;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblFolderNbrText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFiles;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblFileNbrText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLbTimeText;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBoxDoShowDoubleBlanks;
    }
}