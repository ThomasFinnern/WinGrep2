namespace NetGrep
{
    partial class frmReplaceProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplaceProperties));
            this.lblReplacePropertiesTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panlBackupFoldersSpezification = new System.Windows.Forms.Panel();
            this.chkbUseBackupFolder = new System.Windows.Forms.CheckBox();
            this.cmdFolderListView = new System.Windows.Forms.Button();
            this.cmbBackupFolder = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdbtBackupFolderSpezifikationView = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmbReplaceString = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbSearchString = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdbtReplaceFlagSpecificationView = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelFileSpecification = new System.Windows.Forms.FlowLayoutPanel();
            this.chkReplaceInSelectedFiles = new System.Windows.Forms.CheckBox();
            this.chkReplaceConfirmEachReplace = new System.Windows.Forms.CheckBox();
            this.chkCreateBackup = new System.Windows.Forms.CheckBox();
            this.chkReplaceOriginalFile = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdStartReplace = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panlBackupFoldersSpezification.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanelFileSpecification.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReplacePropertiesTitle
            // 
            this.lblReplacePropertiesTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblReplacePropertiesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReplacePropertiesTitle.BackColor = System.Drawing.Color.DarkKhaki;
            this.lblReplacePropertiesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacePropertiesTitle.ForeColor = System.Drawing.Color.Yellow;
            this.lblReplacePropertiesTitle.Location = new System.Drawing.Point(9, 9);
            this.lblReplacePropertiesTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReplacePropertiesTitle.Name = "lblReplacePropertiesTitle";
            this.lblReplacePropertiesTitle.Size = new System.Drawing.Size(471, 25);
            this.lblReplacePropertiesTitle.TabIndex = 6;
            this.lblReplacePropertiesTitle.Text = "Replace properties";
            this.lblReplacePropertiesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panlBackupFoldersSpezification, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelFileSpecification, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 303);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panlBackupFoldersSpezification
            // 
            this.panlBackupFoldersSpezification.Controls.Add(this.chkbUseBackupFolder);
            this.panlBackupFoldersSpezification.Controls.Add(this.cmdFolderListView);
            this.panlBackupFoldersSpezification.Controls.Add(this.cmbBackupFolder);
            this.panlBackupFoldersSpezification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panlBackupFoldersSpezification.Location = new System.Drawing.Point(3, 226);
            this.panlBackupFoldersSpezification.Name = "panlBackupFoldersSpezification";
            this.panlBackupFoldersSpezification.Size = new System.Drawing.Size(462, 54);
            this.panlBackupFoldersSpezification.TabIndex = 39;
            // 
            // chkbUseBackupFolder
            // 
            this.chkbUseBackupFolder.AutoSize = true;
            this.chkbUseBackupFolder.Enabled = false;
            this.chkbUseBackupFolder.Location = new System.Drawing.Point(3, 7);
            this.chkbUseBackupFolder.Name = "chkbUseBackupFolder";
            this.chkbUseBackupFolder.Size = new System.Drawing.Size(113, 17);
            this.chkbUseBackupFolder.TabIndex = 29;
            this.chkbUseBackupFolder.Text = "Use backup folder";
            this.chkbUseBackupFolder.UseVisualStyleBackColor = true;
            this.chkbUseBackupFolder.Visible = false;
            // 
            // cmdFolderListView
            // 
            this.cmdFolderListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFolderListView.Location = new System.Drawing.Point(440, 29);
            this.cmdFolderListView.Name = "cmdFolderListView";
            this.cmdFolderListView.Size = new System.Drawing.Size(22, 21);
            this.cmdFolderListView.TabIndex = 28;
            this.cmdFolderListView.Text = "...";
            this.cmdFolderListView.UseVisualStyleBackColor = true;
            // 
            // cmbBackupFolder
            // 
            this.cmbBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBackupFolder.FormattingEnabled = true;
            this.cmbBackupFolder.Location = new System.Drawing.Point(3, 30);
            this.cmbBackupFolder.Name = "cmbBackupFolder";
            this.cmbBackupFolder.Size = new System.Drawing.Size(433, 21);
            this.cmbBackupFolder.TabIndex = 2;
            this.cmbBackupFolder.Visible = false;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.rdbtBackupFolderSpezifikationView);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(3, 202);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(150, 18);
            this.panel5.TabIndex = 37;
            // 
            // rdbtBackupFolderSpezifikationView
            // 
            this.rdbtBackupFolderSpezifikationView.AutoSize = true;
            this.rdbtBackupFolderSpezifikationView.Location = new System.Drawing.Point(110, -2);
            this.rdbtBackupFolderSpezifikationView.Name = "rdbtBackupFolderSpezifikationView";
            this.rdbtBackupFolderSpezifikationView.Size = new System.Drawing.Size(37, 17);
            this.rdbtBackupFolderSpezifikationView.TabIndex = 39;
            this.rdbtBackupFolderSpezifikationView.TabStop = true;
            this.rdbtBackupFolderSpezifikationView.Text = "[+]";
            this.rdbtBackupFolderSpezifikationView.UseVisualStyleBackColor = true;
            this.rdbtBackupFolderSpezifikationView.Click += new System.EventHandler(this.rdbtBackupFolderSpezifikationView_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "*Backup folders";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.cmbReplaceString);
            this.panel7.Location = new System.Drawing.Point(3, 81);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(462, 26);
            this.panel7.TabIndex = 38;
            // 
            // cmbReplaceString
            // 
            this.cmbReplaceString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReplaceString.FormattingEnabled = true;
            this.cmbReplaceString.Location = new System.Drawing.Point(3, 0);
            this.cmbReplaceString.Name = "cmbReplaceString";
            this.cmbReplaceString.Size = new System.Drawing.Size(459, 21);
            this.cmbReplaceString.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.cmbSearchString);
            this.panel2.Location = new System.Drawing.Point(3, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 21);
            this.panel2.TabIndex = 0;
            // 
            // cmbSearchString
            // 
            this.cmbSearchString.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbSearchString.FormattingEnabled = true;
            this.cmbSearchString.Location = new System.Drawing.Point(0, 0);
            this.cmbSearchString.Name = "cmbSearchString";
            this.cmbSearchString.Size = new System.Drawing.Size(462, 21);
            this.cmbSearchString.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this.rdbtReplaceFlagSpecificationView);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(3, 58);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(150, 17);
            this.panel6.TabIndex = 37;
            // 
            // rdbtReplaceFlagSpecificationView
            // 
            this.rdbtReplaceFlagSpecificationView.AutoSize = true;
            this.rdbtReplaceFlagSpecificationView.Location = new System.Drawing.Point(110, -2);
            this.rdbtReplaceFlagSpecificationView.Name = "rdbtReplaceFlagSpecificationView";
            this.rdbtReplaceFlagSpecificationView.Size = new System.Drawing.Size(37, 17);
            this.rdbtReplaceFlagSpecificationView.TabIndex = 42;
            this.rdbtReplaceFlagSpecificationView.TabStop = true;
            this.rdbtReplaceFlagSpecificationView.Text = "[+]";
            this.rdbtReplaceFlagSpecificationView.UseVisualStyleBackColor = true;
            this.rdbtReplaceFlagSpecificationView.Click += new System.EventHandler(this.rdbtReplaceFlagSpecification_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Replace string";
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(85, 13);
            this.panel4.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Search string";
            // 
            // flowLayoutPanelFileSpecification
            // 
            this.flowLayoutPanelFileSpecification.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFileSpecification.AutoSize = true;
            this.flowLayoutPanelFileSpecification.Controls.Add(this.chkReplaceInSelectedFiles);
            this.flowLayoutPanelFileSpecification.Controls.Add(this.chkReplaceConfirmEachReplace);
            this.flowLayoutPanelFileSpecification.Controls.Add(this.chkCreateBackup);
            this.flowLayoutPanelFileSpecification.Controls.Add(this.chkReplaceOriginalFile);
            this.flowLayoutPanelFileSpecification.Location = new System.Drawing.Point(3, 113);
            this.flowLayoutPanelFileSpecification.Name = "flowLayoutPanelFileSpecification";
            this.flowLayoutPanelFileSpecification.Size = new System.Drawing.Size(462, 83);
            this.flowLayoutPanelFileSpecification.TabIndex = 41;
            // 
            // chkReplaceInSelectedFiles
            // 
            this.chkReplaceInSelectedFiles.AutoSize = true;
            this.chkReplaceInSelectedFiles.Location = new System.Drawing.Point(3, 3);
            this.chkReplaceInSelectedFiles.Name = "chkReplaceInSelectedFiles";
            this.chkReplaceInSelectedFiles.Size = new System.Drawing.Size(141, 17);
            this.chkReplaceInSelectedFiles.TabIndex = 29;
            this.chkReplaceInSelectedFiles.Text = "Replace in selected files";
            this.chkReplaceInSelectedFiles.UseVisualStyleBackColor = true;
            // 
            // chkReplaceConfirmEachReplace
            // 
            this.chkReplaceConfirmEachReplace.AutoSize = true;
            this.chkReplaceConfirmEachReplace.Location = new System.Drawing.Point(150, 3);
            this.chkReplaceConfirmEachReplace.Name = "chkReplaceConfirmEachReplace";
            this.chkReplaceConfirmEachReplace.Size = new System.Drawing.Size(126, 17);
            this.chkReplaceConfirmEachReplace.TabIndex = 28;
            this.chkReplaceConfirmEachReplace.Text = "Confirm each replace";
            this.chkReplaceConfirmEachReplace.UseVisualStyleBackColor = true;
            // 
            // chkCreateBackup
            // 
            this.chkCreateBackup.AutoSize = true;
            this.chkCreateBackup.Location = new System.Drawing.Point(282, 3);
            this.chkCreateBackup.Name = "chkCreateBackup";
            this.chkCreateBackup.Size = new System.Drawing.Size(97, 17);
            this.chkCreateBackup.TabIndex = 26;
            this.chkCreateBackup.Text = "Create Backup";
            this.chkCreateBackup.UseVisualStyleBackColor = true;
            // 
            // chkReplaceOriginalFile
            // 
            this.chkReplaceOriginalFile.AutoSize = true;
            this.chkReplaceOriginalFile.Location = new System.Drawing.Point(3, 26);
            this.chkReplaceOriginalFile.Name = "chkReplaceOriginalFile";
            this.chkReplaceOriginalFile.Size = new System.Drawing.Size(118, 17);
            this.chkReplaceOriginalFile.TabIndex = 27;
            this.chkReplaceOriginalFile.Text = "Replace original file";
            this.chkReplaceOriginalFile.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(248, 353);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(73, 21);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(404, 353);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(73, 21);
            this.cmdExit.TabIndex = 10;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdStartReplace
            // 
            this.cmdStartReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartReplace.Location = new System.Drawing.Point(327, 353);
            this.cmdStartReplace.Name = "cmdStartReplace";
            this.cmdStartReplace.Size = new System.Drawing.Size(73, 21);
            this.cmdStartReplace.TabIndex = 8;
            this.cmdStartReplace.Text = "Replace";
            this.cmdStartReplace.UseVisualStyleBackColor = true;
            this.cmdStartReplace.Click += new System.EventHandler(this.cmdStartReplace_Click);
            // 
            // frmReplaceProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 386);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdStartReplace);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblReplacePropertiesTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReplaceProperties";
            this.Text = "frnSearchReplace";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panlBackupFoldersSpezification.ResumeLayout(false);
            this.panlBackupFoldersSpezification.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanelFileSpecification.ResumeLayout(false);
            this.flowLayoutPanelFileSpecification.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblReplacePropertiesTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panlBackupFoldersSpezification;
        private System.Windows.Forms.Button cmdFolderListView;
        private System.Windows.Forms.ComboBox cmbBackupFolder;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rdbtBackupFolderSpezifikationView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox cmbReplaceString;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbSearchString;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton rdbtReplaceFlagSpecificationView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFileSpecification;
        private System.Windows.Forms.CheckBox chkReplaceInSelectedFiles;
        private System.Windows.Forms.CheckBox chkReplaceConfirmEachReplace;
        private System.Windows.Forms.CheckBox chkCreateBackup;
        private System.Windows.Forms.CheckBox chkReplaceOriginalFile;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdStartReplace;
        private System.Windows.Forms.CheckBox chkbUseBackupFolder;
    }
}