using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Windows.Forms;
using MainGlobal;
using ErrorCapture;
using LibStringFunctions;

namespace NetGrep
{
    public partial class frmSearchProperties : Form
    {
        public bool bDoStartSearch;
        private clsSearchProperties LocalSearchProperties;
        public clsSearchProperties SearchProperties
        { 
            get {return LocalSearchProperties;}
        }

        public frmSearchProperties(clsSearchProperties InSearchProperties)
        {
            InitializeComponent();

            bDoStartSearch = false;

            LocalSearchProperties = InSearchProperties;
            AssignConfig2Control();

            cmbSearchString.Focus();
        }

        private void AssignConfig2Control()
        {
            cmbSearchString.Items.Add(SearchProperties.SearchString);
            cmbSearchString.SelectedIndex = 0;
            // ToDo: Add Last used Search items  
            foreach (string Token in Global.SearchStringTokens.MergedTokenList())
            {
                if (!cmbSearchString.Items.Contains (Token))
                    cmbSearchString.Items.Add(Token);
            }

            // --- Search string options -------------------------------------

            chkUseRegularExpression.Checked = SearchProperties.bUseRegularExpression;
            chkWholeWordsOnly.Checked = SearchProperties.bWholeWordsOnly;
            chkMatchCase.Checked = SearchProperties.bMatchCase;
            chkLinesWithNoMatch.Checked = SearchProperties.bLinesWithNoMatch;
            chkFilesWithNoMatch.Checked = SearchProperties.bFilesWithNoMatch;
            chkStopAfterFirstMatch.Checked = SearchProperties.bStopAfterFirstMatch;
            chkSearchInFoundFiles.Checked = SearchProperties.bSearchInFoundFiles;
            chkNeedsCompleteLine.Checked = SearchProperties.bNeedsCompleteLine;

            chkUseDelimitedList.Checked = SearchProperties.bUseDelimitedList;
            textBoxSeperationChar.Text = SearchProperties.DelimitedSeperationChar;
            textBoxSearchFieldNbr.Text = SearchProperties.DelimitedSearchFieldNbr;
            chkDelimitedList_CheckedChanged (this, new EventArgs ());

            chkUseFixedWidthList.Checked = SearchProperties.bUseFixedWidthList;
            textBoxBeginPosition.Text = SearchProperties.FixedWidthBeginPosition;
            textBoxSize.Text = SearchProperties.FixedWidthSize;
            chkUseFixedWidthList_CheckedChanged (this, new EventArgs ());

            // ToDo: use cmbFileSpec.Items.Clear in all assigns in all forms
            cmbFileSpec.Items.Add(SearchProperties.SearchFileTypesAsString);
            foreach (string Token in Global.FileSpecificationToken.MergedTokenList())
            {
                if (!cmbFileSpec.Items.Contains(Token))
                    cmbFileSpec.Items.Add(Token);
            }
            cmbFileSpec.SelectedIndex = 0;
            // ToDo: Add Last used FileSpec's
            //chkSkipTextFiles.Checked = SearchProperties;
            //chkSkipBinaryFiles.Checked = SearchProperties;
            //chkSearchInZipFiles.Checked = SearchProperties;

            cmbFolder.Items.Add(SearchProperties.SearchFoldersAsString);
            foreach (string Token in Global.SearchFoldersToken.MergedTokenList())
            {
                if (!cmbFolder.Items.Contains(Token))
                    cmbFolder.Items.Add(Token);
            }
            
            // --- File type options -----------------------------------

            chkRegExFileNames.Checked = SearchProperties.bUseFileRegularExpression;
            chkSearchInZipFiles.Checked = SearchProperties.bSearchInsideZipFiles;
            // .Checked = SearchProperties.bSkipBinaryFiles;
            chkSkipFileTypes.Checked = SearchProperties.bSkipFileTypes;
            cmbFileSpecSkip.Text = SearchProperties.SkipFileTypesString;
            chkRegExFileMatchCase.Checked = SearchProperties.bRegExFileMatchCase;


            // --- Folder options -------------------------------------

            checkRegExFullPath.Checked = SearchProperties.bUseFolderRegularExpression;
            chkRegExFolderMatchCase.Checked = SearchProperties.bRegExFolderMatchCase;
            checkRegExPathLastPart.Checked = SearchProperties.bRegExPathLastPart;
            txtbRegExFolder.Text = SearchProperties.RegExFolderText;

            chkDoRecourseFolder.Checked = SearchProperties.bDoRecourseFolders;

            cmbFolder.SelectedIndex = 0;
            // ToDo: Add Last used Folder's
            //chkRecourseFolder.Checked = SearchProperties;
            //CountFilesFirst.Checked = SearchProperties;

            // --- Line view amount options -------------------------------------

            NbrShowFollowingLines.Text = SearchProperties.ViewSetting.Show.LineNbrFollowingMatch.ToString();
            NbrShowPreviousLines.Text = SearchProperties.ViewSetting.Show.LineNbrPreviousToMatch.ToString();

            NbrPrepareFollowingLines.Text = SearchProperties.ViewSetting.Keep.LineNbrFollowingMatch.ToString();
            NbrPreparePreviousLines.Text = SearchProperties.ViewSetting.Keep.LineNbrPreviousToMatch.ToString();

            //--- View optional parameter --------------------------------

            // force complete view if parameter is set
            if (IsExtraParameterSet())
            {
                radioButtonMoreInSearchString.Checked = true;
                flowLayoutPanelSearchString.Visible = true;
            }

            // force complete view if parameter is set
            if (IsFolderParameterSet())
            {
                radioButtonMoreInFolders.Checked = true;
                flowLayoutPanelFolder.Visible = true;
            }

            // force complete view if parameter is set
            if (IsFileParameterSet())
            {
                radioButtonMoreInFileSpecification.Checked = true;
                flowLayoutPanelFileSpecification.Visible = true;
            }

        }

