using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;

using LibWindowsForms;
using AppPaths;
using ErrorCapture;
using MainGlobal;
//using LogInputKeys;

namespace NetGrep
{



    /* webSearchResult, webFileList
     * http://stackoverflow.com/questions/5867662/winforms-webbrowser-blocking-processcmdkey
    WebBrowser browser = new WebBrowser();

    ...
    browser.Document.Body.KeyDown += new HtmlElementEventHandler(Body_KeyDown);
    ...
    private void Body_KeyDown(Object sender, HtmlElementEventArgs e)
    {
        if(e.KeyPressedCode==83 && e.CtrlKeyPressed)
            MessageBox.Show("Give me some cookies");
    }
     * 
     if (msg.Msg == 0x101    //WM_KEYUP
    
     
     
     */

    [ComVisibleAttribute(true)]
    public partial class frmSearchResultView : Form
    {
        private bool bIsAssingData2CtrlActive = false;
        public bool RequestSearchProperties;
        public bool bDoRequestRestartSearch;
        public bool RequestReplaceProperties;
        clsOneStringPerTime LastTitle = new clsOneStringPerTime();
        clsOneStringPerTime LastInfo = new clsOneStringPerTime();
        System.Timers.Timer TimerUpdateInfos = new System.Timers.Timer ();

        private clsSearchProperties LocalSearchProperties = null;
        public clsSearchProperties SearchProperties
        {
            get { return LocalSearchProperties; }
        }

        private clsSearchExecute LocalSearchResults = null;
        public clsSearchExecute SearchResults
        {
            get { return LocalSearchResults; }
        }


        public frmSearchResultView(frmNetGrepWinProgram oParent,
            clsSearchProperties InSearchProperties,
            clsSearchExecute InLocalSearchResults
            ) 
        {
            InitializeComponent();
            AssignWebRowserParentOwner(oParent);
            // AssingWebRowserOnKeydownevents();

            //this.WindowState = FormWindowState.Maximized;
            //this.ControlBox = false;
            //this.Dock = DockStyle.Fill;
            //this.Visible = false;
            //this.Owner = MdiForm.Owner;
            //this.MdiParent = MdiForm.Owner;
            //this.WindowState = FormWindowState.Maximized;

            LocalSearchProperties = InSearchProperties;
            LocalSearchResults = InLocalSearchResults;
            AssignConfig2Control();
        }

        //private void AssingWebRowserOnKeydownevents()
        //{
        //    // webFileList.Document.Body.KeyDown += new HtmlElementEventHandler(webFileList_Keydown);
        //    // webSearchResult.Document.Body.KeyDown += new HtmlElementEventHandler(webSearchResult_Keydown);
        //}

        public void AssignWebRowserParentOwner(frmNetGrepWinProgram oParent)
        {
            this.MdiParent = oParent;
            webFileList.ObjectForScripting = this;
            webSearchResult.ObjectForScripting = this;
        }

        // public clsSearchResults SearchResults = new clsSearchResults(); 

        private void AssignConfig2Control()
        {
            bIsAssingData2CtrlActive = true;
            numericUpDownPreLines.Value = LocalSearchProperties.ViewSetting.Show.LineNbrPreviousToMatch;
            numericUpDownPostLines.Value = LocalSearchProperties.ViewSetting.Show.LineNbrFollowingMatch;

            numericUpDownPreLines.Maximum = LocalSearchProperties.ViewSetting.Keep.LineNbrPreviousToMatch;
            numericUpDownPostLines.Maximum = LocalSearchProperties.ViewSetting.Keep.LineNbrFollowingMatch;

            // checkBoxDoShowTitle.Visible = LocalSearchProperties.ShowViewSelection.bDoShowTitle;
            checkBoxDoShowTitle.Checked = LocalSearchProperties.ViewSetting.bDoShowTitle;

            // checkBoxDoShowLineNbrs.Visible = LocalSearchProperties.ShowViewSelection.bDoShowLineNumbers;
            checkBoxDoShowLineNbrs.Checked = LocalSearchProperties.ViewSetting.bDoShowLineNumbers;

            // checkBoxDoShowFileContents.Visible = LocalSearchProperties.ShowViewSelection.bDoShowFileContents;
            checkBoxDoShowFileContents.Checked = LocalSearchProperties.ViewSetting.bDoShowFileContents;

            // checkBoxDoShowFixedFont.Visible = LocalSearchProperties.ShowViewSelection.bDoShowFixedFont;
            checkBoxDoShowFixedFont.Checked = LocalSearchProperties.ViewSetting.bDoShowFixedFont;

            // checkBoxDoShowFileNames.Visible = LocalSearchProperties.ShowViewSelection.bDoShowFileNames;
            checkBoxDoShowFileNames.Checked = LocalSearchProperties.ViewSetting.bDoShowFileNames;

            // checkBoxDoShowFileContents.Visible = LocalSearchProperties.ShowViewSelection.bDoShowFileContents;
            checkBoxDoShowFileContents.Checked = LocalSearchProperties.ViewSetting.bDoShowFileContents;

            // checkBoxDoShowWholeLine.Visible = LocalSearchProperties.ShowViewSelection.bDoShowWholeLine;
            checkBoxDoShowWholeLine.Checked = LocalSearchProperties.ViewSetting.bDoShowWholeLine;

            checkBoxDoShowDoubleBlanks.Checked = LocalSearchProperties.ViewSetting.bDoShowDoubleBlanks;
            

            bIsAssingData2CtrlActive = false;
        }

