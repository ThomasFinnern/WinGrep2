using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MainGlobal;

namespace NetGrep
{
    public partial class frmUsedPathView : Form
    {
        public frmUsedPathView()
        {
            InitializeComponent();

            AssignData2Control();
        }

        private void AssignData2Control()
        {
            lblFolderName01.Text = "LastUsedSearchPropertyFileName";
            textBoxFolderName01.Text = Global.Config.LastUsedSearchPropertyFileName;

            lblFolderName02.Text = "LastUsedSearchResultFileName";
            textBoxFolderName02.Text = Global.Config.LastUsedSearchResultFileName;

            lblFolderName03.Text = "LastUsedSearchResultHtmlFileName";
            textBoxFolderName03.Text = Global.Config.LastUsedSearchResultHtmlFileName;

            lblFolderName04.Text = "SearchStringTokens.CfgFileName";
//            textBoxFolderName04.Text = Global.SearchStringTokens.CfgFileName;

            lblFolderName05.Text = "ReplaceStringTokens.CfgFileName";
//            textBoxFolderName05.Text = Global.ReplaceStringTokens.CfgFileName;
/*
            lblFolderName06.Text = "";
            textBoxFolderName06.Text = Global.;

            lblFolderName07.Text = "";
            textBoxFolderName07.Text = Global.;

            lblFolderName08.Text = "";
            textBoxFolderName08.Text = Global.;
 */  
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}