        private bool IsFileParameterSet()
        {
            bool bIsFileParameterSet = false;

            if (chkRegExFileNames.Checked)
                bIsFileParameterSet = true;
            
            if (chkRegExFileMatchCase.Checked)
                bIsFileParameterSet = true;

            return bIsFileParameterSet;
        }

        private bool IsFolderParameterSet()
        {
            bool bIsFolderParameterSet = false;

            if (!chkDoRecourseFolder.Checked)
                bIsFolderParameterSet = true;

            if(txtbRegExFolder.Text.Length > 0)
                bIsFolderParameterSet = true;

            if (!checkRegExFullPath.Checked)
                bIsFolderParameterSet = true;

            if (!chkRegExFolderMatchCase.Checked)
                bIsFolderParameterSet = true;

            if (!checkRegExPathLastPart.Checked)
                bIsFolderParameterSet = true;

            return bIsFolderParameterSet;
        }

        private bool IsExtraParameterSet()
        {
            bool bIsExtraParameterSet = false;


            // ToDo: 
            if (chkWholeWordsOnly.Checked)
                bIsExtraParameterSet = true;

            if (chkMatchCase.Checked)
                bIsExtraParameterSet = true;

            if (chkUseRegularExpression.Checked)
                bIsExtraParameterSet = true;

            if (chkStopAfterFirstMatch.Checked)
                bIsExtraParameterSet = true;

            if (chkFilesWithNoMatch.Checked)
                bIsExtraParameterSet = true;

            if (chkLinesWithNoMatch.Checked)
                bIsExtraParameterSet = true;

            if (chkLinesWithNoMatch.Checked)
                bIsExtraParameterSet = true;

            if (chkLinesWithNoMatch.Checked)
                bIsExtraParameterSet = true;

            if (chkLinesWithNoMatch.Checked)
                bIsExtraParameterSet = true;

            if (chkbUseDateTime.Checked)
                bIsExtraParameterSet = true;

            if (chkUseFixedWidthList.Checked)
                bIsExtraParameterSet = true;

            if (chkUseDelimitedList.Checked)
                bIsExtraParameterSet = true;

            //if (.Checked)
            //    bIsExtraParameterSet = true;

            //if (.Checked)
            //    bIsExtraParameterSet = true;

            return bIsExtraParameterSet;
        }

    
    
    
    
