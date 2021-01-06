using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using ErrorCapture;

namespace NetGrep
{
    public partial class frmCopyFileNames2ClipBoard : Form
    {
        private List<string> FoundPathFileNames;
        private string OutPathFileNames;
        public frmCopyFileNames2ClipBoard(List<string> InFoundPathFileNames)
        {
            InitializeComponent();

            FoundPathFileNames = InFoundPathFileNames;

            AssignData2Controls();

        }

        private void AssignData2Controls()
        {
            // todo: Load checking from config
            CreateOutPathFileNames();
            ViewOutPathFileNames(); 
        }

        private void ViewOutPathFileNames()
        {
            txtbFileNames.Text = OutPathFileNames;
        }

        private void CreateOutPathFileNames()
        {
            OutPathFileNames = "";

            try
            {
                if (rdbtFileNames.Checked) 
                    CreateFileNames ();
                if (rdbtFileNamesNoExtension.Checked) 
                    CreateFileNamesNoExtension ();
                if (rdbtFileNamesWithPath.Checked) 
                    CreateFileNamesWithPath ();
                if (rdbtFolderNames.Checked) 
                    CreateFolderNames();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void CreateFolderNames()
        {
            bool bDisableDoubles = !chkbViewDoubles.Checked;
            OutPathFileNames = "";

            foreach (string PathFileName in FoundPathFileNames)
            {
                string OutText = Path.GetDirectoryName(PathFileName);
                // Use all names 
                if (!bDisableDoubles)
                {
                    OutPathFileNames += OutText + "\r\n";
                }

                // Prevent doubles
                if (bDisableDoubles && !OutPathFileNames.Contains(OutText))
                {
                    OutPathFileNames += OutText + "\r\n";
                }
            }
        }

        private void CreateFileNamesWithPath()
        {
            bool bDisableDoubles = !chkbViewDoubles.Checked;
            OutPathFileNames = "";

            foreach (string PathFileName in FoundPathFileNames)
            {
                string OutText = PathFileName;

                // Use all names 
                if (!bDisableDoubles)
                {
                    OutPathFileNames += OutText + "\r\n";
                }

                // Prevent doubles
                if (bDisableDoubles && !OutPathFileNames.Contains(OutText))
                {
                    OutPathFileNames += OutText + "\r\n";
                }
            }
        }

        private void CreateFileNamesNoExtension()
        {
            bool bDisableDoubles = !chkbViewDoubles.Checked;
            OutPathFileNames = "";

            foreach (string PathFileName in FoundPathFileNames)
            {
                string OutText = Path.GetFileNameWithoutExtension(PathFileName);

                // Use all names 
                if (!bDisableDoubles)
                {
                    OutPathFileNames += OutText + "\r\n";
                }

                // Prevent doubles
                if (bDisableDoubles && !OutPathFileNames.Contains(OutText))
                {
                    OutPathFileNames += OutText + "\r\n";
                }
            }
        }

        private void CreateFileNames()
        {
            bool bDisableDoubles = !chkbViewDoubles.Checked;
            OutPathFileNames = "";

            foreach (string PathFileName in FoundPathFileNames)
            {
                string OutText = Path.GetFileName(PathFileName);

                // Use all names 
                if (!bDisableDoubles)
                {
                    OutPathFileNames += OutText + "\r\n";
                }

                // Prevent doubles
                if (bDisableDoubles && !OutPathFileNames.Contains(OutText))
                {
                    OutPathFileNames += OutText + "\r\n";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // todo: Save checking in config
            this.Close();
        }

        private void rdbtFileNames_Click(object sender, EventArgs e)
        {
            CreateOutPathFileNames();
        }

        private void rdbtFileNames_CheckedChanged(object sender, EventArgs e)
        {
            CreateOutPathFileNames();
            ViewOutPathFileNames();
        }

        private void cmdAssign_Click(object sender, EventArgs e)
        {
            // Clipboard.SetText(OutPathFileNames);
            Clipboard.SetText(OutPathFileNames, TextDataFormat.UnicodeText);
            // Clipboard.s
        }

        private void chkbWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            txtbFileNames.WordWrap = chkbWordWrap.Checked;
        }

        private void chkbViewDoubles_CheckedChanged(object sender, EventArgs e)
        {
            rdbtFileNames_CheckedChanged(sender, e);
        }
    }
}