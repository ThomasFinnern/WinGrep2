using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace NetGrep
{
    public partial class frmSearchResultRichTextView : Form
    {
        public clsSearchResults SearchResults;
        public string NextFileName = "";
        private clsSearchResultTokenLinesAsRtf ActSearchResultTokenLinesAsRtf;
        private bool bIsStartOfFileResultFound = false;
        
        public frmSearchResultRichTextView()
        {
            InitializeComponent();
        }

        private void frmSearchResultRichTextView_Load(object sender, EventArgs e)
        {
            AssignNextFileContent();
        }

        void AssignNextFileContent()
        {
            lblFileName.Text = NextFileName;
    
            // if exist (filename .....)
            if (File.Exists(NextFileName))
            {
                clsFileResults FileInsideResults = SearchResults.GetFileResultsFromFileName(NextFileName);

                ActSearchResultTokenLinesAsRtf = new clsSearchResultTokenLinesAsRtf(FileInsideResults);
                ActSearchResultTokenLinesAsRtf.AssignText(richTextBoxFileContent, richTextBoxLineIdx);
                
                //// richTextBoxFileContent.rtf = "Not found file .... "
                //richTextBoxFileContent.Text = File.ReadAllText(NextFileName);
                richTextBoxFileContent.SelectionStart = 0;
                cmdNextResult_Click(richTextBoxFileContent, new EventArgs ());
            }
        }

        private void cmdNextFile_Click(object sender, EventArgs e)
        {
            NextFileName = SearchResults.GetNextFile (NextFileName);
            if (NextFileName != "")
                AssignNextFileContent();
            else
            { 
                NextFileName = "End of List: To start from beginning use button again";
                lblFileName.Text = NextFileName;
                richTextBoxFileContent.Text = "";
            }
        }

        private void cmdPreviousFile_Click(object sender, EventArgs e)
        {
            NextFileName = SearchResults.GetPreviousFile(NextFileName);
            if (NextFileName != "")
                AssignNextFileContent();
            else
            {
                NextFileName = "End of List: To start from beginning use button again";
                lblFileName.Text = NextFileName;
                richTextBoxFileContent.Text = "";
            }
        }


        // Line numbers in front
        //http://www.codeproject.com/KB/edit/numberedtextbox.aspx
        private void cmdPreviousResult_Click(object sender, EventArgs e)
        {
            ;
            if (File.Exists(NextFileName))
            {
                if (ActSearchResultTokenLinesAsRtf != null)
                {
                    int SelectionIdx = richTextBoxFileContent.SelectionStart;
                    int LineIdx = richTextBoxFileContent.GetLineFromCharIndex(SelectionIdx);
                    int ColumnIdx = SelectionIdx - richTextBoxFileContent.GetFirstCharIndexOfCurrentLine();
                    int Length = -1;

                    bIsStartOfFileResultFound = ActSearchResultTokenLinesAsRtf.SelectPreviousResult(richTextBoxFileContent, 
                        richTextBoxLineIdx,
                        ref LineIdx, ref ColumnIdx, ref Length, bIsStartOfFileResultFound);
                    if (bIsStartOfFileResultFound)
                        lblFileName.Text = "Start of file reached. Press again for last file result";
                    else
                        lblFileName.Text = NextFileName;
                }
            }
        }

        private void cmdNextResult_Click(object sender, EventArgs e)
        {
            int SelectionIdx = richTextBoxFileContent.SelectionStart;
            int LineIdx = richTextBoxFileContent.GetLineFromCharIndex(SelectionIdx);
            int ColumnIdx = SelectionIdx - richTextBoxFileContent.GetFirstCharIndexOfCurrentLine();
            int Length = -1;
            bIsStartOfFileResultFound = ActSearchResultTokenLinesAsRtf.SelectNextResult(
                richTextBoxFileContent, richTextBoxLineIdx, ref LineIdx,
                ref ColumnIdx, ref Length, bIsStartOfFileResultFound);
            if (bIsStartOfFileResultFound)
                lblFileName.Text = "End of file reached. Press again for first file result";
            else
                lblFileName.Text = NextFileName;

        }
        /*
        */






        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}