        public void AssignControl2Config()
        {
            LocalSearchProperties.ViewSetting.Show.LineNbrPreviousToMatch = Convert.ToInt32(numericUpDownPreLines.Value);
            LocalSearchProperties.ViewSetting.Show.LineNbrFollowingMatch = Convert.ToInt32(numericUpDownPostLines.Value);

            // Maximum doesn't change
            // LocalSearchProperties.ViewSetting.Keep.LineNbrPreviousToMatch = numericUpDownPreLines.Maximum;
            // LocalSearchProperties.ViewSetting.Keep.LineNbrFollowingMatch = numericUpDownPostLines.Maximum;

            // LocalSearchProperties.ShowViewSelection.bDoShowTitle = checkBoxDoShowTitle.Visible;
            LocalSearchProperties.ViewSetting.bDoShowTitle = checkBoxDoShowTitle.Checked;

            // LocalSearchProperties.ShowViewSelection.bDoShowLineNumbers = checkBoxDoShowLineNbrs.Visible;
            LocalSearchProperties.ViewSetting.bDoShowLineNumbers = checkBoxDoShowLineNbrs.Checked;

            // LocalSearchProperties.ShowViewSelection.bDoShowFileContents = checkBoxDoShowFileContents.Visible;
            LocalSearchProperties.ViewSetting.bDoShowFileContents = checkBoxDoShowFileContents.Checked;

            // LocalSearchProperties.ShowViewSelection.bDoShowFixedFont = checkBoxDoShowFixedFont.Visible;
            LocalSearchProperties.ViewSetting.bDoShowFixedFont = checkBoxDoShowFixedFont.Checked;

            // LocalSearchProperties.ShowViewSelection.bDoShowFileNames = checkBoxDoShowFileNames.Visible;
            LocalSearchProperties.ViewSetting.bDoShowFileNames = checkBoxDoShowFileNames.Checked;

            // LocalSearchProperties.ShowViewSelection.bDoShowFileContents = checkBoxDoShowFileContents.Visible;
            LocalSearchProperties.ViewSetting.bDoShowFileContents = checkBoxDoShowFileContents.Checked;

            // LocalSearchProperties.ShowViewSelection.bDoShowWholeLine = checkBoxDoShowWholeLine.Visible;
            LocalSearchProperties.ViewSetting.bDoShowWholeLine = checkBoxDoShowWholeLine.Checked;

            // todo ....
            LocalSearchProperties.ViewSetting.bDoShowDoubleBlanks = checkBoxDoShowDoubleBlanks.Checked;
        }

        public void AssignControl2ConfigAndSave()
        {
            AssignControl2Config();
            LocalSearchProperties.SaveClass2UserFile();
        }

        public void ShowEmptyResults()
        {
            webFileList.DocumentText = "<html><body> empty search file list </body></html>"; // SearchResultFileListAsHtml.FoundFileNamesHtmlDocument();
            // webFileList.Document.Body.KeyDown += new HtmlElementEventHandler(webFileList_Keydown);

            webSearchResult.DocumentText = "<html><body> empty search results </body></html>"; // SearchResultTokenLinesAsHtml.FoundTokenLinesHtmlDocument();
            // webSearchResult.Document.Body.KeyDown += new HtmlElementEventHandler(webSearchResult_Keydown);

            Application.DoEvents();
        }

        public void WriteResultFileListHtmlFile(string FileName)
        {
            string HtmlDocText = webFileList.DocumentText;
            WriteResultFileListHtmlFile(FileName, HtmlDocText);
        }

        public void WriteResultFileListHtmlFile(string FileName, string HtmlDocText)
        {
            if (File.Exists(FileName))
            {
                //Global.oDebugLog.DPrint("File will be overwritten:" + FileName);
                //string OutTxt = string.Format("Error in DoCmdReadNcsFile: File: {0} does not exist.", UsePathFileName);
                //Global.oDebugLog.MessageBox(OutTxt); 
                //return;
            }

            //----------------------------------------------------------------------------
            // Write
            //----------------------------------------------------------------------------

            FileStream OutHtmlFile = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            if (OutHtmlFile != null)
            {
                string OutTxt = HtmlDocText;
                StreamWriter TxtWriter = new StreamWriter(OutHtmlFile, System.Text.Encoding.Default);

                TxtWriter.Write(OutTxt);
                TxtWriter.Flush();   // Puffer => Disk
                TxtWriter.Close();

                OutHtmlFile.Close();
            }

            return;
        }



        public void WriteResultTokenLinesHtmlFile(string FileName)
        {
            string HtmlDocText = webSearchResult.DocumentText;
            WriteResultTokenLinesHtmlFile(FileName, HtmlDocText);
        }

