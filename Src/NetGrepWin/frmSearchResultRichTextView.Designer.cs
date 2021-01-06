namespace NetGrep
{
    partial class frmSearchResultRichTextView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRtf = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBoxLineIdx = new System.Windows.Forms.RichTextBox();
            this.richTextBoxFileContent = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdNextResult = new System.Windows.Forms.Button();
            this.cmdPreviousResult = new System.Windows.Forms.Button();
            this.lblNextResult = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDummy = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdPreviousFile = new System.Windows.Forms.Button();
            this.cmdNextFile = new System.Windows.Forms.Button();
            this.lblNextFile = new System.Windows.Forms.Label();
            this.panelFileName = new System.Windows.Forms.Panel();
            this.lblFileNameTitle = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelRtf.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFileName.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelRtf, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelFileName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 584);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanelRtf
            // 
            this.tableLayoutPanelRtf.AutoSize = true;
            this.tableLayoutPanelRtf.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelRtf.ColumnCount = 2;
            this.tableLayoutPanelRtf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelRtf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRtf.Controls.Add(this.richTextBoxLineIdx, 0, 0);
            this.tableLayoutPanelRtf.Controls.Add(this.richTextBoxFileContent, 1, 0);
            this.tableLayoutPanelRtf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRtf.Location = new System.Drawing.Point(3, 54);
            this.tableLayoutPanelRtf.Name = "tableLayoutPanelRtf";
            this.tableLayoutPanelRtf.RowCount = 1;
            this.tableLayoutPanelRtf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRtf.Size = new System.Drawing.Size(878, 494);
            this.tableLayoutPanelRtf.TabIndex = 1;
            // 
            // richTextBoxLineIdx
            // 
            this.richTextBoxLineIdx.BackColor = System.Drawing.SystemColors.ControlDark;
            this.richTextBoxLineIdx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLineIdx.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxLineIdx.Name = "richTextBoxLineIdx";
            this.richTextBoxLineIdx.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxLineIdx.Size = new System.Drawing.Size(44, 488);
            this.richTextBoxLineIdx.TabIndex = 2;
            this.richTextBoxLineIdx.Text = "";
            this.richTextBoxLineIdx.WordWrap = false;
            // 
            // richTextBoxFileContent
            // 
            this.richTextBoxFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxFileContent.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxFileContent.Location = new System.Drawing.Point(53, 3);
            this.richTextBoxFileContent.Name = "richTextBoxFileContent";
            this.richTextBoxFileContent.Size = new System.Drawing.Size(822, 488);
            this.richTextBoxFileContent.TabIndex = 0;
            this.richTextBoxFileContent.Text = "";
            this.richTextBoxFileContent.WordWrap = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(330, 24);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.cmdNextResult);
            this.panel2.Controls.Add(this.cmdPreviousResult);
            this.panel2.Controls.Add(this.lblNextResult);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 25);
            this.panel2.TabIndex = 1;
            // 
            // cmdNextResult
            // 
            this.cmdNextResult.Location = new System.Drawing.Point(110, 0);
            this.cmdNextResult.Name = "cmdNextResult";
            this.cmdNextResult.Size = new System.Drawing.Size(27, 22);
            this.cmdNextResult.TabIndex = 0;
            this.cmdNextResult.Text = ">";
            this.cmdNextResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNextResult.UseVisualStyleBackColor = true;
            this.cmdNextResult.Click += new System.EventHandler(this.cmdNextResult_Click);
            // 
            // cmdPreviousResult
            // 
            this.cmdPreviousResult.Location = new System.Drawing.Point(3, 0);
            this.cmdPreviousResult.Name = "cmdPreviousResult";
            this.cmdPreviousResult.Size = new System.Drawing.Size(27, 22);
            this.cmdPreviousResult.TabIndex = 4;
            this.cmdPreviousResult.Text = "<";
            this.cmdPreviousResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdPreviousResult.UseVisualStyleBackColor = true;
            this.cmdPreviousResult.Click += new System.EventHandler(this.cmdPreviousResult_Click);
            // 
            // lblNextResult
            // 
            this.lblNextResult.AutoSize = true;
            this.lblNextResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextResult.Location = new System.Drawing.Point(36, 4);
            this.lblNextResult.Name = "lblNextResult";
            this.lblNextResult.Size = new System.Drawing.Size(68, 13);
            this.lblNextResult.TabIndex = 3;
            this.lblNextResult.Text = "Next result";
            this.lblNextResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.lblDummy);
            this.panel3.Location = new System.Drawing.Point(149, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(46, 16);
            this.panel3.TabIndex = 3;
            // 
            // lblDummy
            // 
            this.lblDummy.AutoSize = true;
            this.lblDummy.Location = new System.Drawing.Point(33, 3);
            this.lblDummy.Name = "lblDummy";
            this.lblDummy.Size = new System.Drawing.Size(10, 13);
            this.lblDummy.TabIndex = 0;
            this.lblDummy.Text = " ";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.cmdPreviousFile);
            this.panel1.Controls.Add(this.cmdNextFile);
            this.panel1.Controls.Add(this.lblNextFile);
            this.panel1.Location = new System.Drawing.Point(201, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 25);
            this.panel1.TabIndex = 1;
            // 
            // cmdPreviousFile
            // 
            this.cmdPreviousFile.Location = new System.Drawing.Point(3, -1);
            this.cmdPreviousFile.Name = "cmdPreviousFile";
            this.cmdPreviousFile.Size = new System.Drawing.Size(27, 22);
            this.cmdPreviousFile.TabIndex = 4;
            this.cmdPreviousFile.Text = "<<";
            this.cmdPreviousFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdPreviousFile.UseVisualStyleBackColor = true;
            this.cmdPreviousFile.Click += new System.EventHandler(this.cmdPreviousFile_Click);
            // 
            // cmdNextFile
            // 
            this.cmdNextFile.Location = new System.Drawing.Point(96, 0);
            this.cmdNextFile.Name = "cmdNextFile";
            this.cmdNextFile.Size = new System.Drawing.Size(27, 22);
            this.cmdNextFile.TabIndex = 4;
            this.cmdNextFile.Text = ">>";
            this.cmdNextFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNextFile.UseVisualStyleBackColor = true;
            this.cmdNextFile.Click += new System.EventHandler(this.cmdNextFile_Click);
            // 
            // lblNextFile
            // 
            this.lblNextFile.AutoSize = true;
            this.lblNextFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextFile.Location = new System.Drawing.Point(36, 3);
            this.lblNextFile.Name = "lblNextFile";
            this.lblNextFile.Size = new System.Drawing.Size(54, 13);
            this.lblNextFile.TabIndex = 3;
            this.lblNextFile.Text = "Next file";
            this.lblNextFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFileName
            // 
            this.panelFileName.AutoSize = true;
            this.panelFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFileName.Controls.Add(this.lblFileNameTitle);
            this.panelFileName.Controls.Add(this.lblFileName);
            this.panelFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileName.Location = new System.Drawing.Point(3, 33);
            this.panelFileName.Name = "panelFileName";
            this.panelFileName.Size = new System.Drawing.Size(878, 15);
            this.panelFileName.TabIndex = 3;
            // 
            // lblFileNameTitle
            // 
            this.lblFileNameTitle.AutoSize = true;
            this.lblFileNameTitle.Location = new System.Drawing.Point(3, 0);
            this.lblFileNameTitle.Name = "lblFileNameTitle";
            this.lblFileNameTitle.Size = new System.Drawing.Size(55, 13);
            this.lblFileNameTitle.TabIndex = 2;
            this.lblFileNameTitle.Text = "Filename: ";
            this.lblFileNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(61, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(137, 13);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "SearchResultPathFileName";
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.cmdEdit);
            this.flowLayoutPanel2.Controls.Add(this.cmdOpen);
            this.flowLayoutPanel2.Controls.Add(this.cmdExit);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(656, 554);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(225, 27);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(3, 3);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(69, 21);
            this.cmdEdit.TabIndex = 0;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Visible = false;
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(78, 3);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(69, 21);
            this.cmdOpen.TabIndex = 0;
            this.cmdOpen.Text = "Open";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Visible = false;
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(153, 3);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(69, 21);
            this.cmdExit.TabIndex = 0;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // frmSearchResultRichTextView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 584);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSearchResultRichTextView";
            this.Text = "File content view";
            this.Load += new System.EventHandler(this.frmSearchResultRichTextView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelRtf.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFileName.ResumeLayout(false);
            this.panelFileName.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBoxFileContent;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblFileNameTitle;
        private System.Windows.Forms.Panel panelFileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNextFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cmdPreviousFile;
        private System.Windows.Forms.Button cmdNextFile;
        private System.Windows.Forms.Button cmdNextResult;
        private System.Windows.Forms.Button cmdPreviousResult;
        private System.Windows.Forms.Label lblNextResult;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDummy;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRtf;
        private System.Windows.Forms.RichTextBox richTextBoxLineIdx;
    }
}