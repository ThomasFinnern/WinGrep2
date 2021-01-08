using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

using MainGlobal;
using ErrorCapture;
using AppPaths;

namespace NetGrep
{
    public partial class frmTestTRegularExpressionSearch : Form
    {
        public clsSearchProperties LocalSearchProperties;
        public clsTestRegExSearchData TestRegExSearchData = new clsTestRegExSearchData();

        public frmTestTRegularExpressionSearch()
        {
            InitializeComponent();

            TestRegExSearchData = clsTestRegExSearchData.LoadClassOrCreateUserFile();

            LocalSearchProperties = clsSearchProperties.LoadClassOrCreateUserFile();
            AssignConfig2Control();
            LocalSearchProperties.SaveClass2UserFile();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AssignConfig2Control()
        {
            cmbSearchString.Items.Add(LocalSearchProperties.SearchString);
            cmbSearchString.SelectedIndex = 0;
            // ToDo: Add Last used Search items  
            foreach (string Token in Global.SearchStringTokens.MergedTokenList())
            {
                if (!cmbSearchString.Items.Contains(Token))
                    cmbSearchString.Items.Add(Token);
            }

            // Preset always on start
            LocalSearchProperties.bUseRegularExpression = true;

            chkUseRegularExpression.Checked = LocalSearchProperties.bUseRegularExpression;
            chkWholeWordsOnly.Checked = LocalSearchProperties.bWholeWordsOnly;
            chkMatchCase.Checked = LocalSearchProperties.bMatchCase;
            chkLinesWithNoMatch.Checked = LocalSearchProperties.bLinesWithNoMatch;
            chkStopAfterFirstMatch.Checked = LocalSearchProperties.bStopAfterFirstMatch;

            // Search token and search text lines from saved content

            // Search token from last
            LoadTestRegEx2Control(0);
        }

        public void LoadTestRegEx2Control(int UseSlot)
        {
            // ToDo: try in all functions
            if (UseSlot >= TestRegExSearchData.SearchToken.Count)
            {
                // ToDo: Msgbox
                return;
            }

            // int LastUsedSearchGroup = TestRegExSearchData.LastUsedSearchGroup;
            string UseSearchToken = TestRegExSearchData.SearchToken[UseSlot];
            if (UseSearchToken.Trim().Length > 0)
            {
                cmbSearchString.Items.Insert(0, UseSearchToken);

                List<string> LastUsedLines = TestRegExSearchData.Texts2SearchIn[UseSlot];

                textSearchText.Lines = LastUsedLines.ToArray();
            }
        }

        public void SaveControl2TestRegEx(int UseSlot)
        {
            // Outside field ?             
            if (UseSlot >= clsTestRegExSearchData.cSlotNbr)
            {
                // ToDo: Msgbox
                return;
            }

            // check for missing entries in searchtoken and Texts2SearchIn or the need to create the actual one
            // Initialized unused slots
            for (int Idx = TestRegExSearchData.SearchToken.Count; Idx <= UseSlot; Idx++)
            {
                TestRegExSearchData.SearchToken.Add ("");
                TestRegExSearchData.Texts2SearchIn.Add(new List <string> ());
            }
            
            // Search token from last
            //TestRegExSearchData.LastUsedSearchGroup = UseSlot;

            if (cmbSearchString.SelectedIndex < 0)
                cmbSearchString.SelectedIndex = 0;

            TestRegExSearchData.SearchToken[UseSlot] = (string)cmbSearchString.Items[cmbSearchString.SelectedIndex];
            List<string> LastUsedLines = TestRegExSearchData.Texts2SearchIn[UseSlot];

            LastUsedLines.Clear();
            foreach (string Line in textSearchText.Lines)
            {
                LastUsedLines.Add(Line);
            }
            // Already done above : TestRegExSearchData.Texts2SearchIn[UseSlot] = LastUsedLines;

            TestRegExSearchData.SaveClass2UserFile();
        }

        private void AssignControl2Config()
        {
            // SearchProperties.SearchString = (string)cmbSearchString.Items[0];
            LocalSearchProperties.SearchString = cmbSearchString.Text;
            Global.SearchStringTokens.AddUsedToken(cmbSearchString.Text);
            Global.SearchStringTokens.SaveClass2UserFile();

            LocalSearchProperties.bUseRegularExpression = chkUseRegularExpression.Checked;
            LocalSearchProperties.bWholeWordsOnly = chkWholeWordsOnly.Checked;
            LocalSearchProperties.bMatchCase = chkMatchCase.Checked;
            LocalSearchProperties.bLinesWithNoMatch = chkLinesWithNoMatch.Checked;
            LocalSearchProperties.bStopAfterFirstMatch = chkStopAfterFirstMatch.Checked;
            // SearchProperties.FileSpecification = (string)cmbFileSpec.Items[0];

            //int LastUsedSearchGroup = TestRegExSearchData.LastUsedSearchGroup;
            SaveControl2TestRegEx(0);
        }

        private void cmdStartSearch_Click(object sender, EventArgs e)
        {
            AssignControl2Config();

            //--------------------------------------------------------------------------------------
            // Prepare regular expression search string
            //--------------------------------------------------------------------------------------

            Regex regExSearch = clsSearchRegularExpression.CreateSearchRegEx(
                LocalSearchProperties);

            //--------------------------------------------------------------------------------------
            // Search in every line
            //--------------------------------------------------------------------------------------
            List<clsFileResults> Files2LineResults = new List<clsFileResults>();
            clsFileResults FileResult = null;

            bool bMatchFound = clsSearchInLines.DoSearchInLines(
                textSearchText.Lines,
                regExSearch, LocalSearchProperties,
                "LocalLinesSearch", ref FileResult);

            if (FileResult != null)
                Files2LineResults.Add(FileResult);

            //----------------------------------------------------------------------------
            // Show result
            //----------------------------------------------------------------------------

            clsSearchResultTokenLinesAsHtml SearchResultTokenLinesAsHtml =
                new clsSearchResultTokenLinesAsHtml(Files2LineResults);
            webSearchResult.DocumentText = SearchResultTokenLinesAsHtml.FoundLinesWithTokenHtmlDocument();

            //Fix: yyyyy Data path 
            // SearchResultTokenLinesAsHtml.WriteFileFoundLinesWithTokenHtmlDocument(
            ////   ???? Path.GetDirectoryName(Application.ExecutablePath) + "\\" +
            //       Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" +
            //    "..\\..\\..\\Data\\LinesWithTokenHtmlDocument.htm");
            SearchResultTokenLinesAsHtml.WriteFileFoundLinesWithTokenHtmlDocument(
                clsAppPaths.UserPathName.PathName + "\\" +
                //// ??? Path.GetDirectoryName(Application.ExecutablePath) + "\\" +
                //       Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" +
                //"..\\..\\..\\Data\\LinesWithTokenHtmlDocument.htm");
                "LinesWithTokenHtmlDocument.htm");
        }

        private void frmTestTRegularExpressionSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //Global.LogInputKeys.AddKeyValue("Tre", e);


            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                cmdStartSearch_Click(sender, new EventArgs());
            }
        }

        private void cmdLoad01_Click(object sender, EventArgs e)
        {
            LoadTestRegEx2Control(1);
            SaveControl2TestRegEx(0); // Last used
        }

        private void cmdSave01_Click(object sender, EventArgs e)
        {
            SaveControl2TestRegEx(1);
        }

        private void cmdLoad02_Click(object sender, EventArgs e)
        {
            LoadTestRegEx2Control(2);
            SaveControl2TestRegEx(0); // Last used
        }

        private void cmdSave02_Click(object sender, EventArgs e)
        {
            SaveControl2TestRegEx(2);
        }

        private void cmdLoad03_Click(object sender, EventArgs e)
        {
            LoadTestRegEx2Control(3);
            SaveControl2TestRegEx(0); // Last used
        }

        private void cmdSave03_Click(object sender, EventArgs e)
        {
            SaveControl2TestRegEx(3);
        }
    }
}


