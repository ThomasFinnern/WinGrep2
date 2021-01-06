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
    public partial class frmOptions : Form
    {
        CtrlOptionSearchResultView OptionSearchResultView = new CtrlOptionSearchResultView();
        CtrlOptionOnStartOfProgram OptionOnStartOfProgram = new CtrlOptionOnStartOfProgram();
        CtrlOptionWhileSearching OptionWhileSearching = new CtrlOptionWhileSearching();
        CtrlOptionTools OptionTools = new CtrlOptionTools();

        UserControl DisplayedOptionCtrl = null;
        List<UserControl> OptionCtrls = new List<UserControl>(); 

        public frmOptions()
        {
            InitializeComponent();

            OptionCtrls.Add(OptionSearchResultView); // 0
            OptionCtrls.Add(OptionWhileSearching); // 1
            OptionCtrls.Add(OptionOnStartOfProgram); // 2
            OptionCtrls.Add(OptionTools); // 3

            // ToDo: editor command Lines : OptionCtrls.Add(); // 1

            AssignConfig2Control();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            listBoxOptionWindows.Items.Clear();
            // listBoxOptionWindows.Items.AddRange(new string[] { "Main", "Sub", "", "" });
            listBoxOptionWindows.Items.AddRange(new string[] 
                {   // ToDO: use abstract class which forces title . Then use title here
                    "Search result view", 
                    "While searching", 
                    "On start of program", 
                    "Tools" 
                }
            );
            listBoxOptionWindows.SelectedIndex = 0;
        }

        private void listBoxOptionWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DisplayedOptionCtrl != null)
            {
                /*
                userControl.Parent = this.splitContainer1.Panel2;
                userControl.Dock = DockStyle.Fill;
                userControl.Visible = true;
                userControl.Focus();

                Um es später mal wieder zu entfernen:
                this.splitContainer1.Panel2.Controls.Remove(userControl);
                */

                DisplayedOptionCtrl.Visible = false;
                DisplayedOptionCtrl.Parent = null;
            }
            if (OptionCtrls.Count > listBoxOptionWindows.SelectedIndex)
                DisplayedOptionCtrl = OptionCtrls[listBoxOptionWindows.SelectedIndex];

            DisplayedOptionCtrl.Visible = true;
            DisplayedOptionCtrl.Parent = panelOptionWindow;

            panelOptionWindow.Controls.Clear();
            panelOptionWindow.Controls.Add(DisplayedOptionCtrl);
            
        }

        private void AssignConfig2Control()
        {
            Assign2ControlSearchViewProperties();
            Assign2ControlMain();
            // Global.Config.
        }

        private void Assign2ControlMain()
        {
            OptionOnStartOfProgram.checkBoxDoPopUpSearchOnStart.Checked = Global.Config.bDoPopUpSearchOnStart;
            OptionOnStartOfProgram.checkBoxDoRepeatLastSearchOnStart.Checked = Global.Config.bDoRepeatLastSearchOnStart;
            OptionOnStartOfProgram.checkBoxDoLoadLastOpenSearches.Checked = Global.Config.bDoLoadLastOpenSearchesOnStart;
            OptionOnStartOfProgram.checkBoxDoViewLastUsedSearchResult.Checked = Global.Config.bDoViewLastUsedSearchResultOnStart;

            OptionWhileSearching.checkBoxDoViewFileNamesOnSearch.Checked = Global.Config.bViewFileNamesOnSearch; 
            // toDo: own formular with title , Todo: all clt form shall have a title
            OptionWhileSearching.checkBoxDoCountFoldersOnSearch.Checked = Global.Config.bCountFoldersOnSearch;
            OptionWhileSearching.checkBoxDoCountFilesOnSearch.Checked = Global.Config.bCountFilesOnSearch;
        }

        private void Assign2ControlSearchViewProperties()
        {
            OptionSearchResultView.NbrShowFollowingLines.Text = Global.Config.ViewSetting.Show.LineNbrFollowingMatch.ToString();
            OptionSearchResultView.NbrShowPreviousLines.Text = Global.Config.ViewSetting.Show.LineNbrPreviousToMatch.ToString();

            OptionSearchResultView.NbrPrepareFollowingLines.Text = Global.Config.ViewSetting.Keep.LineNbrFollowingMatch.ToString();
            OptionSearchResultView.NbrPreparePreviousLines.Text = Global.Config.ViewSetting.Keep.LineNbrPreviousToMatch.ToString();

            // OptionMainView.chkCmdLineUseLastSearchProperties.Checked = Global.Config.bCmdLineUseLastSearchProperties;
            OptionSearchResultView.checkBoxDoShowTitle.Checked = Global.Config.ViewSetting.bDoShowTitle;
            OptionSearchResultView.checkBoxDoShowLineNumbers.Checked = Global.Config.ViewSetting.bDoShowLineNumbers;
            OptionSearchResultView.checkBoxDoShowFixedFont.Checked = Global.Config.ViewSetting.bDoShowFixedFont;
            OptionSearchResultView.checkBoxDoShowFileNames.Checked = Global.Config.ViewSetting.bDoShowFileNames;
            OptionSearchResultView.checkBoxDoShowFileContents.Checked = Global.Config.ViewSetting.bDoShowFileContents;
            OptionSearchResultView.checkBoxDoShowWholeLine.Checked = Global.Config.ViewSetting.bDoShowWholeLine;

            OptionSearchResultView.checkBoxUseDoShowTitle.Checked = Global.Config.ShowViewSelection.bDoShowTitle;
            OptionSearchResultView.checkBoxUseDoShowLineNumbers.Checked = Global.Config.ShowViewSelection.bDoShowLineNumbers;
            OptionSearchResultView.checkBoxUseDoShowFixedFont.Checked = Global.Config.ShowViewSelection.bDoShowFixedFont;
            OptionSearchResultView.checkBoxUseDoShowFileNames.Checked = Global.Config.ShowViewSelection.bDoShowFileNames;
            OptionSearchResultView.checkBoxUseDoShowFileContents.Checked = Global.Config.ShowViewSelection.bDoShowFileContents;
            OptionSearchResultView.checkBoxUseDoShowWholeLine.Checked = Global.Config.ShowViewSelection.bDoShowWholeLine;        
        }

        private void AssignControl2Config()
        {
            try
            {
                Assign2ConfigSearchViewProperties();
                Assign2ConfigMain();



                // Global.Config.bCmdLineUseLastSearchProperties = OptionMainView.chkCmdLineUseLastSearchProperties.Checked;
            }
            catch 
            {
                string OutTxt = "Wrong data in Config. Please change before startign search";
                // MessageBox.Show(OutTxt);
                Global.oDebugLog.MessageBox(OutTxt);
            }
        }
        private void Assign2ConfigMain()
        {
            Global.Config.bDoPopUpSearchOnStart = OptionOnStartOfProgram.checkBoxDoPopUpSearchOnStart.Checked;
            Global.Config.bDoRepeatLastSearchOnStart = OptionOnStartOfProgram.checkBoxDoRepeatLastSearchOnStart.Checked;
            Global.Config.bDoLoadLastOpenSearchesOnStart = OptionOnStartOfProgram.checkBoxDoLoadLastOpenSearches.Checked;
            Global.Config.bDoViewLastUsedSearchResultOnStart = OptionOnStartOfProgram.checkBoxDoViewLastUsedSearchResult.Checked;

            Global.Config.bViewFileNamesOnSearch = OptionWhileSearching.checkBoxDoViewFileNamesOnSearch.Checked;
            Global.Config.bCountFoldersOnSearch = OptionWhileSearching.checkBoxDoCountFoldersOnSearch.Checked;
            Global.Config.bCountFilesOnSearch = OptionWhileSearching.checkBoxDoCountFilesOnSearch.Checked;
        }

        private void Assign2ConfigSearchViewProperties()
        {
            //Global.Config.NbrKeepSearchToken = Convert.ToInt32 (OptionMainView.NbrKeepSearchToken.Text);
            Global.Config.ViewSetting.Show.LineNbrFollowingMatch = Convert.ToInt32(OptionSearchResultView.NbrShowFollowingLines.Text);
            Global.Config.ViewSetting.Show.LineNbrPreviousToMatch = Convert.ToInt32(OptionSearchResultView.NbrShowPreviousLines.Text);

            Global.Config.ViewSetting.Keep.LineNbrFollowingMatch = Convert.ToInt32(OptionSearchResultView.NbrPrepareFollowingLines.Text);
            Global.Config.ViewSetting.Keep.LineNbrPreviousToMatch = Convert.ToInt32(OptionSearchResultView.NbrPreparePreviousLines.Text);


            Global.Config.ViewSetting.bDoShowTitle = OptionSearchResultView.checkBoxDoShowTitle.Checked;
            Global.Config.ViewSetting.bDoShowLineNumbers = OptionSearchResultView.checkBoxDoShowLineNumbers.Checked;
            Global.Config.ViewSetting.bDoShowFixedFont = OptionSearchResultView.checkBoxDoShowFixedFont.Checked;
            Global.Config.ViewSetting.bDoShowFileNames = OptionSearchResultView.checkBoxDoShowFileNames.Checked;
            Global.Config.ViewSetting.bDoShowFileContents = OptionSearchResultView.checkBoxDoShowFileContents.Checked;
            Global.Config.ViewSetting.bDoShowWholeLine = OptionSearchResultView.checkBoxDoShowWholeLine.Checked;

            Global.Config.ShowViewSelection.bDoShowTitle = OptionSearchResultView.checkBoxUseDoShowTitle.Checked;
            Global.Config.ShowViewSelection.bDoShowLineNumbers = OptionSearchResultView.checkBoxUseDoShowLineNumbers.Checked;
            Global.Config.ShowViewSelection.bDoShowFixedFont = OptionSearchResultView.checkBoxUseDoShowFixedFont.Checked;
            Global.Config.ShowViewSelection.bDoShowFileNames = OptionSearchResultView.checkBoxUseDoShowFileNames.Checked;
            Global.Config.ShowViewSelection.bDoShowFileContents = OptionSearchResultView.checkBoxUseDoShowFileContents.Checked;
            Global.Config.ShowViewSelection.bDoShowWholeLine = OptionSearchResultView.checkBoxUseDoShowWholeLine.Checked;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            AssignControl2Config();
            Global.Config.SaveClass2UserFile();

            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}