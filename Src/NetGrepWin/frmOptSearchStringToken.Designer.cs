namespace NetGrep
{
    partial class frmOptSearchStringToken
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
            this.lblTokenTitle = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmdAssign = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPreFixedTokenNumber = new System.Windows.Forms.TextBox();
            this.textBoxMFirstFixedTokenNumber = new System.Windows.Forms.TextBox();
            this.textBoxMaxTokenNumber = new System.Windows.Forms.TextBox();
            this.textBoxMaxFixedNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBoxToken = new System.Windows.Forms.CheckedListBox();
            this.textBoxNewSearchString = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdAddNewSearchString = new System.Windows.Forms.Button();
            this.cmdDeleteSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSearchPropertiesTitle
            // 
            this.lblSearchPropertiesTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblSearchPropertiesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearchPropertiesTitle.BackColor = System.Drawing.Color.MediumVioletRed;
            this.lblSearchPropertiesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchPropertiesTitle.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblSearchPropertiesTitle.Location = new System.Drawing.Point(9, 9);
            this.lblSearchPropertiesTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearchPropertiesTitle.Name = "lblSearchPropertiesTitle";
            this.lblSearchPropertiesTitle.Size = new System.Drawing.Size(523, 25);
            this.lblSearchPropertiesTitle.TabIndex = 21;
            this.lblSearchPropertiesTitle.Text = "Option search string token";
            this.lblSearchPropertiesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTokenTitle
            // 
            this.lblTokenTitle.AutoSize = true;
            this.lblTokenTitle.Location = new System.Drawing.Point(10, 98);
            this.lblTokenTitle.Name = "lblTokenTitle";
            this.lblTokenTitle.Size = new System.Drawing.Size(231, 13);
            this.lblTokenTitle.TabIndex = 23;
            this.lblTokenTitle.Text = "Search strings (checked for fixed items to keep)";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(429, 362);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 25);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmdAssign
            // 
            this.cmdAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAssign.Location = new System.Drawing.Point(211, 362);
            this.cmdAssign.Name = "cmdAssign";
            this.cmdAssign.Size = new System.Drawing.Size(103, 25);
            this.cmdAssign.TabIndex = 25;
            this.cmdAssign.Text = "Assign";
            this.cmdAssign.UseVisualStyleBackColor = true;
            this.cmdAssign.Click += new System.EventHandler(this.cmdAssign_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(320, 362);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(103, 25);
            this.cmdCancel.TabIndex = 26;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClear.Location = new System.Drawing.Point(102, 362);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(103, 25);
            this.cmdClear.TabIndex = 27;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(310, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Pre fixed token number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPreFixedTokenNumber
            // 
            this.textBoxPreFixedTokenNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPreFixedTokenNumber.Location = new System.Drawing.Point(465, 243);
            this.textBoxPreFixedTokenNumber.Name = "textBoxPreFixedTokenNumber";
            this.textBoxPreFixedTokenNumber.Size = new System.Drawing.Size(67, 20);
            this.textBoxPreFixedTokenNumber.TabIndex = 28;
            // 
            // textBoxMFirstFixedTokenNumber
            // 
            this.textBoxMFirstFixedTokenNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMFirstFixedTokenNumber.Location = new System.Drawing.Point(465, 269);
            this.textBoxMFirstFixedTokenNumber.Name = "textBoxMFirstFixedTokenNumber";
            this.textBoxMFirstFixedTokenNumber.Size = new System.Drawing.Size(67, 20);
            this.textBoxMFirstFixedTokenNumber.TabIndex = 28;
            // 
            // textBoxMaxTokenNumber
            // 
            this.textBoxMaxTokenNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMaxTokenNumber.Location = new System.Drawing.Point(465, 295);
            this.textBoxMaxTokenNumber.Name = "textBoxMaxTokenNumber";
            this.textBoxMaxTokenNumber.Size = new System.Drawing.Size(67, 20);
            this.textBoxMaxTokenNumber.TabIndex = 28;
            // 
            // textBoxMaxFixedNumber
            // 
            this.textBoxMaxFixedNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMaxFixedNumber.Location = new System.Drawing.Point(465, 321);
            this.textBoxMaxFixedNumber.Name = "textBoxMaxFixedNumber";
            this.textBoxMaxFixedNumber.Size = new System.Drawing.Size(67, 20);
            this.textBoxMaxFixedNumber.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(310, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "First fixed token number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(310, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Max token number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(310, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Max fixed number";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkedListBoxToken
            // 
            this.checkedListBoxToken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxToken.FormattingEnabled = true;
            this.checkedListBoxToken.HorizontalScrollbar = true;
            this.checkedListBoxToken.Location = new System.Drawing.Point(13, 114);
            this.checkedListBoxToken.Name = "checkedListBoxToken";
            this.checkedListBoxToken.Size = new System.Drawing.Size(290, 227);
            this.checkedListBoxToken.TabIndex = 29;
            // 
            // textBoxNewSearchString
            // 
            this.textBoxNewSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewSearchString.Location = new System.Drawing.Point(13, 66);
            this.textBoxNewSearchString.Name = "textBoxNewSearchString";
            this.textBoxNewSearchString.Size = new System.Drawing.Size(464, 20);
            this.textBoxNewSearchString.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "New search string";
            // 
            // cmdAddNewSearchString
            // 
            this.cmdAddNewSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddNewSearchString.Location = new System.Drawing.Point(483, 66);
            this.cmdAddNewSearchString.Name = "cmdAddNewSearchString";
            this.cmdAddNewSearchString.Size = new System.Drawing.Size(49, 20);
            this.cmdAddNewSearchString.TabIndex = 31;
            this.cmdAddNewSearchString.Text = "Add";
            this.cmdAddNewSearchString.UseVisualStyleBackColor = true;
            this.cmdAddNewSearchString.Click += new System.EventHandler(this.cmdAddNewSearchString_Click);
            // 
            // cmdDeleteSelected
            // 
            this.cmdDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDeleteSelected.Location = new System.Drawing.Point(320, 114);
            this.cmdDeleteSelected.Name = "cmdDeleteSelected";
            this.cmdDeleteSelected.Size = new System.Drawing.Size(94, 20);
            this.cmdDeleteSelected.TabIndex = 32;
            this.cmdDeleteSelected.Text = "Delete Selected";
            this.cmdDeleteSelected.UseVisualStyleBackColor = true;
            this.cmdDeleteSelected.Click += new System.EventHandler(this.cmdDeleteSelected_Click);
            // 
            // frmOptSearchStringToken
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
            this.Name = "frmOptSearchStringToken";
            this.Text = "Option search string token";
            this.Load += new System.EventHandler(this.frmOptSearchStringToken_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchPropertiesTitle;
        private System.Windows.Forms.Label lblTokenTitle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button cmdAssign;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPreFixedTokenNumber;
        private System.Windows.Forms.TextBox textBoxMFirstFixedTokenNumber;
        private System.Windows.Forms.TextBox textBoxMaxTokenNumber;
        private System.Windows.Forms.TextBox textBoxMaxFixedNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBoxToken;
        private System.Windows.Forms.TextBox textBoxNewSearchString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdAddNewSearchString;
        private System.Windows.Forms.Button cmdDeleteSelected;
    }
}