        public void WriteResultTokenLinesHtmlFile(string FileName, string HtmlDocText)
        {
            if (File.Exists(FileName))
            {
                //Global.oDebugLog.DPrint("File will be overwritten:" + FileName);
                //string OutTxt = string.Format("Error in DoCmdReadyyyFile: File: {0} does not exist.", UsePathFileName);
                //Global.oDebugLog.MessageBox(OutTxt); 
                //return;
            }

            //----------------------------------------------------------------------------
            // Write
            //----------------------------------------------------------------------------

            FileStream OutHtmlFile = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            if ((OutHtmlFile != null))
            {
                string OutTxt = HtmlDocText;
                StreamWriter TxtWriter = new StreamWriter(OutHtmlFile, System.Text.Encoding.Default);

                TxtWriter.Write(OutTxt);
                TxtWriter.Flush();   // Puffer => Disk
                TxtWriter.Close();

                OutHtmlFile.Close();
            }

            return;
        }

        public void ShowResults()
        {
            try
            {
                // Shall be done already: ShowTitleInManuBar();
                ShowResultFileListAsHtml();
                ShowResultTokenLinesAsHtml();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void ShowTitleInManuBar()
        {
            try
            {
                /*
                this.Text = SearchResults.SearchResultInfo.SearchProperties.SearchString + ":  ";
                foreach (string FolderName in SearchResults.SearchResultInfo.SearchProperties.SearchFolders)
                {
                    this.Text += FolderName;
                }
                */

                if (LocalSearchResults != null)
                {
                    this.Text = LocalSearchResults.SearchResultInfo.SearchProperties.IdSearchQueryDistinguishView();

                    // tell windows about it
                    this.ActivateMdiChild(null);
                    this.ActivateMdiChild(this);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void ShowResultFileListAsHtml()
        {
            try
            {
                if (LocalSearchResults != null)
                {
                    clsSearchResultFileListAsHtml SearchResultFileListAsHtml = new clsSearchResultFileListAsHtml(LocalSearchResults.SearchResultInfo,
                        LocalSearchResults.Files2LineResults, LocalSearchResults.SearchResultInfo.SearchProperties.SearchString);
                    string webFileListText = SearchResultFileListAsHtml.FoundFileNamesHtmlDocument();
                    webFileList.DocumentText = webFileListText;

                    // http://stackoverflow.com/questions/4459690/how-to-feed-webbrowser-control-and-manipulate-the-html-document


                    // webFileList.Document.Body.KeyDown += new HtmlElementEventHandler(webFileList_Keydown);

                    // Html document not accepted ?
                    Application.DoEvents();

                    string HtmlOutFile = clsAppPaths.UserPathName.PathName + "\\" + "SearchResultFileListAsHtml.htm";

                    //if (webFileList.DocumentText == "")
                    if (webFileList.DocumentText.Length < 16)
                    {
                        MessageBox.Show("Html document for file list not accepted ? content not conform with html ?\r\n"
                        + "See file: " + HtmlOutFile);
                        WriteResultFileListHtmlFile(HtmlOutFile, webFileListText);

                        webSearchResult.DocumentText = "<html><body>Creation of file list lines failed (HTML)</body></html>";
                        // webSearchResult.Document.Body.KeyDown += new HtmlElementEventHandler(webFileList_Keydown);
                    }
                    else
                    {
                        //SearchResultFileListAsHtml.WriteResultFileHtml(
                        ////    Path.GetDirectoryName(Application.ExecutablePath) + "\\" + 
                        // Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" +
                        //    "..\\..\\..\\Data\\SearchResultFileListAsHtml.htm"
                        //    );
                        WriteResultFileListHtmlFile(HtmlOutFile);
                    }
                }
                else
                {
                    webFileList.DocumentText = "<html><body>SearchResults == null</body></html>";
                    // webFileList.Document.Body.KeyDown += new HtmlElementEventHandler(webFileList_Keydown);
                }
                Application.DoEvents();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void ShowResultTokenLinesAsHtml()
        {
            try
            {
                if (LocalSearchResults == null)
                    return;

                clsSearchResultTokenLinesAsHtml SearchResultTokenLinesAsHtml =
                    new clsSearchResultTokenLinesAsHtml(LocalSearchResults.Files2LineResults);
                string webSearchResultText = SearchResultTokenLinesAsHtml.FoundFilesWithTokenLinesHtmlDocument(
                    LocalSearchProperties.ViewSetting.Show,
                    LocalSearchProperties.ViewSetting);
                webSearchResult.DocumentText = webSearchResultText;
                // webSearchResult.Document.Body.KeyDown += new HtmlElementEventHandler(webSearchResult_Keydown);
                Application.DoEvents();

                string HtmlOutFile = clsAppPaths.UserPathName.PathName + "\\" + "SearchResultTokenLinesAsHtml.htm";
                //if (webSearchResult.DocumentText == "")
                if (webSearchResult.DocumentText.Length < 15)
                {
                    MessageBox.Show("Html document for search results is not accepted ? content not conform with html ? \r\n"
                        + "See file : " + HtmlOutFile);
                    WriteResultTokenLinesHtmlFile(HtmlOutFile, webSearchResultText);

                    webSearchResult.DocumentText = "<html><body>Creation of token lines failed (HTML)</body></html>";
                    // webSearchResult.Document.Body.KeyDown += new HtmlElementEventHandler(webSearchResult_Keydown);
                }
                else
                {
                    //SearchResultTokenLinesAsHtml.WriteFileFoundFilesWithTokenLinesHtmlDocument(
                    //// Path.GetDirectoryName(Application.ExecutablePath) + "\\" +
                    // Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" +
                    //    "..\\..\\..\\Data\\SearchResultTokenLinesAsHtml.htm"
                    //    );
                    WriteResultTokenLinesHtmlFile(HtmlOutFile);
                    //this.WindowState = FormWindowState.Maximized;
                }
                this.Visible = true;

                Application.DoEvents();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public bool RequestSearchPropertiesInput()
        {
            try
            {
                frmSearchProperties SearchPropertiesView = new frmSearchProperties(LocalSearchProperties);
                // SearchPropertiesView.SearchProperties = ;
                // SearchPropertiesView.AssignConfig2Control();
                SearchPropertiesView.ShowDialog(this);

                //----------------------------------------------------------------------------
                // Search requested ?
                //----------------------------------------------------------------------------

                return SearchPropertiesView.bDoStartSearch;

            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return false;
        }

        public void RequestPropertiesInputDoSearchAndShow()
        {
            bool bDoStartSearch;

            bDoStartSearch = RequestSearchPropertiesInput();

            //----------------------------------------------------------------------------
            // Search requested ?
            //----------------------------------------------------------------------------

            if (bDoStartSearch)
            {
                Global.AssignLastSearchQuery(LocalSearchProperties);

                // Lines shown previus and post to found lines 
                bIsAssingData2CtrlActive = true;
                numericUpDownPreLines.Value = LocalSearchProperties.ViewSetting.Show.LineNbrPreviousToMatch;
                numericUpDownPostLines.Value = LocalSearchProperties.ViewSetting.Show.LineNbrFollowingMatch;
                numericUpDownPreLines.Maximum = LocalSearchProperties.ViewSetting.Keep.LineNbrPreviousToMatch;
                numericUpDownPostLines.Maximum = LocalSearchProperties.ViewSetting.Keep.LineNbrFollowingMatch;
                bIsAssingData2CtrlActive = false;

                ShowTitleInManuBar();

                // Execute search
                ExecuteSearchFromForm();

                // Show search
                ShowResults();
            }
        }

        public void ExecuteSearchFromForm()
        {
            try
            {
                clsSearchExecute OldSearchResults = LocalSearchResults;

                // Start Search
                LocalSearchResults = new clsSearchExecute();

                // Collect files from last search if requested
                if (LocalSearchProperties.bSearchInFoundFiles)
                {
                    bool bUsedOldSearchResults = false;
                    if (OldSearchResults != null)
                    {
                        if (OldSearchResults.Files2LineResults.Count > 0)
                        {
                            bUsedOldSearchResults = true;
                            LocalSearchResults.Files2LineResults = OldSearchResults.Files2LineResults;
                        }
                    }

                    if (!bUsedOldSearchResults)
                    {
                        string OutTxt = "";
                        OutTxt += "Search files from last search not given but requested from search properties" + "\r\n";
                        OutTxt += "Using standard files and folders for search";
                        MessageBox.Show(OutTxt);
                    }
                }

                ShowEmptyResults();

                ResetStripStatus();

                // Activate Timer
                TimerUpdateInfos.Interval = 250; // 0.250 sec
                TimerUpdateInfos.Elapsed += new System.Timers.ElapsedEventHandler(timerUpdateInfos_Tick);
                TimerUpdateInfos.Start();

                LocalSearchResults.OnSetTitle += OnSetTitle;
                LocalSearchResults.OnSetInfo += OnSetInfo;
                LocalSearchResults.OnUpdateFolderCount += OnUpdateFolderCount;
                LocalSearchResults.OnUpdateFileCount += OnUpdateFileCount;
                LocalSearchResults.OnUpdateTime += OnUpdateTime;

                //----------------------------------------------------------------------------
                // Do search requested ?
                //----------------------------------------------------------------------------

                LocalSearchResults.ExecuteSearch(LocalSearchProperties);

                TimerUpdateInfos.Stop();
                timerUpdateInfos_Tick(this, new EventArgs());
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void frmDoSearch_Shown(object sender, EventArgs e)
        {
            // request search input on startup
            if (RequestSearchProperties)
                RequestPropertiesInputDoSearchAndShow();
            else
            {
                if (bDoRequestRestartSearch)
                {
                    ExecuteSearchFromForm();
                    ShowResults();
                }            
            }
        }

        private void timerUpdateInfos_Tick(object sender, EventArgs e)
        {
            //// ToDo : fix timer 
            //if (LastTitle.bLastInfoIsSet)
            //{
            //    string Temp = LastTitle.LastInfoOnce();
            //    //if (Temp.Length > 0) // debug purposes
            //    //    Temp = Temp;
            //    toolStripStatusLblTitleText.Text = Temp;         // ToDo: invalid code exception w.g Thread       
            //    //toolStripStatusLblTitleText.Text = LastTitle.LastInfoOnce();
            //    LastTitle.LastInfo = "";

            //    Application.DoEvents();
            //}
            //if (LastInfo.bLastInfoIsSet)
            //{
            //    string Temp = LastInfo.LastInfoOnce();
            //    //if (Temp.Length > 0) // debug purposes
            //    //    Temp = Temp;
            //    toolStripStatusActInfoText.Text = Temp;
            //    LastTitle.LastInfo = "";

            //    Application.DoEvents();
            //}
        }

        private void ResetStripStatus()
        {
            //toolStripStatusTitleText.Text = "";
            toolStripStatusLblTitleText.Text = "";
            toolStripStatusActInfoText.Text = "";

            // Progressbar

        }

        // private EventHandler <clsEventArgsWithOneMessage> OnSetTitle (object sender, clsEventArgsWithOneMessage e)
        private void OnSetTitle(object sender, clsEventArgsWithOneMessage eTitle)
        {
            // LastTitle.LastInfo = e.Message;
            toolStripStatusLblTitleText.Text = eTitle.Message;
            //toolStripStatusLblTitleText.Invalidate();
            Application.DoEvents();
        }

        // private EventHandler <clsEventArgsWithOneMessage> OnSetTitle (object sender, clsEventArgsWithOneMessage e)
        private void OnSetInfo(object sender, clsEventArgsWithOneMessage eInfo)
        {
            if (Global.Config.bViewFileNamesOnSearch)
            {

                // LastInfo.LastInfo = e.Message;
                toolStripStatusActInfoText.Text = eInfo.Message;
                // toolStripStatusActInfoText.Invalidate();
                Application.DoEvents();
            }
        }

        private void OnUpdateFolderCount (object sender, clsEventArgsWithOneMessage eInfo)
        {
            if (Global.Config.bCountFoldersOnSearch)
            {

                // LastInfo.LastInfo = e.Message;
                toolStripStatusLblFolderNbrText.Text = eInfo.Message;
                // toolStripStatusLblFolderNbrText.Invalidate();
                Application.DoEvents();
            }
        }

        private void OnUpdateFileCount(object sender, clsEventArgsWithOneMessage eInfo)
        {
            if (Global.Config.bCountFilesOnSearch)
            {
                // LastInfo.LastInfo = e.Message;
                toolStripStatusLblFileNbrText.Text = eInfo.Message;
                // toolStripStatusLblFileNbrText.Invalidate();
                Application.DoEvents();
            }
        }

        private void OnUpdateTime(object sender, clsEventArgsWithOneMessage eInfo)
        {
            // if (Global.Config.bCountFilesOnSearch)
            {
                // LastInfo.LastInfo = e.Message;
                toolStripStatusLbTimeText.Text = eInfo.Message;
                // toolStripStatusLbTimeText.Invalidate();
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Here all short cuts may be used 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            //Global.LogInputKeys.AddKeyValue("PrR", keys);

            switch (keys)
            {
                case (Keys.Control | Keys.T):
                    // MessageBox.Show("Ctrl+S: Exe");
                    //Global.LogInputKeys.AddKeyValue("PrP", keys);
                    return true;
            }

            return base.ProcessCmdKey(ref message, keys);
        }

        private void webFileList_Keydown(Object sender, HtmlElementEventArgs e)
        {
            //Global.LogInputKeys.AddKeyValue("WbKf", e);

        }

        private void webSearchResult_Keydown(Object sender, HtmlElementEventArgs e)
        {
            //Global.LogInputKeys.AddKeyValue("WbKs", e);


        }


        private bool webFileList_skipOnce = false;
        /// <summary>
        ///  Handles keys local to the calling webbrowser other webbrowser keys go to central function (default)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webFileList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                //Global.LogInputKeys.AddKeyValue("Wbf", e);

                if (webFileList_skipOnce)
                {
                    webFileList_skipOnce = false;
                    return;
                }
                
                if (e.Control && !e.Shift && !e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            // Todo: simul ? e.Handled = true;
                            webCopy(webFileList);
                            webFileList_skipOnce = true;
                            break;

                        case Keys.A:
                            webSelectAllText(webFileList); ;
                            webFileList_skipOnce = true;
                            break;

                        case Keys.T: // ToDO: Remove
                            // Global.LogInputKeys.AddKeyValue("Wbf", e);
                            break;

                        default:
                            // Todo: simul ? e.Handled = false;
                            webFileList_skipOnce = webBrowserStandard_PreviewKeyDown(sender, e);
                            break;
                    }
                }

            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private bool webSearchResult_skipOnce = false;
        /// <summary>
        ///  Handles keys local to the calling webbrowser other webbrowser keys go to central function (default)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webSearchResult_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                //Global.LogInputKeys.AddKeyValue("Wbs", e);

                //frmNetGrepWinProgram MdiForm = null;
                if (webSearchResult_skipOnce)
                {
                    webSearchResult_skipOnce = false;
                    return;
                }

                if (e.Control && !e.Shift && !e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            // Todo: simul ? e.Handled = true;
                            webCopy(webSearchResult);
                            webFileList_skipOnce = true;
                            break;

                        case Keys.A:
                            webSelectAllText(webSearchResult); ;
                            webFileList_skipOnce = true;
                            break;

                        default:
                            // Todo: simul ? e.Handled = false;
                            webFileList_skipOnce = webBrowserStandard_PreviewKeyDown(sender, e);
                            break;
                    }
                }

            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        /// <summary>
        /// Handle keys which are assigned to the webBrowser which are not local to a certain browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool webBrowserStandard_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            bool webKeys_skipOnce = false;

            try
            {
                frmNetGrepWinProgram MdiForm = null;

//                Global.LogInputKeys.AddKeyValue("Web", e.KeyCode, 0);

                if (e.Control && !e.Shift && !e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.F:
                            // Todo: simul ? e.Handled = true;
                            RequestPropertiesInputDoSearchAndShow();
                            webFileList_skipOnce = true;
                            break;

                        case Keys.N:
                            MdiForm = (frmNetGrepWinProgram)clsActiveMainForm.SearchMdiParentForm();
                            MdiForm.newSearchToolStripMenuItem_Click(sender, new EventArgs());
                            webFileList_skipOnce = true;
                            break;

                        case Keys.O: // open search 
                            MdiForm = (frmNetGrepWinProgram)clsActiveMainForm.SearchMdiParentForm();
                            MdiForm.openSearchQueryToolStripMenuItem_Click(sender, new EventArgs());
                            webFileList_skipOnce = true;
                            // webFileList.se;
                            break;

                        case Keys.S: // Save search
                            MdiForm = (frmNetGrepWinProgram)clsActiveMainForm.SearchMdiParentForm();
                            MdiForm.saveSearchQueryToolStripMenuItem_Click(sender, new EventArgs());
                            webFileList_skipOnce = true;
                            break;

                        /**/
                        case Keys.F6:
                            // Next Form forward
                            MdiForm = (frmNetGrepWinProgram)clsActiveMainForm.SearchMdiParentForm();
                            MdiForm.SelectNextControl(MdiForm.ActiveControl, true, true, true, true);
                            webFileList_skipOnce = true;
                            break;
                        /**/

                        default:
                            break;
                    }
                }

                if (!e.Control && !e.Shift && e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.R: // Re - search  (again no user change)
                            MdiForm = (frmNetGrepWinProgram)clsActiveMainForm.SearchMdiParentForm();
                            MdiForm.restartSearchToolStripMenuItem_Click(sender, new EventArgs());
                            webFileList_skipOnce = true;
                            break;

                        default:
                            // Todo: simul ? e.Handled = false;
                            break;
                    }

                }

                //if (!e.Control && e.Shift && !e.Alt)
                //{
                //    /*
                //                    switch (e.KeyCode)
                //                    {
                //                        //case Keys.A:
                //                        //    // webFileList.se;
                //                        //    break;


                //                        default:
                //                            // Todo: simul ? e.Handled = false;
                //                            break;
                //                    }

                //    */

                //}



                //if (e.Control && e.Shift)
                //{
                //    if (e.KeyCode != Keys.Shift)
                //    {
                //        int test = 1;                    
                //    }

                //}

                /**/
                if (e.Control && e.Shift && !e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.F6:
                            // Next Form backward
                            MdiForm = (frmNetGrepWinProgram)clsActiveMainForm.SearchMdiParentForm();
                            MdiForm.SelectNextControl(MdiForm.ActiveControl, false, true, true, true);
                            break;
                    }
                }
                /**/

            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return webKeys_skipOnce;
        }

        /*
        http://stackoverflow.com/questions/1980515/webbrowser-keyboard-shortcuts

        override PreProcessMessage







        // */



        private void webCopy(WebBrowser InBrowser)
        {
            InBrowser.Document.ExecCommand("Copy", false, null);
        }
        
        private void webSelectAllText(WebBrowser InBrowser)
        {
            InBrowser.Document.ExecCommand("SelectAll", false, null);
            //mshtml.IHTMLDocument2 doc = (mshtml.IHTMLDocument2)webBrowser1.Document.DomDocument;
            //mshtml.IHTMLBodyElement body = (mshtml.IHTMLBodyElement)doc.body;
            //mshtml.IHTMLTxtRange range = body.createTextRange();
            //range.select();

//            doc.execCommand("Copy", false, null);

            //doc.execCommand("Unselect", false, null);            //InBrowser.Document.ExecCommand("Copy", false, null);
            //Document.ExecCommand("Unselect", false, null);
        }

        public void RequestReplacePropertiesInputDoReplace()
        {
            bool bDoStartReplace;

            bDoStartReplace = RequestReplacePropertiesInput();

            //----------------------------------------------------------------------------
            // Replace requested ?
            //----------------------------------------------------------------------------

            if (bDoStartReplace)
            {
                // ToDo: Check for LocalSearchProperties.bReplaceInSelectedFiles 
                //    ==> Open window with list and then create LocalSearchProperties copy with selected files ..
                //    .




                //DoSearchFromForm();
                LocalSearchResults.ExecuteReplace(LocalSearchProperties);

                // What to do when repalce is finished (old search may be wrong though ....
                // Show search
                //ShowResults();
            }
        }

        public bool RequestReplacePropertiesInput()
        {
            frmReplaceProperties ReplacePropertiesView = new frmReplaceProperties(LocalSearchProperties);
            // ReplacePropertiesView.SearchProperties = LocalSearchProperties;
            // ReplacePropertiesView.AssignConfig2Control();
            ReplacePropertiesView.ShowDialog(this);

            //----------------------------------------------------------------------------
            // Search requested ?
            //----------------------------------------------------------------------------

            return ReplacePropertiesView.bDoStartReplace;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webFileList.Document.InvokeScript("testIn",
                new String[] { "Called from c# form code" });
        }

        public void webFileList_HtmlDoubleClick(object oHtmlSourceIn)
        {
            string FileName;
            string PathName;
            string SrcPathFileName;
            // HtmlElementCollection Elements;

            HtmlElement oHtmlSource = webFileList.Document.ActiveElement;
            HtmlElement oHtmlParentTr = oHtmlSource.Parent;
            //HtmlElement oHtmlParentTable = oHtmlParentTr.Parent;
            HtmlElement FirstCell = oHtmlParentTr.FirstChild;
            HtmlElement NextCell = FirstCell.NextSibling;

            try
            {
                FileName = FirstCell.InnerText;
                PathName = NextCell.InnerText;
                SrcPathFileName = Path.Combine(PathName, FileName);

                // MessageBox.Show("DoubleClick: PathFileName: " + SrcPathFileName);

                frmSearchResultRichTextView SearchResultRichTextView = new frmSearchResultRichTextView ();
                SearchResultRichTextView.NextFileName = SrcPathFileName;
                SearchResultRichTextView.SearchResults = LocalSearchResults;
                SearchResultRichTextView.Show(this);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }


        public void webFileList_HtmlClick(object oHtmlSourceIn)
        {
            string FileName;
            string PathName;
            string SrcPathFileName;
            HtmlElementCollection Elements;

            try
            {
                HtmlElement oHtmlSource = webFileList.Document.ActiveElement;
                HtmlElement oHtmlParentTr = oHtmlSource.Parent;
                //HtmlElement oHtmlParentTable = oHtmlParentTr.Parent;
                HtmlElement FirstCell = oHtmlParentTr.FirstChild;
                HtmlElement NextCell = FirstCell.NextSibling;

                FileName = FirstCell.InnerText;
                PathName = NextCell.InnerText;
                SrcPathFileName = Path.Combine(PathName, FileName);

                // MessageBox.Show("PathFileName: " + SrcPathFileName);

                //--- set this element to bold ---------------------------------------------------
                // Elements = webFileList.Document.GetElementsByTagName(oHtmlParentTr.TagName);
                Elements = webSearchResult.Document.GetElementsByTagName("span");
 
                ////--- Move file part in second web into view ---------------------------------------------------
                              
                foreach (HtmlElement Element in Elements)
                {
                    string DstPathFileName = Element.InnerHtml;
                    if (SrcPathFileName.Equals(DstPathFileName))
                    {
                        Element.ScrollIntoView(true);
                        break;
                    }
                }

                ////HtmlElement oHtmlParent = oHtmlSource.Parent;
                ////HtmlElement oHtmlFirstChild = oHtmlParent.FirstChild;
                //// http://support.microsoft.com/kb/312777/en-us
                //// http://msdn.microsoft.com/en-us/library/aa770041(v=VS.85).aspx

                // geht nicht
                FileNameList_HighLightOneName(SrcPathFileName);


            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        //public void webFileList_TestMessage(String message)
        //{
        //    MessageBox.Show(message, "from webFileList HTML");
        //}

        private void FileNameList_HighLightOneName(string SearchFoundSrcPathFileName)
        {
            string FoundFileName;
            string FoundPathName;
            string FoundSrcPathFileName;
            HtmlElementCollection Elements;

            Elements = webFileList.Document.GetElementsByTagName("tr");
            foreach (HtmlElement oHtmlParentTr in Elements)
            {
                HtmlElement FirstCell = oHtmlParentTr.FirstChild;
                HtmlElement NextCell = FirstCell.NextSibling;

                FoundFileName = FirstCell.InnerText;
                FoundPathName = NextCell.InnerText;
                FoundSrcPathFileName = Path.Combine(FoundPathName, FoundFileName);

                if (SearchFoundSrcPathFileName == FoundSrcPathFileName)
                {
                   //  ... css updaten

                    oHtmlParentTr.SetAttribute("className", "highlight");
                }
                else
                {
                    oHtmlParentTr.SetAttribute("className", "");
                }
            }

/*
            foreach (HtmlElement oHtmlParentTr in Elements)
            {
                HtmlElement FirstCell = oHtmlParentTr.FirstChild;
                HtmlElement NextCell = FirstCell.NextSibling;

                FoundFileName = FirstCell.InnerText;
                FoundPathName = NextCell.InnerText;
                FoundSrcPathFileName = Path.Combine(FoundPathName, FoundFileName);

                if (SearchFoundSrcPathFileName == FoundSrcPathFileName)
                {
                    //  ... css updaten

                    oHtmlParentTr.SetAttribute("class", "highlight");
                }
            }
*/
        }

        private void numericUpDownPreLines_ValueChanged(object sender, EventArgs e)
        {
            if (!bIsAssingData2CtrlActive)
            {
                AssignControl2ConfigAndSave();

                // long LineNbrPreviousToMatch = Convert.ToInt32(numericUpDownPreLines.Value);
                //if (LocalSearchProperties.ViewSetting.Show.LineNbrPreviousToMatch != LineNbrPreviousToMatch)
                //{
                //    LocalSearchProperties.ViewSetting.Show.LineNbrPreviousToMatch = LineNbrPreviousToMatch;
                ShowResultTokenLinesAsHtml();
                //}
            }
        }

        private void numericUpDownPostLines_ValueChanged(object sender, EventArgs e)
        {
            if (!bIsAssingData2CtrlActive)
            {
                AssignControl2ConfigAndSave();

                // long LineNbrFollowingMatch = Convert.ToInt32(numericUpDownPostLines.Value);
                // if (LocalSearchProperties.ViewSetting.Show.LineNbrFollowingMatch != LineNbrFollowingMatch)
                // {
                //    LocalSearchProperties.ViewSetting.Show.LineNbrFollowingMatch = LineNbrFollowingMatch;
                    ShowResultTokenLinesAsHtml();
                //}
            }
        }

        private void checkBoxDoShowTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (!bIsAssingData2CtrlActive)
            {
                AssignControl2ConfigAndSave();

                // LocalSearchProperties.ViewSetting.bDoShowTitle = checkBoxDoShowTitle.Checked;
                ShowResultTokenLinesAsHtml();
            }
        }

        private void checkBoxDoShowLineNbrs_CheckedChanged(object sender, EventArgs e)
        {
            if (!bIsAssingData2CtrlActive)
            {
                AssignControl2ConfigAndSave();

                //LocalSearchProperties.ViewSetting.bDoShowLineNumbers = checkBoxDoShowLineNbrs.Checked;
                ShowResultTokenLinesAsHtml();
            }
        }

        private void checkBoxDoShowFixedFont_CheckedChanged(object sender, EventArgs e)
        {
            if (!bIsAssingData2CtrlActive)
            {
                AssignControl2ConfigAndSave();

                // LocalSearchProperties.ViewSetting.bDoShowFixedFont = checkBoxDoShowFixedFont.Checked;
                ShowResultTokenLinesAsHtml();
            }
        }

        private void checkBoxDoShowFileNames_CheckedChanged(object sender, EventArgs e)
        {
            if (!bIsAssingData2CtrlActive)
            {
                AssignControl2ConfigAndSave();

                // LocalSearchProperties.ViewSetting.bDoShowFileNames = checkBoxDoShowFileNames.Checked;
                ShowResultTokenLinesAsHtml();
            }
        }

        private void checkBoxDoShowFileContents_CheckedChanged(object sender, EventArgs e)
        {
            if (!bIsAssingData2CtrlActive)
            {
                AssignControl2ConfigAndSave();

                // LocalSearchProperties.ViewSetting.bDoShowFileContents = checkBoxDoShowFileContents.Checked;
                ShowResultTokenLinesAsHtml();
            }
        }

        private void checkBoxDoShowWholeLine_CheckedChanged(object sender, EventArgs e)
        {
            if (!bIsAssingData2CtrlActive)
            {
                AssignControl2ConfigAndSave();

                // LocalSearchProperties.ViewSetting.bDoShowWholeLine = checkBoxDoShowWholeLine.Checked;
                ShowResultTokenLinesAsHtml();
            }
        }


        public void CopyFileNames2Clipboard()
        {
            List<string> FoundPathFileNames = LocalSearchResults.FileNamesAsStringList();

            frmCopyFileNames2ClipBoard CopyFileNames2ClipBoardView = new frmCopyFileNames2ClipBoard(FoundPathFileNames);
            CopyFileNames2ClipBoardView.ShowDialog();
        }

        public void CloseRequest()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(ex);
                ErrCapture.ShowExeption();
            }
        }

        public void DoCancelSearch()
        {
            LocalSearchResults.DoCancelSearch ();
        }

        public void CopySearchId2Clipboard()
        {
            string Id = "Not prepared, therefore nothing changed";
            if (LocalSearchResults != null)
            {
                Id = LocalSearchResults.SearchResultInfo.SearchProperties.IdSearchQueryDistinguishView();
                // MessageBox.Show("Id: '" + Id + "'");
                Clipboard.SetText(Id, TextDataFormat.UnicodeText);
                
                //Id = @"/* 12 */::*.h *.hpp *.c *.cpp::D:\\HeliprogEmulation\\schleif.nt\\";
                //Clipboard.SetText(Id, TextDataFormat.UnicodeText);
                //
                //Id = @"::*.h *.hpp *.c *.cpp::D:\\HeliprogEmulation\\schleif.nt\\";
                //Clipboard.SetText(Id, TextDataFormat.UnicodeText);
                //
                //Id = @"/* 12 */::*.h *.hpp *.c *.cpp::";
                //Clipboard.SetText(Id, TextDataFormat.UnicodeText);
                //

                //Id = @"/* 12 */::*.h *.hpp *.c *.cpp::D:\\HeliprogEmulation\\schleif.nt\\";
                //Clipboard.SetText(Id, TextDataFormat.UnicodeText);
                //
                //Id = @"/* 12 */::*.h *.hpp *.c *.cpp::D:\\HeliprogEmulation\\schleif.nt\\";
                //Clipboard.SetText(Id, TextDataFormat.UnicodeText);
                //
                //Id = @"/* 12 */::*.h *.hpp *.c *.cpp::D:\\HeliprogEmulation\\schleif.nt\\";
                //Clipboard.SetText(Id, TextDataFormat.UnicodeText);


                /*
                Id = "Test";
                //Clipboard.SetText(Id, TextDataFormat.UnicodeText);
                Clipboard.SetText(" dummy ");
                
                Clipboard.SetText(Id, TextDataFormat.UnicodeText);
                */

            }

            MessageBox.Show ("Text in clipboard: \r\n" + Id);
        }

        private void frmSearchResultView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DoCancelSearch();
            }

            if (e.Alt)
            {
                if (e.KeyCode == Keys.R)
                {
                    ExecuteSearchFromForm();
                    ShowResults();
                }
            }
        }
    }
}