        private void AssignControl2Config()
        {
            // --- Search string options -------------------------------------

            // SearchProperties.SearchString = (string)cmbSearchString.Items[0];
            SearchProperties.SearchString = cmbSearchString.Text;
            Global.SearchStringTokens.AddUsedToken(cmbSearchString.Text);
            Global.SearchStringTokens.SaveClass2UserFile();

            SearchProperties.bUseRegularExpression = chkUseRegularExpression.Checked;
            SearchProperties.bWholeWordsOnly = chkWholeWordsOnly.Checked;
            SearchProperties.bMatchCase = chkMatchCase.Checked;
            SearchProperties.bLinesWithNoMatch = chkLinesWithNoMatch.Checked;
            SearchProperties.bFilesWithNoMatch = chkFilesWithNoMatch.Checked;
            SearchProperties.bStopAfterFirstMatch = chkStopAfterFirstMatch.Checked;
            SearchProperties.bSearchInFoundFiles = chkSearchInFoundFiles.Checked;
            // SearchProperties.FileSpecification = (string)cmbFileSpec.Items[0];
            SearchProperties.bNeedsCompleteLine = chkNeedsCompleteLine.Checked;

            SearchProperties.bUseDelimitedList = chkUseDelimitedList.Checked;
            SearchProperties.DelimitedSeperationChar = textBoxSeperationChar.Text;
            SearchProperties.DelimitedSearchFieldNbr = textBoxSearchFieldNbr.Text;

            SearchProperties.bUseFixedWidthList = chkUseFixedWidthList.Checked;
            SearchProperties.FixedWidthBeginPosition = textBoxBeginPosition.Text;
            SearchProperties.FixedWidthBeginPosition = textBoxBeginPosition.Text;

            SearchProperties.SearchFileTypesAsString = cmbFileSpec.Text;
            Global.FileSpecificationToken.AddUsedToken(cmbFileSpec.Text);
            Global.FileSpecificationToken.SaveClass2UserFile();

            // SearchProperties = chkSkipTextFiles.Checked;
            // SearchProperties = chkSkipBinaryFiles.Checked;
            // SearchProperties = chkSearchInZipFiles.Checked;

            // SearchProperties.SearchFoldersAsString = (string)cmbFolder.Items[0];
            SearchProperties.SearchFoldersAsString = cmbFolder.Text;
            Global.SearchFoldersToken.AddUsedToken(cmbFolder.Text);
            Global.SearchFoldersToken.SaveClass2UserFile();

            // --- File type options -----------------------------------

            SearchProperties.bUseFileRegularExpression = chkRegExFileNames.Checked;
            SearchProperties.bSearchInsideZipFiles = chkSearchInZipFiles.Checked;
            // SearchProperties.bSkipBinaryFiles = .Checked;
            SearchProperties.bSkipFileTypes = chkSkipFileTypes.Checked;
            SearchProperties.SkipFileTypesString = cmbFileSpecSkip.Text;
            SearchProperties.bRegExFileMatchCase = chkRegExFileMatchCase.Checked;

            // --- Folder options -------------------------------------#

            SearchProperties.bUseFolderRegularExpression = checkRegExFullPath.Checked;
            SearchProperties.bRegExFolderMatchCase = chkRegExFolderMatchCase.Checked;
            SearchProperties.bRegExPathLastPart = checkRegExPathLastPart.Checked;
            SearchProperties.RegExFolderText = txtbRegExFolder.Text;

            SearchProperties.bDoRecourseFolders = chkDoRecourseFolder.Checked;

            SearchProperties.ViewSetting.Show.LineNbrFollowingMatch = Convert.ToInt32(NbrShowFollowingLines.Text);
            SearchProperties.ViewSetting.Show.LineNbrPreviousToMatch = Convert.ToInt32(NbrShowPreviousLines.Text);

            SearchProperties.ViewSetting.Keep.LineNbrFollowingMatch = Convert.ToInt32(NbrPrepareFollowingLines.Text);
            SearchProperties.ViewSetting.Keep.LineNbrPreviousToMatch = Convert.ToInt32(NbrPreparePreviousLines.Text);
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            AssignControl2Config();
            //SearchProperties.SaveClass2UserFile();

            this.Close();
        }

        private void cmdStartSearch_Click(object sender, EventArgs e)
        {
            AssignControl2Config();
            SearchProperties.SaveClass2UserFile();

            bDoStartSearch = true;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSearchProperties_KeyDown(object sender, KeyEventArgs e)
        {
            //Global.LogInputKeys.AddKeyValue("Sep", e);
            
            if (e.KeyCode == Keys.Enter)
            {
                cmdStartSearch_Click(sender, new EventArgs());
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                cmdCancel_Click(sender, e);
            }
        }
        
        private void radioButtonMoreInSearchString_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelSearchString.Visible)
            {
                // Keep enabled when any control is set in extension
                flowLayoutPanelSearchString.Visible = IsExtraParameterSet(); // false expected in most cases
            }
            else
            {
                flowLayoutPanelSearchString.Visible = true;
            }

