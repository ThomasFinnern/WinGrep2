using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MainGlobal;
using ErrorCapture;

namespace NetGrep
{
    public partial class frmReplaceProperties : Form
    {
        public bool bDoStartReplace;
        private clsSearchProperties SearchProperties;

        public frmReplaceProperties(clsSearchProperties InSearchProperties)
        {
            InitializeComponent();

            bDoStartReplace = false;
            SearchProperties = InSearchProperties;
            AssignConfig2Control(); 
            cmbReplaceString.Focus();
        }

        private void AssignConfig2Control()
        {
            cmbSearchString.Items.Add(SearchProperties.SearchString);
            cmbSearchString.SelectedIndex = 0;

            cmbReplaceString.Items.Add(SearchProperties.ReplaceString);
            cmbReplaceString.SelectedIndex = 0;

            foreach (string Token in Global.ReplaceStringTokens.MergedTokenList())
            {
                if (!cmbReplaceString.Items.Contains(Token))
                    cmbReplaceString.Items.Add(Token);
            }

            chkReplaceInSelectedFiles.Checked = SearchProperties.bReplaceInSelectedFiles;
            chkReplaceConfirmEachReplace.Checked = SearchProperties.bConfirmEachReplace;
            chkCreateBackup.Checked = SearchProperties.bCreateBackup;
            chkReplaceOriginalFile.Checked = SearchProperties.bReplaceOriginalFile;

            chkbUseBackupFolder.Checked = SearchProperties.bUseBackupFolder;

            cmbBackupFolder.Items.Add(SearchProperties.BackupFolder);
            foreach (string Token in Global.BackupFoldersToken.MergedTokenList())
            {
                if (!cmbBackupFolder.Items.Contains(Token))
                    cmbBackupFolder.Items.Add(Token);
            }
            cmbBackupFolder.SelectedIndex = 0;
        }

        private void AssignControl2Config()
        {
            SearchProperties.ReplaceString = cmbReplaceString.Text;
            // ? Global.ReplaceStringTokens.AddUsedToken(cmbSearchString.Text);
            Global.ReplaceStringTokens.AddUsedToken(cmbReplaceString.Text);
            Global.ReplaceStringTokens.SaveClass2UserFile();

            SearchProperties.bReplaceInSelectedFiles = chkReplaceInSelectedFiles.Checked;
            SearchProperties.bConfirmEachReplace = chkReplaceConfirmEachReplace.Checked;
            SearchProperties.bCreateBackup = chkCreateBackup.Checked;
            SearchProperties.bReplaceOriginalFile = chkReplaceOriginalFile.Checked;

            SearchProperties.bUseBackupFolder = chkbUseBackupFolder.Checked;
            SearchProperties.BackupFolder = chkbUseBackupFolder.Text;
            Global.FileSpecificationToken.AddUsedToken(chkbUseBackupFolder.Text);
            Global.FileSpecificationToken.SaveClass2UserFile();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            AssignControl2Config();
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdStartReplace_Click(object sender, EventArgs e)
        {
            AssignControl2Config();
            SearchProperties.SaveClass2UserFile();

            bDoStartReplace = true;
            this.Close();
        }

        private void rdbtReplaceFlagSpecification_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelFileSpecification.Visible)
            {
                rdbtReplaceFlagSpecificationView.Checked = true;
                flowLayoutPanelFileSpecification.Visible = false;                
            }
            else
            {
                rdbtReplaceFlagSpecificationView.Checked = false;
                flowLayoutPanelFileSpecification.Visible = true;
            }
        }

        private void rdbtBackupFolderSpezifikationView_Click(object sender, EventArgs e)
        {
            if (panlBackupFoldersSpezification.Visible)
            {
                rdbtBackupFolderSpezifikationView.Checked = true;
                panlBackupFoldersSpezification.Visible = false;
            }
            else
            {
                rdbtBackupFolderSpezifikationView.Checked = false;
                panlBackupFoldersSpezification.Visible = true;
            }
        }

    }
}