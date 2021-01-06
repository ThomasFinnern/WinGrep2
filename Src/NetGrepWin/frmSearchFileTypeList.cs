using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetGrep
{
    public partial class frmSearchFileTypeList : Form
    {
        public bool bDoReplaceFileListString;
        // Must be set before using show
        //public List<string> FileList;
        public string FileListString;
        // public clsSearchProperties SearchProperties;

        //public frmSearchFileList(List<string> InFileList)
        public frmSearchFileTypeList(string InFileListString)
        {
            InitializeComponent();

            bDoReplaceFileListString = false;

            // FileList = InFileList;
            FileListString = InFileListString;
            AssignConfig2Control();
        }

        private void AssignConfig2Control()
        {
            textBoxFileTypeList.Text = "";
            //foreach (string FileType in FileList)
            foreach (string FileType in FileListString.Split (' '))
            {
                textBoxFileTypeList.Text += FileType + "\r\n";
            }
        }

        private void AssignControl2Config()
        {
            // FileList = new List<string>();
            FileListString = "";
            foreach (string FileType in textBoxFileTypeList.Text.Split (
                new string[] { "\r\n" }, StringSplitOptions.None))
            {
                // FileList.Add (FileType);
                FileListString += FileType + " ";
            }

            FileListString = FileListString.Trim();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            AssignControl2Config();
            bDoReplaceFileListString = true;
            
            this.Close();
        }

    }
}