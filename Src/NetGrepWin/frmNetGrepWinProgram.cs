using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using AppPaths;
using MainGlobal;
using ErrorCapture;
using CmdLine2005;
//using LogInputKeys;

namespace NetGrep
{
    public partial class frmNetGrepWinProgram : Form
    {
        bool bIsFirstStartOfDoSearch = true;
        bool bIsFirstStartOfDoRepeatLastSearchOnStart = true;

        private List<string> CmdLinePathFileNamesList = new List<string>();

        public frmNetGrepWinProgram()
        {
            InitializeComponent();
            // this.LayoutMdi(MdiLayout.Cascade);

            // InitConfig();
            Global.InitGlobalObjects();
            
            // 
            // ToDo: AssignSearchParameters2ToolStripParameters(); pictures in command line
            
            ExecuteAppCommandsFromCmdLine();            
        }

        public void ExecuteAppCommandsFromCmdLine()
        {
            try
            {
                // ToDo: show debug inside form or show at least the actual comnmand
                frmCommandLine CheckCommands = new frmCommandLine();

                CheckCommands.AppReadAndParseCmdLine();
                if (CheckCommands.AppCommands.Args.Count > 0 || CheckCommands.AppCommands.Opts.Count > 0)
                {
                    Application.DoEvents();

                    CheckCommands.bDoExecuteAppCommands = true;
                    //CheckCommands.Show(this);
                    CheckCommands.ShowDialog(this);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NetGrepWinProgram_Load(object sender, EventArgs e)
        {
            try
            {
                //--------------------------------------------
                // Commandline handling
                //--------------------------------------------

                // User request to close from commandline
                if (Global.CmdLineConfig.bCloseAfterCommandsDone)
                    this.Close();

                // View searches created by command line
                foreach (Form SearchResultViewForm in Global.CmdLineConfig.frmSearchResultViews)
                {
                    frmSearchResultView SearchResultView = (frmSearchResultView)SearchResultViewForm;
                    SearchResultView.AssignWebRowserParentOwner(this);
                    SearchResultView.Show();
                }

                //--------------------------------------------
                // Open last used searches
                //--------------------------------------------


                // Open files on closing  ToDo: :: SearchResult or Search query ? -> extension
                if (   (   Global.Config.bDoLoadLastOpenSearchesOnStart
                        || Global.CmdLineConfig.bDoLoadLastOpenSearchesOnStart) 
                    && !Global.CmdLineConfig.bDontLoadLastOpenSearchesOnStart)
                {
                    // includes LastUsedSearchResults
                    OpenSearchesActiveAtClosing();
                }
                else
                {
                    // Last opened search on closing
                    if (!Global.CmdLineConfig.bDontOpenLastUsedSearch)
                    {
                        OpenLastUsedSearchResults(); // Single search

                        // Todo: include OpenLastUsedSearchQuery(); for config , for save ...
                    }
                }

                // View search results given by filenames on commandline
                if (CmdLinePathFileNamesList.Count > 0)
                {
                    OpenSearchesFromCommandLine();
                }

                int OpenFormsNumber = OpenSearchResultViewForms().Count;
                if (OpenFormsNumber == 1)
                {
                    frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();
                    ActSearch.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        // Last search results (single form)
        private void OpenLastUsedSearchResults()
        {
            clsResultsOfOneSearch ResultsOfOneSearch = new clsResultsOfOneSearch();
            clsResultsOfOneSearch.AssignStandardFileName();
            frmSearchResultView SearchResultView = OpenSearchFromFileName(clsResultsOfOneSearch.UserCfgPathFileName, true);
        }

        private void OpenSearchesActiveAtClosing()
        {
            clsReopenClosedFiles.AssignStandardFileName();
            clsReopenClosedFiles Files2BeReopened = clsReopenClosedFiles.LoadClassFromUserFile();
            if (Files2BeReopened != null)
            {
                if (Files2BeReopened.FileList.Count > 0)
                {
                    foreach (string PathFileName in Files2BeReopened.FileList)
                    {
                        OpenSearchFromFileName(PathFileName, true);
                    }
                }
            }
        }

        private frmSearchResultView OpenSearchFromFileName(string PathFileName) // toDO: check for filename or provide function for each type
        {
            return OpenSearchFromFileName(PathFileName, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PathFileName"></param>
        /// <returns></returns>
        private frmSearchResultView OpenSearchFromFileName(string PathFileName, bool bIgnoreUpdateLastUsed) // toDO: check for filename or provide function for each type
        {
            frmSearchResultView SearchResultView = null;
            try
            {
                if (File.Exists(PathFileName))
                {
                    clsResultsOfOneSearch ResultsOfOneSearch = new clsResultsOfOneSearch();
                    ResultsOfOneSearch = clsResultsOfOneSearch.LoadClassFromFile(PathFileName);

                    if (ResultsOfOneSearch != null)
                    {
                        SearchResultView = OpenSearchFromSearchResult(ResultsOfOneSearch, bIgnoreUpdateLastUsed);
                        // SearchResultView does not already exist 
                        if(SearchResultView != null)
                            // if (!bIgnoreUpdateLastUsed)
                            AssignLastUsedFileName(PathFileName);
                    }
                    else
                    //if (ResultsOfOneSearch == null)
                    {
                        clsSearchProperties SearchQuery = new clsSearchProperties ();

                        SearchQuery = clsSearchProperties.LoadClassFromFile(PathFileName);
                        if (SearchQuery != null)
                        {
                            SearchResultView = OpenSearchFromSearchQuery(SearchQuery);
                            if (!bIgnoreUpdateLastUsed)
                                AssignLastUsedFileName(PathFileName);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return SearchResultView;
        }

        private frmSearchResultView OpenSearchFromSearchResult(clsResultsOfOneSearch SearchResult, bool bIgnoreUpdateLastUsed)
        {
            frmSearchResultView SearchResultView = null;
            try
            {
                // Remove already opened forms with the same search query
                frmSearchResultView QueryAlreadyOpened = FindQueryAlreadyOpened(SearchResult.SearchProperties.IdSearchQueryDistinguishView());
                if (QueryAlreadyOpened != null)
                {
                    // ToDo: Check and ask user for unsaved changes before closing/ then flag (autoOverwrite / or activate already used is needed)
                    if (bIgnoreUpdateLastUsed)
                        return null; // don't load again
                    QueryAlreadyOpened.CloseRequest(); // Reload 
                }

                SearchResultView = new frmSearchResultView(this, SearchResult.SearchProperties,
                    SearchResult.SearchResults);

                //SearchResultView.LocalSearchProperties = SearchResult.SearchProperties;
                //SearchResultView.LocalSearchResults = SearchResult.SearchResults;
                //SearchResultView.AssignConfig2Control();
                //SearchResultView.MdiParent = this;
                //130708: SearchResultView.AssingParentOwner(this);
                SearchResultView.ShowTitleInManuBar();
                SearchResultView.ShowResults();

                //NextSearch.RequestSearchProperties = false;
                if (bIsFirstStartOfDoSearch)
                {
                    bIsFirstStartOfDoSearch = false;
                    // SearchResultView.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    // SearchResultView.WindowState = FormWindowState.Normal;
                }

                SearchResultView.Show();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return SearchResultView;

        }

        private frmSearchResultView OpenSearchFromSearchQuery (clsSearchProperties SearchQuery)
        {
            frmSearchResultView SearchResultView = null;
            try
            {
                // Remove already opened forms with the same search query
                frmSearchResultView QueryAlreadyOpened = FindQueryAlreadyOpened(SearchQuery.IdSearchQueryDistinguishView());
                if (QueryAlreadyOpened != null)
                {
                    // ToDo: Check and ask user for unsaved changes before closing/ then flag (autoOverwrite / or activate already used is needed)
                    QueryAlreadyOpened.CloseRequest(); // Reload 
                }

                SearchResultView = new frmSearchResultView(this, SearchQuery, null);

                // SearchResultView.LocalSearchProperties = SearchQuery;
                // SearchResultView.AssignConfig2Control();
                // SearchResultView.MdiParent = this;
                //130708: SearchResultView.AssingParentOwner(this);
                SearchResultView.ShowResults();

                //NextSearch.RequestSearchProperties = false;
                if (bIsFirstStartOfDoSearch)
                {
                    bIsFirstStartOfDoSearch = false;
                    // SearchResultView.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    // SearchResultView.WindowState = FormWindowState.Normal;
                }

                SearchResultView.Show();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return SearchResultView;
        }

        private frmSearchResultView FindQueryAlreadyOpened(string IdSearchQuery)
        {
            frmSearchResultView FoundForm = null;

            try
            {
                // clsPackageNameParts oLangFileName = new clsPackageNameParts(PathFileName);

                List<frmSearchResultView> ActSearchResultForms = OpenSearchResultViewForms();
                foreach (frmSearchResultView ActSearchResultView in ActSearchResultForms)
                {
                    if (ActSearchResultView.SearchResults != null)
                    {
                        if (ActSearchResultView.SearchResults.SearchResultInfo.SearchProperties.IdSearchQueryDistinguishView() == IdSearchQuery)
                        {
                            FoundForm = ActSearchResultView;
                            break;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return FoundForm;
        }

        /// <summary>
        /// Here all short cuts may be used which are not already "catched" by standard web forms 
        /// in frmSearchResultView
        /// </summary>
        /// <param name="message"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            bool bShift = false;
            bool bAlt = false;
            bool bCtrl = false;

            // 標M_KEYDOWN is 0x100 (256),
            // 標M_KEYUP is 0x101 (257),
            // 標M_CHAR (roughly equivalent to KeyPress) is 0x102 (258),
            // 標M_SYSKEYDOWN is 0x104 (260),
            // 標M_SYSKEYUP is 0x105 (261).

            //Global.LogInputKeys.AddKeyValue("PrP", keys);

            if ((keys & Keys.Control) == Keys.Control)
            {
                toolStripLabelCtrl.Enabled = true;
                bCtrl = true;
            }
            else
                toolStripLabelCtrl.Enabled = false;

            if ((keys & Keys.Alt) == Keys.Alt)
            {
                toolStripLabelCtrl.Enabled = true;
                bAlt = true;
            }
            else
                toolStripLabelCtrl.Enabled = false;

            if ((keys & Keys.Shift) == Keys.Shift)
            {
                toolStripLabelShift.Enabled = true;
                bShift = true;
            }
            else
                toolStripLabelShift.Enabled = false;

            if ((keys & Keys.F6) == Keys.F6)
            {
                toolStripLabelF6.Enabled = true;

            } else
                toolStripLabelF6.Enabled = false;


            /**
            if (toolStripLabelShift.Enabled && toolStripLabelCtrl.Enabled && toolStripLabelF6.Enabled)
                toolStripLabelF6.Enabled = true;
            /**/

            // Control.ModifierKeys Control.ModifierKeys == Keys.Control
            /**
            if ((Keys.Control & !Keys.Shift & !Keys.Alt)

            switch (keys)
            {
                case ((Keys.Control & !Keys.Shift & !Keys.Alt) | Keys.F6):
                    // MessageBox.Show("Ctrl+F6: Exe");
                    ViewNextForm();
                    return true;

                case (Keys.Control | Keys.Tab):
                    // MessageBox.Show("Ctrl+TAb: Exe");
                    ViewNextForm();
                    return true;


                case (Keys.Control | Keys.Shift | Keys.F6):
                    // MessageBox.Show("Ctrl+SHIFT+F6: Exe");
                    ViewPreviousForm();
                    return true;

                case (Keys.Control | Keys.Shift | Keys.Tab):
                    // MessageBox.Show("Ctrl+Shif+TAb: Exe");
                    ViewPreviousForm ();
                    return true;

                case (Keys.Control | Keys.N):
                    // MessageBox.Show ("Ctrl+N: Exe");
                    newSearchToolStripMenuItem_Click(this, new EventArgs());
                    return true;

                case (Keys.Control | Keys.O):
                    // MessageBox.Show("Ctrl+O: Exe");
                    openSearchQueryToolStripMenuItem_Click(this, new EventArgs());
                    return true;

                case (Keys.Control | Keys.F):
                    // MessageBox.Show("Ctrl+F: Exe");
                    searchToolStripMenuItem_Click(this, new EventArgs());
                    return true;

                case (Keys.Control | Keys.S):
                    // MessageBox.Show("Ctrl+S: Exe");
                    saveSearchQueryToolStripMenuItem_Click(this, new EventArgs());
                    return true;

                //-----------------------------    
                case (Keys.Control | Keys.T):
                    // MessageBox.Show("Ctrl+S: Exe");
                    //Global.LogInputKeys.AddKeyValue("PrP", keys);
                    return true;


                case (Keys.Alt | Keys.R):
                    // MessageBox.Show("ALT+R: Exe");
                    restartSearchToolStripMenuItem_Click(this, new EventArgs());
                    return true;
            }
            /**/

            /*----------------------------
            
            ----------------------------*/


            //--- Next window CTRL + F6 -----------------------------


            if ((keys & Keys.F6) == Keys.F6 && bCtrl && !bAlt && !bShift)
            {
                ViewNextForm();
                return true;
            }

            //--- Previous window CTRL + SHIFT + F6 -----------------------------

            if ((keys & Keys.F6) == Keys.F6 && bCtrl && !bAlt && bShift)
            {
                ViewPreviousForm();
                return true;
            }

            //--- Next window CTRL + Tab -----------------------------
            // ToDo: Show selction window of open forms
            if ((keys & Keys.Tab) == Keys.Tab && bCtrl && !bAlt && !bShift)
            {
                ViewNextForm();
                return true;
            }

            //--- Previous window CTRL + SHIFT + Tab -----------------------------
            // ToDo: Show selction window of open forms
            if ((keys & Keys.Tab) == Keys.Tab && bCtrl && !bAlt && bShift)
            {
                ViewPreviousForm();
                return true;
            }

            //--- New search query window CTRL + N -----------------------------

            if ((keys & Keys.N) == Keys.N && bCtrl && !bAlt && bShift)
            {
                newSearchToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }

            //--- Open 'old' search query CTRL + N -----------------------------

            if ((keys & Keys.O) == Keys.O && bCtrl && !bAlt && !bShift)
            {
                openSearchQueryToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }

            //--- Open search CTRL + F -----------------------------

            if ((keys & Keys.F) == Keys.F && bCtrl && !bAlt && !bShift)
            {
                openSearchQueryToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }

            //--- Save search query CTRL + S -----------------------------

            if ((keys & Keys.S) == Keys.S && bCtrl && !bAlt && !bShift)
            {
                saveSearchQueryToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }


            //--- Test something CTRL + T -----------------------------

            if ((keys & Keys.T) == Keys.T && bCtrl && !bAlt && !bShift)
            {
                //openSearchQueryToolStripMenuItem_Click(this, new EventArgs());
                //return true;
            }


            //--- Open search CTRL + R -----------------------------

            if ((keys & Keys.R) == Keys.R && bCtrl && !bAlt && !bShift)
            {
                restartSearchToolStripMenuItem_Click(this, new EventArgs());
                return true;
            }

            /**/
            return base.ProcessCmdKey(ref message, keys);
        }

        public void ViewNextForm()
        {
            // Next Form forward
            this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        public void ViewPreviousForm()
        {
            // Next Form backward
            this.SelectNextControl(this.ActiveControl, false, true, true, true);
        }

        private void InitConfig()
        {
            try
            {
                if (Global.Config == null)
                {
                    Global.Config = clsConfigNetGrep.LoadClassOrCreateUserFile ();
                    //if (Global.Config == null)
                    //{
                    //    Global.Config = new clsConfigNetGrep();
                    //    Global.Config.SaveClass2ProgramFile();
                    //}
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of a form and assign it the currently active form.
                //---------------------------------------------------------------
                // Find active search result window and start search there
                //---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

                if (ActSearch != null)
                {
                    // ActSearch.LocalSearchProperties = clsSearchProperties.LoadClassOrCreateUserFile();
                    ActSearch.RequestSearchProperties = true;

                    ActSearch.RequestPropertiesInputDoSearchAndShow();
                }
                else
                {
                    //// ToDo: yes no cancel ...
                    ////newSearchToolStripMenuItem_Click(sender, e);
                    //string OutTxt = "Actual search form not found. Will open new search";
                    //MessageBox.Show(OutTxt);

                    newSearchToolStripMenuItem_Click(sender, e);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void restartSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------------------------------------------
                // Find active search result window and start search there
                //---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

                // Create an instance of a form and assign it the currently active form.
                if (ActSearch != null)
                {
                    ActSearch.ExecuteSearchFromForm();
                    ActSearch.ShowResults();
                }
                else
                {
                    newSearchToolStripMenuItem_Click(sender, e);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form SearchOptions = new frmOptions();
                SearchOptions.ShowDialog(this);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void newSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                clsSearchProperties LocalSearchProperties = clsSearchProperties.LoadClassOrCreateUserFile();
                LocalSearchProperties.ViewSetting = Global.Config.ViewSetting.Clone();
                LocalSearchProperties.ShowViewSelection = Global.Config.ShowViewSelection.Clone();

                frmSearchResultView NextSearch = new frmSearchResultView(this, LocalSearchProperties, null);

                // NextSearch.LocalSearchProperties = clsSearchProperties.LoadClassOrCreateUserFile();
                // NextSearch.LocalSearchProperties.ViewSetting = Global.Config.ViewSetting.Clone();
                // NextSearch.LocalSearchProperties.ShowViewSelection = Global.Config.ShowViewSelection.Clone();
                // NextSearch.AssignConfig2Control();

                NextSearch.RequestSearchProperties = true;
                if (bIsFirstStartOfDoRepeatLastSearchOnStart)
                {
                    if (Global.Config.bDoRepeatLastSearchOnStart)
                    {
                        NextSearch.RequestSearchProperties = false;
                        NextSearch.bDoRequestRestartSearch = true;
                    }

                    bIsFirstStartOfDoRepeatLastSearchOnStart = false;
                }

                // ToDo : check it out 
                if (this.MdiChildren.Length < 2)
                // if (bIsFirstStartOfDoSearch)
                {
                    bIsFirstStartOfDoSearch = false;
                    NextSearch.WindowState = FormWindowState.Maximized;
                }

                // NextSearch.AssignConfig2Control();
                NextSearch.Show();
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void searchStringListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmOptSearchStringToken OptSearchStringToken = new frmOptSearchStringToken();
                OptSearchStringToken.ShowDialog(this);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void testTextSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTextSearch TestTextSearch = new frmTestTextSearch();
            
            TestTextSearch.Show(this);
        }

        private void testRegularSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTRegularExpressionSearch TestTRegularExpressionSearch =
                new frmTestTRegularExpressionSearch();
            TestTRegularExpressionSearch.Show(this);
        }

        private void closeSearchQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // Find active search result window and close it
            //---------------------------------------------------------------

            frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();
            if (ActSearch != null)
            {
                ActSearch.Close();
            }
        }

        private Form SearchActiveMdiForm()
        {
            //---------------------------------------------------------------
            // Find active search result window and start search there
            //---------------------------------------------------------------

            // Create an instance of a form and assign it the currently active form.
            // Form activeForm = Form.ActiveForm;
            Form activeForm = this.ActiveMdiChild;
            if (activeForm == null)
            {
                FormCollection openForms = Application.OpenForms;
                for (int i = 0; i < openForms.Count && activeForm == null; ++i)
                {
                    Form openForm = openForms[i];
                    if (openForm.IsMdiContainer)
                    {
                        activeForm = openForm.ActiveMdiChild;
                    }
                }
            }

            return activeForm;
        }

        private frmSearchResultView SearchActiveMdiFormOfTypeDoSearch()
        {
            Form activeForm = SearchActiveMdiForm();

            if (activeForm is frmSearchResultView)
                return (frmSearchResultView) activeForm;
            else
                return null;
        }

        public void saveSearchQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------------------------------------------
                // Find active search result window and start search there
                //---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

                if (ActSearch != null)
                {
                    SaveFileDialog SaveSearchPropertiesDialog = new SaveFileDialog();
                    if (Global.Config.LastUsedSearchPropertyFileName.Length > 0)
                        SaveSearchPropertiesDialog.InitialDirectory = Global.Config.LastUsedSearchPropertyFileName;
                    SaveSearchPropertiesDialog.Filter = "Search property files (*.prp)|*.prp|All files (*.*)|*.*";
                    SaveSearchPropertiesDialog.FilterIndex = 1;

                    if (SaveSearchPropertiesDialog.ShowDialog() == DialogResult.OK)
                    {
                        string FileName = SaveSearchPropertiesDialog.FileName;
                        ActSearch.SearchProperties.SaveClass2File(FileName);

                        AssignLastUsedFileName(FileName);

                        Global.Config.LastUsedSearchPropertyFileName = FileName;
                        Global.Config.SaveClass2UserFile();
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void openSearchQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog LoadSearchPropertiesDialog = new OpenFileDialog();
                if (Global.Config.LastUsedSearchPropertyFileName.Length > 0) 
                    LoadSearchPropertiesDialog.InitialDirectory = Global.Config.LastUsedSearchPropertyFileName;
                LoadSearchPropertiesDialog.Filter = "Search property files (*.prp)|*.prp|All files (*.*)|*.*";
                LoadSearchPropertiesDialog.FilterIndex = 1;

                if (LoadSearchPropertiesDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = LoadSearchPropertiesDialog.FileName;
                    OpenSearchFromFileName(FileName);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void saveResultAsTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------------------------------------------
                //
                //---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

                if (ActSearch != null)
                {
                    SaveFileDialog SaveSearchPropertiesDialog = new SaveFileDialog();
                    if (Global.Config.LastUsedSearchResultFileName.Length > 0)
                        SaveSearchPropertiesDialog.InitialDirectory = Global.Config.LastUsedSearchResultFileName;
                    SaveSearchPropertiesDialog.Filter = "Search result text info files (*.txt)|*.txt|All files (*.*)|*.*";
                    SaveSearchPropertiesDialog.FilterIndex = 1;

                    if (SaveSearchPropertiesDialog.ShowDialog() == DialogResult.OK)
                    {
                        string FileName = SaveSearchPropertiesDialog.FileName;
                        ActSearch.SearchResults.WriteResultTextFile(FileName);

                        Global.Config.LastUsedSearchResultFileName = FileName;
                        Global.Config.SaveClass2UserFile();
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void saveSearchResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ////---------------------------------------------------------------
                //// 
                ////---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

                if (ActSearch != null)
                {
                    SaveFileDialog SaveSearchPropertiesDialog = new SaveFileDialog();
                    if (Global.Config.LastUsedSearchResultFileName.Length > 0) 
                        SaveSearchPropertiesDialog.InitialDirectory = Global.Config.LastUsedSearchResultFileName;
                    SaveSearchPropertiesDialog.Filter = "Search result data files (*.res)|*.res|All files (*.*)|*.*";
                    SaveSearchPropertiesDialog.FilterIndex = 1;

                    if (SaveSearchPropertiesDialog.ShowDialog() == DialogResult.OK)
                    {
                        clsResultsOfOneSearch ResultsOfOneSearch = new clsResultsOfOneSearch();
              
                        string FileName = SaveSearchPropertiesDialog.FileName;
                        //ActSearch.SearchResults.WriteResultTextFile(FileName);
                        ResultsOfOneSearch.SearchProperties = ActSearch.SearchProperties;
                        ResultsOfOneSearch.SearchResults = ActSearch.SearchResults;

                        ResultsOfOneSearch.SaveClass2File(FileName);

                        Global.Config.LastUsedSearchResultFileName = FileName;
                        Global.Config.SaveClass2UserFile();

                        AssignLastUsedFileName(FileName);
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void openSearchResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog LoadSearchPropertiesDialog = new OpenFileDialog();
                if (Global.Config.LastUsedSearchResultFileName.Length > 0) 
                    LoadSearchPropertiesDialog.InitialDirectory = Global.Config.LastUsedSearchResultFileName;
                LoadSearchPropertiesDialog.Filter = "Search result data files (*.res)|*.res|All files (*.*)|*.*";
                LoadSearchPropertiesDialog.FilterIndex = 1;

                if (LoadSearchPropertiesDialog.ShowDialog() == DialogResult.OK)
                {
                    string FileName = LoadSearchPropertiesDialog.FileName;
                    OpenSearchFromFileName(FileName);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of a form and assign it the currently active form.
                //---------------------------------------------------------------
                // Find active search result window and start search there
                //---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

                if (ActSearch != null)
                {
                    //ActSearch.LocalSearchProperties = clsSearchProperties.LoadClassOrCreateUserFile();
                    ActSearch.RequestSearchProperties = false;
                    ActSearch.RequestReplaceProperties = true;


                    ActSearch.RequestReplacePropertiesInputDoReplace();
                }
                else
                {
                    // ToDo: yes no cancel ...
                    //newSearchToolStripMenuItem_Click(sender, e);
                    string OutTxt = "Actual search form not found. Will open new search";
                    MessageBox.Show(OutTxt);
                    newSearchToolStripMenuItem_Click(sender, e);
                }

            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void searchInFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of a form and assign it the currently active form.
                //---------------------------------------------------------------
                // Find active search result window and start search there
                //---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

                if (ActSearch != null)
                {
                    //ActSearch.LocalSearchProperties = clsSearchProperties.LoadClassOrCreateUserFile();
                    ActSearch.SearchProperties.bSearchInFoundFiles = true;
                    ActSearch.RequestSearchProperties = true;

                    ActSearch.RequestPropertiesInputDoSearchAndShow();
                }
                else
                {
                    // ToDo: yes no cancel ...
                    //newSearchToolStripMenuItem_Click(sender, e);
                    string OutTxt = "Actual search form not found. Will open new search";
                    MessageBox.Show(OutTxt);

                    newSearchToolStripMenuItem_Click(sender, e);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void saveResultAsFileListHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------------------------------------------
                // Find active search result window and start search there
                //---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();
                
                if (ActSearch != null)
                {
                    // try ... 
                    SaveFileDialog SaveSearchPropertiesDialog = new SaveFileDialog();
                    if (Global.Config.LastUsedSearchResultHtmlFileName.Length > 0) 
                        SaveSearchPropertiesDialog.InitialDirectory = Global.Config.LastUsedSearchResultHtmlFileName;
                    SaveSearchPropertiesDialog.FileName = "SearchResultFileListAsHtml.htm";
                    SaveSearchPropertiesDialog.Filter = "Search file list Html files (*.htm)|*.htm|All files (*.*)|*.*";
                    SaveSearchPropertiesDialog.FilterIndex = 1;

                    if (SaveSearchPropertiesDialog.ShowDialog() == DialogResult.OK)
                    {
                        string FileName = SaveSearchPropertiesDialog.FileName;
                        
                        ActSearch.WriteResultFileListHtmlFile(FileName);

                        Global.Config.LastUsedSearchResultHtmlFileName = FileName;
                        Global.Config.SaveClass2UserFile();
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void saveResultAstokenLinesHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------------------------------------------
                // Find active search result window and start search there
                //---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

                if (ActSearch != null)
                {
                    // try ... 
                    SaveFileDialog SaveSearchPropertiesDialog = new SaveFileDialog();
                    if (Global.Config.LastUsedSearchResultHtmlFileName.Length > 0)
                        SaveSearchPropertiesDialog.InitialDirectory = Global.Config.LastUsedSearchResultHtmlFileName;
                    SaveSearchPropertiesDialog.FileName = "SearchResultTokenLinesAsHtml.htm";
                    SaveSearchPropertiesDialog.Filter = "Search token lines Html files (*.htm)|*.htm|All files (*.*)|*.*";
                    SaveSearchPropertiesDialog.FilterIndex = 1;

                    if (SaveSearchPropertiesDialog.ShowDialog() == DialogResult.OK)
                    {
                        string FileName = SaveSearchPropertiesDialog.FileName;

                        ActSearch.WriteResultTokenLinesHtmlFile (FileName);

                        Global.Config.LastUsedSearchResultHtmlFileName = FileName;
                        Global.Config.SaveClass2UserFile();
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void showResultInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox AboutBox = new frmAboutBox();
            AboutBox.ShowDialog();
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        private void pathInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsedPathView UsedPathView = new frmUsedPathView();
            UsedPathView.Show(this);
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //// tell windows about it
            //frmNetGrepWinProgram MdiForm = null;
            //MdiForm = (frmNetGrepWinProgram)clsActiveMainForm.SearchMdiParentForm();

            //MdiForm.ActivateMdiChild(null);
            //MdiForm.ActivateMdiChild(this); 
            if (this.ActiveMdiChild != null) 
            { 
                Form activeChild = this.ActiveMdiChild; 
                ActivateMdiChild(null); 
                ActivateMdiChild(activeChild); 
            }         
        }

        private void copyNames2ClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

            if (ActSearch != null)
            {
                ActSearch.CopyFileNames2Clipboard();
            }
        }

        private void OpenSearchesFromCommandLine()
        {
            try
            {
                foreach (string PathFileName in CmdLinePathFileNamesList)
                {
                    // OpenPackageFromFileName(PathFileName);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void frmNetGrepWinProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            //--- Save actual result for open on start --------------------------
            // Global.Config.LastUsedFileName
            frmSearchResultView LastSearch = SearchActiveMdiFormOfTypeDoSearch();

            if (LastSearch != null)
            {
                clsResultsOfOneSearch.AssignStandardFileName();
                clsResultsOfOneSearch ResultsOfOneSearch = new clsResultsOfOneSearch();

                ResultsOfOneSearch.AssignStandardValues ();

                ResultsOfOneSearch.SearchProperties = LastSearch.SearchProperties;
                ResultsOfOneSearch.SearchResults = LastSearch.SearchResults;

                ResultsOfOneSearch.SaveClass2UserFile ();
            }

            /*--- Write opened searches to reopen on start of package ---------------------*/
            clsReopenClosedFiles.AssignStandardFileName();
            clsReopenClosedFiles Files2BeReopened = new clsReopenClosedFiles();

            int Idx = 0;
            List<frmSearchResultView> OpenSearchResultForms = OpenSearchResultViewForms();

            //// No form open
            //if (OpenSearchResultForms.Count == 0)
            //{
            //    clsResultsOfOneSearch.UserCfgPathFileName = "";
            //    Global.Config.SaveClass2UserFile();
            //}
                
            foreach (frmSearchResultView ActSearch in OpenSearchResultForms)
            {
                //// Load only once
                //if (!Global.Config.bDoStartWithLastUsedPackage)
                {

                    clsResultsOfOneSearch ResultsOfOneSearch = new clsResultsOfOneSearch();
                    ResultsOfOneSearch.AssignStandardValues();

                    string PathFileName = clsAppPaths.UserCfgPathName.PathName + "OpenSearchResult_" + Idx + ".res";
                    //ActSearch.SearchResults.WriteResultTextFile(FileName);
                    ResultsOfOneSearch.SearchProperties = ActSearch.SearchProperties;
                    ResultsOfOneSearch.SearchResults = ActSearch.SearchResults;

                    ResultsOfOneSearch.SaveClass2File(PathFileName);

                    Files2BeReopened.FileList.Add(PathFileName);

                    Idx++;
                }
                //else
                //{
                //    if (Global.Config.LastUsedFileName != ActLangPackView.PathFileName)
                //    {
                //        Files2BeReopened.FileList.Add(ActLangPackView.PathFileName);
                //    }
                //}
            }

            //if (Files2BeReopened.FileList.Count > 0)
            //{
            Files2BeReopened.SaveClass2UserFile();
            //}
            /**/
        }

        private List<frmSearchResultView> OpenSearchResultViewForms()
        {
            List<frmSearchResultView> ActOpenSearchResultViewForms = new List<frmSearchResultView>();
            FormCollection openForms = Application.OpenForms;
            foreach (Form LocalForm in openForms)
            {
                if (LocalForm is frmSearchResultView)
                    ActOpenSearchResultViewForms.Add((frmSearchResultView)LocalForm);
            }

            return ActOpenSearchResultViewForms;
        }

        private void NetGrepWinProgram_Move(object sender, EventArgs e)
        {
            // InitConfig();
        }

        private void NetGrepWinProgram_Shown(object sender, EventArgs e)
        // private void NetGrepWinPrg_Shown(object sender, EventArgs e)
        {
            try
            {
                // first search
                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();
                if (ActSearch != null)
                {
                    ActSearch.RequestPropertiesInputDoSearchAndShow ();
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void AssignLastUsedFileName(string PathFileName)
        {
            Global.UserLastOpenedFilesList.AddUsedToken(PathFileName);
            Global.UserLastOpenedFilesList.SaveClass2UserFile();
        }

        private void lastUsedSearchFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lastUsedSearchFilesToolStripMenuItem.DropDownItems.Clear();
                
                foreach (string PathFileName in Global.UserLastOpenedFilesList.TokenList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = PathFileName;
                    item.Click += new EventHandler(lastUsedSearchFilesToolStripMenuItemDropDownItem_Click);
                    lastUsedSearchFilesToolStripMenuItem.DropDownItems.Add(item);
                }                
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void lastUsedSearchFilesToolStripMenuItemDropDownItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem Item;

                // ToDO: fill out: fileToolStripMenuItem_Click for last used searches
                Item = (ToolStripMenuItem)sender;
                string FileName = Item.Text;
                OpenSearchFromFileName(FileName);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void lastUsedSearchQueriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lastUsedSearchQueriesToolStripMenuItem.DropDownItems.Clear();

                foreach (clsSearchProperties SearchQuery in Global.LastUsedSearchQueries.TokenList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = SearchQuery.IdSearchQueryDistinguishView ();
                    item.Click += new EventHandler(lastUsedSearchQueriesToolStripMenuItemDropDownItem_Click);
                    lastUsedSearchQueriesToolStripMenuItem.DropDownItems.Add(item);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void lastUsedSearchQueriesToolStripMenuItemDropDownItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item;
                int Idx = 0;
                item = (ToolStripMenuItem)sender;

                if (item != null)     
                {         
                    Idx = ((ToolStripMenuItem)item.OwnerItem).DropDownItems.IndexOf(item);     
                }
                if (Idx < Global.LastUsedSearchQueries.TokenList.Count)
                {
                    clsSearchProperties SearchQuery = Global.LastUsedSearchQueries.TokenList[Idx];
                    OpenSearchFromSearchQuery(SearchQuery);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastUsedSearchFilesToolStripMenuItem_Click(sender, e);
            lastUsedSearchQueriesToolStripMenuItem_Click(sender, e);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // List<frmSearchResultView> ActOpenSearchResultViewForms = new List<frmSearchResultView>();
            FormCollection openForms = Application.OpenForms;
            foreach (Form LocalForm in openForms)
            {
                if (LocalForm is frmSearchResultView)
                    LocalForm.Close();
            }
        }

        private void closeAllButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // Find active search result window and close it
            //---------------------------------------------------------------

            frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();
            if (ActSearch != null)
            {
                FormCollection openForms = Application.OpenForms;
                foreach (Form LocalForm in openForms)
                {
                    if (LocalForm is frmSearchResultView)
                    {
                        if (LocalForm != ActSearch)
                            LocalForm.Close();
                    }
                }
            }
        }

        private void cancelSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------------------------------------------
                // Find active search result window and start search there
                //---------------------------------------------------------------

                frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();
                ActSearch.DoCancelSearch();

            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        private void copySearchId2ClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchResultView ActSearch = SearchActiveMdiFormOfTypeDoSearch();

            if (ActSearch != null)
            {
                ActSearch.CopySearchId2Clipboard();
            }
        }

        private void feedBackOnErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void regularSearchExpressionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegexExpressionsView RegexExpressionsView = new frmRegexExpressionsView();
            RegexExpressionsView.Show();
        }

        private void printResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // todo: implement 
        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // todo: implement 
        }

    }
}

