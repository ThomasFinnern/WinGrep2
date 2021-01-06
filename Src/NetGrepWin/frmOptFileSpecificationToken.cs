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
    public partial class frmOptFileSpecificationToken : Form
    {
        public frmOptFileSpecificationToken()
        {
            InitializeComponent();
        }

        private void frmOptFileSpecificationToken_Load(object sender, EventArgs e)
        {
            AssignConfig2Control();
        }

        private void AssignControl2Config()
        {
            AssignControl2Config(Global.FileSpecificationToken);
        }
        private void AssignControl2Config(clsFileSpecificationToken SearchStringToken)
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
                Global.FileSpecificationToken.PreFixedTokenNumber = Convert.ToInt32(textBoxPreFixedTokenNumber.Text);
            } catch { }
            try {
                Global.FileSpecificationToken.FirstFixedTokenNumber = Convert.ToInt32(textBoxMFirstFixedTokenNumber.Text);
            } catch { }
            try {
                Global.FileSpecificationToken.MaxTokenNumber = Convert.ToInt32(textBoxMaxTokenNumber.Text);
            } catch { }
            try {
                Global.FileSpecificationToken.MaxFixedNumber = Convert.ToInt32(textBoxMaxFixedNumber.Text);
            } catch { }

            SearchStringToken.SaveClass2UserFile();
        }


 /*
ToDo: paket *_eng.wrp suchen, alle Dateien suchen, die den Wert nicht wenthalten !

/**/


        void AssignConfig2Control()
        {
            // Assign elements in merged order
            checkedListBoxToken.Items.Clear();
            // ToDo: How to make this line work :
            //     checkedListBoxToken.Items.AddRange(Global.FileSpecificationToken.MergedTokenList());
            foreach (string Token in Global.FileSpecificationToken.MergedTokenList())
            {
                checkedListBoxToken.Items.Add(Token);
                if (Global.FileSpecificationToken.ContainsFixedToken(Token))
                {
                    checkedListBoxToken.SetItemChecked(checkedListBoxToken.Items.Count - 1, true);
                }
                // checkedListBoxToken. set index ...
            }

            //// Check for fixed items
            //for (int Idx = 0; Idx < checkedListBoxToken.Items.Count; Idx ++)
            //{
            //     if (Global.FileSpecificationToken.ContainsFixedToken((string) checkedListBoxToken.Items [Idx]))
            //     {
            //        // checkedListBoxToken.Items [Idx]
            //        checkedListBoxToken.SetSelected (Idx, true);
            //     }
            //}

            textBoxPreFixedTokenNumber.Text = Global.FileSpecificationToken.PreFixedTokenNumber.ToString();
            textBoxMFirstFixedTokenNumber.Text = Global.FileSpecificationToken.FirstFixedTokenNumber.ToString();
            textBoxMaxTokenNumber.Text = Global.FileSpecificationToken.MaxTokenNumber.ToString();
            textBoxMaxFixedNumber.Text = Global.FileSpecificationToken.MaxFixedNumber.ToString();

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