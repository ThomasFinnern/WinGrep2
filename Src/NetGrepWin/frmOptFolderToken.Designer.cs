namespace NetGrep
{
    partial class frmOptFolderToken
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
            this.cmdDeleteSelected = new System.Windows.Forms.Button();
            this.cmdAddNewSearchString = new System.Windows.Forms.Button();
            this.textBoxNewSearchString = new System.Windows.Forms.TextBox();
            this.checkedListBoxToken = new System.Windows.Forms.CheckedListBox();
            this.textBoxMaxFixedNumber = new System.Windows.Forms.TextBox();
            this.textBoxMaxTokenNumber = new System.Windows.Forms.TextBox();
            this.textBoxMFirstFixedTokenNumber = new System.Windows.Forms.TextBox();
            this.textBoxPreFixedTokenNumber = new System.Windows.Forms.TextBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAssign = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTokenTitle = new System.Windows.Forms.Label();
            this.lblSearchPropertiesTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdDeleteSelected
            // 
            this.cmdDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDeleteSelected.Location = new System.Drawing.Point(322, 115);
            this.cmdDeleteSelected.Name = "cmdDeleteSelected";
            this.cmdDeleteSelected.Size = new System.Drawing.Size(94, 20);
            this.cmdDeleteSelected.TabIndex = 70;
            this.cmdDeleteSelected.Text = "Delete Selected";
            this.cmdDeleteSelected.UseVisualStyleBackColor = true;
            this.cmdDeleteSelected.Click += new System.EventHandler(this.cmdDeleteSelected_Click);
            // 
            // cmdAddNewSearchString
            // 
            this.cmdAddNewSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddNewSearchString.Location = new System.Drawing.Point(485, 67);
            this.cmdAddNewSearchString.Name = "cmdAddNewSearchString";
            this.cmdAddNewSearchString.Size = new System.Drawing.Size(49, 20);
            this.cmdAddNewSearchString.TabIndex = 69;
            this.cmdAddNewSearchString.Text = "Add";
            this.cmdAddNewSearchString.UseVisualStyleBackColor = true;
            this.cmdAddNewSearchString.Click += new System.EventHandler(this.cmdAddNewSearchString_Click);
            // 
            // textBoxNewSearchString
            // 
            this.textBoxNewSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewSearchString.Location = new System.Drawing.Point(15, 67);
            this.textBoxNewSearchString.Name = "textBoxNewSearchString";
            this.textBoxNewSearchString.Size = new System.Drawing.Size(464, 20);
            this.textBoxNewSearchString.TabIndex = 68;
            // 
            // checkedListBoxToken
            // 
            this.checkedListBoxToken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxToken.FormattingEnabled = true;
            this.checkedListBoxToken.HorizontalScrollbar = true;
            this.checkedListBoxToken.Location = new System.Drawing.Point(15, 115);
            this.checkedListBoxToken.Name = "checkedListBoxToken";
            this.checkedListBoxToken.Size = new System.Drawing.Size(290, 227);
            this.checkedListBoxToken.TabIndex = 67;
            // 
            // textBoxMaxFixedNumber
            // 
            this.textBoxMaxFixedNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMaxFixedNumber.Location = new System.Drawing.Point(467, 322);
            this.textBoxMaxFixedNumber.Name = "textBoxMaxFixedNumber";
            this.textBoxMaxFixedNumber.Size = new System.Drawing.Size(67, 20);
            this.textBoxMaxFixedNumber.TabIndex = 64;
            // 
            // textBoxMaxTokenNumber
            // 
            this.textBoxMaxTokenNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMaxTokenNumber.Location = new System.Drawing.Point(467, 296);
            this.textBoxMaxTokenNumber.Name = "textBoxMaxTokenNumber";
            this.textBoxMaxTokenNumber.Size = new System.Drawing.Size(67, 20);
            this.textBoxMaxTokenNumber.TabIndex = 63;
            // 
            // textBoxMFirstFixedTokenNumber
            // 
            this.textBoxMFirstFixedTokenNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMFirstFixedTokenNumber.Location = new System.Drawing.Point(467, 270);
            this.textBoxMFirstFixedTokenNumber.Name = "textBoxMFirstFixedTokenNumber";
            this.textBoxMFirstFixedTokenNumber.Size = new System.Drawing.Size(67, 20);
            this.textBoxMFirstFixedTokenNumber.TabIndex = 66;
            // 
            // textBoxPreFixedTokenNumber
            // 
            this.textBoxPreFixedTokenNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPreFixedTokenNumber.Location = new System.Drawing.Point(467, 244);
            this.textBoxPreFixedTokenNumber.Name = "textBoxPreFixedTokenNumber";
            this.textBoxPreFixedTokenNumber.Size = new System.Drawing.Size(67, 20);
            this.textBoxPreFixedTokenNumber.TabIndex = 65;
            // 
            // cmdClear
            // 
            this.cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClear.Location = new System.Drawing.Point(104, 363);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(103, 25);
            this.cmdClear.TabIndex = 62;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(322, 363);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(103, 25);
            this.cmdCancel.TabIndex = 61;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAssign
            // 
            this.cmdAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAssign.Location = new System.Drawing.Point(213, 363);
            this.cmdAssign.Name = "cmdAssign";
            this.cmdAssign.Size = new System.Drawing.Size(103, 25);
            this.cmdAssign.TabIndex = 60;
            this.cmdAssign.Text = "Assign";
            this.cmdAssign.UseVisualStyleBackColor = true;
            this.cmdAssign.Click += new System.EventHandler(this.cmdAssign_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(431, 363);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 25);
            this.btnExit.TabIndex = 59;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(312, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "Max fixed number";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(312, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Max token number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(312, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "First fixed token number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(312, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 58;
            this.label1.Text = "Pre fixed token number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "New folder string";
            // 
            // lblTokenTitle
            // 
            this.lblTokenTitle.AutoSize = true;
            this.lblTokenTitle.Location = new System.Drawing.Point(12, 99);
            this.lblTokenTitle.Name = "lblTokenTitle";
            this.lblTokenTitle.Size = new System.Drawing.Size(226, 13);
            this.lblTokenTitle.TabIndex = 56;
            this.lblTokenTitle.Text = "Folder strings (checked for fixed items to keep)";
            // 
            // lblSearchPropertiesTitle
            // 
            this.lblSearchPropertiesTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblSearchPropertiesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchPropertiesTitle.BackColor = System.Drawing.Color.MediumVioletRed;
            this.lblSearchPropertiesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchPropertiesTitle.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblSearchPropertiesTitle.Location = new System.Drawing.Point(11, 10);
            this.lblSearchPropertiesTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearchPropertiesTitle.Name = "lblSearchPropertiesTitle";
            this.lblSearchPropertiesTitle.Size = new System.Drawing.Size(523, 25);
            this.lblSearchPropertiesTitle.TabIndex = 52;
            this.lblSearchPropertiesTitle.Text = "Option folder token";
            this.lblSearchPropertiesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOptFolderToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 399);
            this.Controls.Add(this.cmdDeleteSelected);
            this.Controls.Add(this.cmdAddNewSearchString);
            this.Controls.Add(this.textBoxNewSearchString);
            this.Controls.Add(this.checkedListBoxToken);
            this.Controls.Add(this.textBoxMaxFixedNumber);
            this.Controls.Add(this.textBoxMaxTokenNumber);
            this.Controls.Add(this.textBoxMFirstFixedTokenNumber);
            this.Controls.Add(this.textBoxPreFixedTokenNumber);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAssign);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTokenTitle);
            this.Controls.Add(this.lblSearchPropertiesTitle);
            this.Name = "frmOptFolderToken";
            this.Text = "Option folder token";
            this.Load += new System.EventHandler(this.frmOptFolderToken_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdDeleteSelected;
        private System.Windows.Forms.Button cmdAddNewSearchString;
        private System.Windows.Forms.TextBox textBoxNewSearchString;
        private System.Windows.Forms.CheckedListBox checkedListBoxToken;
        private System.Windows.Forms.TextBox textBoxMaxFixedNumber;
        private System.Windows.Forms.TextBox textBoxMaxTokenNumber;
        private System.Windows.Forms.TextBox textBoxMFirstFixedTokenNumber;
        private System.Windows.Forms.TextBox textBoxPreFixedTokenNumber;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAssign;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTokenTitle;
        private System.Windows.Forms.Label lblSearchPropertiesTitle;
    }
}