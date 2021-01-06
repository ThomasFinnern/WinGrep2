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
    public partial class frmOptFolderToken : Form
    {
        public frmOptFolderToken()
        {
            InitializeComponent();
        }

        private void frmOptFolderToken_Load(object sender, EventArgs e)
        {
            AssignConfig2Control();
        }

        private void AssignControl2Config()
        {
            AssignControl2Config(Global.SearchFoldersToken);
        }
        private void AssignControl2Config(clsSearchFoldersToken SearchStringToken)
        {
            SearchStringToken.Clear();
            foreach (string Token in checkedListBoxToken.Items)
            {
                SearchStringToken.AddFreeToken2List(Token);
            }

            foreach (string Token in checkedListBoxToken.CheckedItems)
            {
                SearchStringToken.AddFixToken2List(Token);
            }

            try {
                Global.SearchFoldersToken.PreFixedTokenNumber = Convert.ToInt32(textBoxPreFixedTokenNumber.Text);
            } catch { }
            try {
                Global.SearchFoldersToken.FirstFixedTokenNumber = Convert.ToInt32(textBoxMFirstFixedTokenNumber.Text);
            } catch { }
            try {
                Global.SearchFoldersToken.MaxTokenNumber = Convert.ToInt32(textBoxMaxTokenNumber.Text);
            } catch { }
            try {
                Global.SearchFoldersToken.MaxFixedNumber = Convert.ToInt32(textBoxMaxFixedNumber.Text);
            } catch { }

            SearchStringToken.SaveClass2UserFile();
        }

        void AssignConfig2Control()
        {
            // Assign elements in merged order
            checkedListBoxToken.Items.Clear();
            // ToDo: How to make this line work :
            //     checkedListBoxToken.Items.AddRange(Global.SearchFoldersToken.MergedTokenList());
            foreach (string Token in Global.SearchFoldersToken.MergedTokenList())
            {
                checkedListBoxToken.Items.Add(Token);
                if (Global.SearchFoldersToken.ContainsFixedToken(Token))
                {
                    checkedListBoxToken.SetItemChecked(checkedListBoxToken.Items.Count - 1, true);
                }
                // checkedListBoxToken. set index ...
            }

            //// Check for fixed items
            //for (int Idx = 0; Idx < checkedListBoxToken.Items.Count; Idx ++)
            //{
            //     if (Global.SearchFoldersToken.ContainsFixedToken((string) checkedListBoxToken.Items [Idx]))
            //     {
            //        // checkedListBoxToken.Items [Idx]
            //        checkedListBoxToken.SetSelected (Idx, true);
            //     }
            //}

            textBoxPreFixedTokenNumber.Text = Global.SearchFoldersToken.PreFixedTokenNumber.ToString();
            textBoxMFirstFixedTokenNumber.Text = Global.SearchFoldersToken.FirstFixedTokenNumber.ToString();
            textBoxMaxTokenNumber.Text = Global.SearchFoldersToken.MaxTokenNumber.ToString();
            textBoxMaxFixedNumber.Text = Global.SearchFoldersToken.MaxFixedNumber.ToString();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            cmdAssign_Click(sender, e);
            this.Close();
        }

        private void cmdAssign_Click(object sender, EventArgs e)
        {
            AssignControl2Config();
            // Refresh view for order of elements
            AssignConfig2Control();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            AssignConfig2Control();
        }

        private void cmdAddNewSearchString_Click(object sender, EventArgs e)
        {
            if (!checkedListBoxToken.Items.Contains(textBoxNewSearchString.Text))
                checkedListBoxToken.Items.Insert(0, textBoxNewSearchString.Text);
        }

        private void cmdDeleteSelected_Click(object sender, EventArgs e)
        {

        }
    }
}