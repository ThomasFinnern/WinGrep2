using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using LibStringFunctions;
using ErrorCapture;

namespace NetGrep
{
    // ToDo: Use  combobox for each textbox and fill with SearchProperties.SearchFoldersAsString;  cmbFolder.Items.Add(SearchProperties.SearchFoldersAsString);
    // Use all folder items into each combo the same but seperate more folders in a line 

    public partial class frmSearchFolderList : Form
    {
        List<TextBox> TextBoxFolderNames = new List<TextBox>();
        List<Button> cmdFolderSearches = new List<Button>(); 

        public bool bDoReplaceFolderListString;
        // Must be set before using show
        //public List<string> FileList;
        public string FolderListString;
        // public clsSearchProperties SearchProperties;

        public frmSearchFolderList(string InFolderListString)
        {
            InitializeComponent();

            bDoReplaceFolderListString = false;

            // FileList = InFileList;
            FolderListString = InFolderListString;

            ResetView();
            AssignConfig2Control();
        }

        public void ResetView()
        {
            TextBoxFolderNames = new List<TextBox>();
            TextBoxFolderNames.Add(textBoxFolderName01);
            TextBoxFolderNames.Add(textBoxFolderName02);
            TextBoxFolderNames.Add(textBoxFolderName03);
            TextBoxFolderNames.Add(textBoxFolderName04);
            TextBoxFolderNames.Add(textBoxFolderName05);
            TextBoxFolderNames.Add(textBoxFolderName06);
            TextBoxFolderNames.Add(textBoxFolderName07);
            TextBoxFolderNames.Add(textBoxFolderName08);
            TextBoxFolderNames.Add(textBoxFolderName09);
            TextBoxFolderNames.Add(textBoxFolderName10);
            TextBoxFolderNames.Add(textBoxFolderName11);
            TextBoxFolderNames.Add(textBoxFolderName12);
            TextBoxFolderNames.Add(textBoxFolderName13);

            cmdFolderSearches = new List<Button>();
            cmdFolderSearches.Add(cmdFolderSearch01);
            cmdFolderSearches.Add(cmdFolderSearch02);
            cmdFolderSearches.Add(cmdFolderSearch03);
            cmdFolderSearches.Add(cmdFolderSearch04);
            cmdFolderSearches.Add(cmdFolderSearch05);
            cmdFolderSearches.Add(cmdFolderSearch06);
            cmdFolderSearches.Add(cmdFolderSearch07);
            cmdFolderSearches.Add(cmdFolderSearch08);
            cmdFolderSearches.Add(cmdFolderSearch09);
            cmdFolderSearches.Add(cmdFolderSearch10);
            cmdFolderSearches.Add(cmdFolderSearch11);
            cmdFolderSearches.Add(cmdFolderSearch12);
            cmdFolderSearches.Add(cmdFolderSearch13);

            foreach (TextBox textBoxFolderName in TextBoxFolderNames)
            {
                textBoxFolderName.Text = "";
            }
        }

        private void AssignConfig2Control()
        {
            int Idx;

            Idx = 0;
            foreach (string FolderName in LibStringFileFolderNames.ExtractFolderListWithApostrophes(FolderListString))
            {
                TextBoxFolderNames [Idx].Text = FolderName;
                Idx++;
            }
        }

        public void AssignControl2Config()
        {
            FolderListString = "";
            foreach (TextBox textBoxFolderName in TextBoxFolderNames)
            {
                if (textBoxFolderName.Text.Length > 0)
                    FolderListString += " ";

                FolderListString += LibStringFileFolderNames.EncloseApostropheOnFolderNameWithSpaces(textBoxFolderName.Text);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            AssignControl2Config();
            bDoReplaceFolderListString = true;

            this.Close();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ResetView();
            AssignConfig2Control();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            AssignControl2Config();
            bDoReplaceFolderListString = true;
        }

        private void cmdFolderSearchOpen_Click(object sender, EventArgs e)
        {
            Button TstBtnSearchfolder = (Button) sender;
            int Idx = cmdFolderSearches.IndexOf(TstBtnSearchfolder);

            Button ActBtnSearchfolder = cmdFolderSearches[Idx];
            TextBox ActTextBoxFolderName = TextBoxFolderNames [Idx];

            folderBrowserDialog.SelectedPath = "";
            if (ActTextBoxFolderName.Text.Length > 0)
            {
                //folderBrowserDialog.SelectedPath = Path.GetDirectoryName(ActTextBoxFolderName.Text);
                if (Directory.Exists (ActTextBoxFolderName.Text))
                    folderBrowserDialog.SelectedPath = ActTextBoxFolderName.Text;
                else
                    folderBrowserDialog.SelectedPath = Path.GetDirectoryName(ActTextBoxFolderName.Text);
            }
            else
            {
                if (Idx > 0)
                    if (TextBoxFolderNames[Idx - 1].Text.Length > 0)
                        folderBrowserDialog.SelectedPath = Path.GetDirectoryName(TextBoxFolderNames[Idx - 1].Text);
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ActTextBoxFolderName.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void textBoxFolderName02_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                {
                    TextBox tbxFolder = (TextBox)sender;
                    tbxFolder.Text = files[0];

                    // e.Effect = DragDropEffects.All;
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void textBoxFolderName02_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // ToDO: Check if folder exists, take away until folder exists ..
                    e.Effect = DragDropEffects.Copy;
                }
                else
                    e.Effect = DragDropEffects.None;  
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
    }
}