            radioButtonMoreInSearchString.Checked = flowLayoutPanelSearchString.Visible;
        }

        private void radioButtonMoreInFileSpecification_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelFileSpecification.Visible)
            {
                // Keep enabled when any control is set in extension
                flowLayoutPanelFileSpecification.Visible = IsFileParameterSet();
            }
            else
            {
                flowLayoutPanelFileSpecification.Visible = true;
            }

            radioButtonMoreInFileSpecification.Checked = flowLayoutPanelFileSpecification.Visible;
        }

        private void radioButtonMoreInFolders_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelFolder.Visible)
            {
                // Keep enabled when any control is set in extension
                flowLayoutPanelFolder.Visible = IsFolderParameterSet();
            }
            else
            {
                flowLayoutPanelFolder.Visible = true;
            }

            radioButtonMoreInFolders.Checked = flowLayoutPanelFolder.Visible;
        }

        private void chkDelimitedList_CheckedChanged(object sender, EventArgs e)
        {
            lblSepqarationChracter.Visible = chkUseDelimitedList.Checked;
            textBoxSeperationChar.Visible = chkUseDelimitedList.Checked;
            lblSearchFieldNumber.Visible = chkUseDelimitedList.Checked;
            textBoxSearchFieldNbr.Visible = chkUseDelimitedList.Checked;
            // redraw ?
        }

        private void chkUseFixedWidthList_CheckedChanged(object sender, EventArgs e)
        {
            lblBeginPosition.Visible = chkUseFixedWidthList.Checked;
            textBoxBeginPosition.Visible = chkUseFixedWidthList.Checked;
            lblSize.Visible = chkUseFixedWidthList.Checked;
            textBoxSize.Visible = chkUseFixedWidthList.Checked;
        }

        private void cmdFileListView_Click(object sender, EventArgs e)
        {
            frmSearchFileTypeList frmSearchFileList = new frmSearchFileTypeList(cmbFileSpec.Text);
            frmSearchFileList.ShowDialog (this);

            if (frmSearchFileList.bDoReplaceFileListString)
            {
                cmbFileSpec.Text = frmSearchFileList.FileListString;
            }
        }

        private void cmdFolderListView_Click(object sender, EventArgs e)
        {
            frmSearchFolderList frmSearchFolderList = new frmSearchFolderList(cmbFolder.Text);
            frmSearchFolderList.ShowDialog(this);

            if (frmSearchFolderList.bDoReplaceFolderListString)
            {
                cmbFolder.Text = frmSearchFolderList.FolderListString;
            }
        }

        private void cmbFolder_DragEnter(object sender, DragEventArgs e)
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

        private void cmbFolder_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                {
                    ComboBox tbxFolder = (ComboBox)sender;
                    tbxFolder.Text = LibStringFileFolderNames.CreateSpaceSeparatedFolderNamesString(new List<string>(files));

                    // e.Effect = DragDropEffects.All;
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void chkbUseDateTime_CheckedChanged(object sender, EventArgs e)
        {
            chkbDateRange.Visible = chkbUseDateTime.Checked;
            txtbRangeStart.Visible = chkbUseDateTime.Checked;
            txtbRangeStart.Visible = chkbUseDateTime.Checked;
            lblDateRange.Visible = chkbUseDateTime.Checked;
            chkbIsFileNotOlderThen.Visible = chkbUseDateTime.Checked;
            txtbOlderThenValue.Visible = chkbUseDateTime.Checked;
            cmbbOlderThenFaktor.Visible = chkbUseDateTime.Checked;
        }

        //private void cmbSearchString_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    ComboBox thisCombo = (ComboBox)sender;
        //    int Idx = e.Index;

        //    if (Idx > -1)
        //    {
        //        string Token = (string) thisCombo.Items[Idx];
        //        if (Global.SearchStringTokens.ContainsFixedToken(Token))
        //        {
        //            e.BackColor = Color.AliceBlue;
        //        }


        //        base.Events.


        //    }
        //}
    }
}

