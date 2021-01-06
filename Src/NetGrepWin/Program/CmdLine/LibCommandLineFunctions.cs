using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;

using DebugLog;
using LibStdFileDateTime;
using LibWindowsForms;
using MainGlobal;
using ErrorCapture;
using NetGrep;

namespace CmdLine2005
{
    public partial class clsCommandLine
    {
        //---------------------------------------------------------------------------------
        // Sources for Commands from Commandline
        //---------------------------------------------------------------------------------

        public void DoCmdSearch() // string InPath, string InFileName)
        {
            try
            {
                // ToDO: cmd reset Global.DoCmdGrepProperties

                // ??? Where are the CmdGrepProperties set ? Needs a function for it ? AssignCmdGrepProperties ?

                Global.oDebugLog.WriteUserInfoTitle ("- Do command Find: ");
                Global.DoCmdSearchResults = new clsSearchExecute();


                // AssignGrepPropFromCmdLine(Global.DoCmdGrepProperties);
                Global.oDebugLog.WriteUserInfo(Global.DoCmdGrepProperties.ToString());


                Global.DoCmdSearchResults.ExecuteSearch(Global.DoCmdGrepProperties);                
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

/*        private void AssignGrepPropFromCmdLine(clsSearchProperties clsSearchProperties)
        {
            Global.DoCmdGrepProperties.SearchString = ActCmdObject.InOption("SearchString", Global.DoCmdGrepProperties.SearchString).Value;
            Global.DoCmdGrepProperties.SearchFileTypesAsString = ActCmdObject.InOption("FileSpecification", Global.DoCmdGrepProperties.SearchFileTypesAsString).Value;
            Global.DoCmdGrepProperties.SearchFoldersAsString = ActCmdObject.InOption("Folders", Global.DoCmdGrepProperties.SearchFoldersAsString).Value;

            Global.DoCmdGrepProperties.bUseRegularExpression = ActCmdObject.InOption("RegularExpressions", Global.DoCmdGrepProperties.bUseRegularExpression.ToString()).bValue;
            Global.DoCmdGrepProperties.bWholeWordsOnly = ActCmdObject.InOption("WholeWordsOnly", Global.DoCmdGrepProperties.bWholeWordsOnly.ToString()).bValue;
            Global.DoCmdGrepProperties.bMatchCase = ActCmdObject.InOption("MatchCase", Global.DoCmdGrepProperties.bMatchCase.ToString()).bValue;
            Global.DoCmdGrepProperties.bLinesWithNoMatch = ActCmdObject.InOption("LinesWithNoMatch", Global.DoCmdGrepProperties.bLinesWithNoMatch.ToString()).bValue;
            Global.DoCmdGrepProperties.bStopAfterFirstMatch = ActCmdObject.InOption("StopAfterFirstMatch", Global.DoCmdGrepProperties.bStopAfterFirstMatch.ToString()).bValue;
            Global.DoCmdGrepProperties.bFilesWithNoMatch = ActCmdObject.InOption("FilesWithNoMatch", Global.DoCmdGrepProperties.bFilesWithNoMatch.ToString()).bValue;
            Global.DoCmdGrepProperties.bSearchInFoundFiles = ActCmdObject.InOption("SearchInFoundFiles", Global.DoCmdGrepProperties.bSearchInFoundFiles.ToString()).bValue;
            Global.DoCmdGrepProperties.ReplaceString = ActCmdObject.InOption("ReplaceString", Global.DoCmdGrepProperties.ReplaceString).Value;
            Global.DoCmdGrepProperties.bNeedsCompleteLine = ActCmdObject.InOption("NeedsCompleteLine", Global.DoCmdGrepProperties.bNeedsCompleteLine.ToString()).bValue;
            Global.DoCmdGrepProperties.bUseDelimitedList = ActCmdObject.InOption("UseDelimitedList", Global.DoCmdGrepProperties.bUseDelimitedList.ToString()).bValue;
            Global.DoCmdGrepProperties.bUseFixedWidthList = ActCmdObject.InOption("UseFixedWidthList", Global.DoCmdGrepProperties.bUseFixedWidthList.ToString()).bValue;

            Global.DoCmdGrepProperties.DelimitedSeperationChar = ActCmdObject.InOption("DelimitedSeperationChar", Global.DoCmdGrepProperties.DelimitedSeperationChar).Value;
            Global.DoCmdGrepProperties.DelimitedSearchFieldNbr = ActCmdObject.InOption("DelimitedSearchFieldNbr", Global.DoCmdGrepProperties.DelimitedSearchFieldNbr).Value;
            Global.DoCmdGrepProperties.FixedWidthBeginPosition = ActCmdObject.InOption("FixedWidthBeginPosition", Global.DoCmdGrepProperties.FixedWidthBeginPosition).Value;
            Global.DoCmdGrepProperties.FixedWidthSize = ActCmdObject.InOption("FixedWidthSize", Global.DoCmdGrepProperties.FixedWidthSize).Value;

            // --- File type options -----------------------------------

            Global.DoCmdGrepProperties.bUseFileRegularExpression = ActCmdObject.InOption("UseFileRegularExpression", Global.DoCmdGrepProperties.bUseFileRegularExpression.ToString()).bValue;
            Global.DoCmdGrepProperties.bSearchInsideZipFiles = ActCmdObject.InOption("SearchInsideZipFiles", Global.DoCmdGrepProperties.bSearchInsideZipFiles.ToString()).bValue;
            // public bool bSkipBinaryFiles = ActCmdObject.InOption("bSkipBinaryFiles", Global.DoCmdGrepProperties.bSkipBinaryFiles).bValue;
            // public bool bSkipTextFiles = ActCmdObject.InOption("SkipTextFiles", Global.DoCmdGrepProperties.bSkipBinaryFiles).bValue;
            Global.DoCmdGrepProperties.bSkipFileTypes = ActCmdObject.InOption("SkipFileTypes", Global.DoCmdGrepProperties.bSkipFileTypes.ToString()).bValue;
            Global.DoCmdGrepProperties.SkipFileTypesString = ActCmdObject.InOption("SkipFileTypesString", Global.DoCmdGrepProperties.SkipFileTypesString).Value;

            // --- Folder options -------------------------------------#

            Global.DoCmdGrepProperties.bUseFolderRegularExpression = ActCmdObject.InOption("UseFolderRegularExpression", Global.DoCmdGrepProperties.bUseFolderRegularExpression.ToString()).bValue;
            InOption InOption = ActCmdObject.InOption("DoRecourseFolders", Global.DoCmdGrepProperties.bDoRecourseFolders.ToString());
            bool bTest = InOption.bValue;
            Global.DoCmdGrepProperties.bDoRecourseFolders = ActCmdObject.InOption("DoRecourseFolders", Global.DoCmdGrepProperties.bDoRecourseFolders.ToString()).bValue;

            // --- Replace options ------------------------------------
            Global.DoCmdGrepProperties.bReplaceInSelectedFiles = ActCmdObject.InOption("ReplaceInSelectedFiles", Global.DoCmdGrepProperties.bReplaceInSelectedFiles.ToString()).bValue;
            Global.DoCmdGrepProperties.bConfirmEachReplace = ActCmdObject.InOption("ConfirmEachReplace", Global.DoCmdGrepProperties.bConfirmEachReplace.ToString()).bValue;
            Global.DoCmdGrepProperties.bCreateBackup = ActCmdObject.InOption("CreateBackup", Global.DoCmdGrepProperties.bCreateBackup.ToString()).bValue;
            Global.DoCmdGrepProperties.bReplaceOriginalFile = ActCmdObject.InOption("ReplaceOriginalFile", Global.DoCmdGrepProperties.bReplaceOriginalFile.ToString()).bValue;
            Global.DoCmdGrepProperties.bUseBackupFolder = ActCmdObject.InOption("UseBackupFolder", Global.DoCmdGrepProperties.bUseBackupFolder.ToString()).bValue;
            Global.DoCmdGrepProperties.BackupFolder = ActCmdObject.InOption("BackupFolder", Global.DoCmdGrepProperties.BackupFolder).Value;

            /* ToDO:**:: add parameters for ViewSetting and ShowViewSelection
            public clsSearchViewProperties ViewSetting = new clsSearchViewProperties();
            public clsSearchViewProperties ShowViewSelection = new clsSearchViewProperties();
            * /

            Global.DoCmdGrepProperties.ViewSetting.bDoShowTitle = ActCmdObject.InOption("ViewDoShowTitle", Global.DoCmdGrepProperties.ViewSetting.bDoShowTitle.ToString()).bValue;
            Global.DoCmdGrepProperties.ViewSetting.bDoShowLineNumbers = ActCmdObject.InOption("ViewDoShowLineNumbers", Global.DoCmdGrepProperties.ViewSetting.bDoShowLineNumbers.ToString()).bValue;
            Global.DoCmdGrepProperties.ViewSetting.bDoShowFixedFont = ActCmdObject.InOption("ViewDoShowFixedFont", Global.DoCmdGrepProperties.ViewSetting.bDoShowFixedFont.ToString()).bValue;
            Global.DoCmdGrepProperties.ViewSetting.bDoShowFileNames = ActCmdObject.InOption("ViewDoShowFileNames", Global.DoCmdGrepProperties.ViewSetting.bDoShowFileNames.ToString()).bValue;
            Global.DoCmdGrepProperties.ViewSetting.bDoShowFileContents = ActCmdObject.InOption("ViewDoShowFileContents", Global.DoCmdGrepProperties.ViewSetting.bDoShowFileContents.ToString()).bValue;
            Global.DoCmdGrepProperties.ViewSetting.bDoShowWholeLine = ActCmdObject.InOption("ViewDoShowWholeLine", Global.DoCmdGrepProperties.ViewSetting.bDoShowWholeLine.ToString()).bValue;

            Global.DoCmdGrepProperties.ViewSetting.Show.LineNbrPreviousToMatch = Convert.ToInt32(ActCmdObject.InOption("ViewShowLineNbrPreviousToMatch", Global.DoCmdGrepProperties.ViewSetting.Show.LineNbrPreviousToMatch.ToString()).Value);
            Global.DoCmdGrepProperties.ViewSetting.Show.LineNbrFollowingMatch = Convert.ToInt32(ActCmdObject.InOption("ViewShowLineNbrFollowingMatch", Global.DoCmdGrepProperties.ViewSetting.Show.LineNbrFollowingMatch.ToString()).Value);
            Global.DoCmdGrepProperties.ViewSetting.Keep.LineNbrPreviousToMatch = Convert.ToInt32(ActCmdObject.InOption("ViewKeepLineNbrPreviousToMatch", Global.DoCmdGrepProperties.ViewSetting.Keep.LineNbrPreviousToMatch.ToString()).Value);
            Global.DoCmdGrepProperties.ViewSetting.Keep.LineNbrFollowingMatch = Convert.ToInt32(ActCmdObject.InOption("ViewKeepLineNbrFollowingMatch", Global.DoCmdGrepProperties.ViewSetting.Keep.LineNbrFollowingMatch.ToString()).Value);

            /*
            ShowViewSelection

            public bool bDoShowTitle;
            public bool bDoShowLineNumbers;
            public bool bDoShowFixedFont;
            public bool bDoShowFileNames;
            public bool bDoShowFileContents;
            public bool bDoShowWholeLine;
            Show
            public long LineNbrPreviousToMatch;
            public long LineNbrFollowingMatch;
            Keep
            public long LineNbrPreviousToMatch;
            public long LineNbrFollowingMatch;
            * /
        }
/**/

        public bool DoCmdReplace() // string OutPath, string OutFileName)
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command Replace");
                SorryCmdNotImplementedYet("Replace");
                
                //if (OutFileName.Length == 0)
                //{
                //    string OutTxt = string.Format("Error in DoCmdReadWheelContainerFile: FileName is not given.");
                // 
                //    Global.oDebugLog.MessageBox(OutTxt);
                //    return false;
                //}

                //// Does given filename include path, then use it
                //string TestOutPath = Path.GetDirectoryName(OutFileName);
                //if (TestOutPath.Length > 0)
                //{
                //    OutPath = TestOutPath;
                //    OutFileName = Path.GetFileName(OutFileName);
                //}

                //if (OutPath.Length > 0 && !Directory.Exists(OutPath))
                //{
                //    string OutTxt = string.Format("Error in DoCmdReadWheelContainerFile: Path: {0} does not exist.", OutPath);
                //    Global.oDebugLog.MessageBox(OutTxt););
                //    return false;
                //}

                //string UsePathFileName = Path.Combine(OutPath, OutFileName);
                //return Global.ActWheelContainerFileContent.WriteWheelContainerFile(UsePathFileName);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
            return false;
        }

        public void DoCmdCreateHtmlViewAndShowSearchResult() // string NewAddition)
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command ShowResult");
                
                Application.DoEvents();

                //Form MdiForm = (frmNetGrepWinProgram)clsActiveMainForm.SearchMdiParentForm();

                frmSearchResultView frmCommandSearchResult = 
                    new frmSearchResultView(null,
                    Global.DoCmdGrepProperties, 
                    Global.DoCmdSearchResults);
                frmCommandSearchResult.WindowState = FormWindowState.Maximized;
                //frmCommandSearchResult.Owner = MdiForm.Owner;
                //frmCommandSearchResult.MdiParent = MdiForm.Owner;
                // tto early frmCommandSearchResult.MdiParent = (frmNetGrepWinProgram)MdiForm;

                frmCommandSearchResult.ShowTitleInManuBar();
                // frmCommandSearchResult.LocalSearchProperties = Global.DoCmdGrepProperties;
                // frmCommandSearchResult.LocalSearchResults = Global.DoCmdSearchResults;
                frmCommandSearchResult.ShowResults ();

                Global.CmdLineConfig.frmSearchResultViews.Add(frmCommandSearchResult);

                // frmCommandSearchResult.Show();

                // SorryCmdNotImplementedYet("ShowResult");
                //if (NewAddition.Length < 1)
                //{
                //    string OutTxt = string.Format("Error in DoCmdAddString2AllNames: Option \"/String2Add\" is missing");
                //    Global.oDebugLog.MessageBox(OutTxt);
                //    return;
                //}

                //Global.ActWheelContainerFileContent.AddString2AllNames(NewAddition);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public bool DoCmdWriteSearchResultIntoFile(string OutPath, string OutFileName)
        {
            try
            {
                string FullPath = "";
                string OutTxt = "";

                Global.oDebugLog.WriteUserInfoTitle("- Do command WriteResultIntoFile");

                OutTxt = "DoCmdWriteSearchResultIntoFile Path: " + OutPath + " File:" + OutFileName;
                try
                {
                    FullPath = Path.GetFullPath(OutPath);
                }
                catch
                {
                    FullPath = "Not detectable";
                }
                OutTxt = "DoCommandsFromFile Path: " + OutPath
                    + " File:" + OutFileName
                    + " FullPath:" + FullPath;
                Global.oDebugLog.WriteLine(OutTxt);

                if (OutFileName.Length == 0)
                {
                    OutTxt = string.Format("Error in DoCmdWriteSearchResultIntoFile: FileName is not given.");
                    Global.oDebugLog.MessageBox(OutTxt); 
                    return false;
                }

                // Does given filename include path, then use it
                string TestOutPath = Path.GetDirectoryName(OutFileName);
                if (TestOutPath.Length > 0)
                {
                    OutPath = TestOutPath;
                    OutFileName = Path.GetFileName(OutFileName);
                }

                if (OutPath.Length > 0 && !Directory.Exists(OutPath))
                {
                    OutTxt = string.Format("Error in DoCmdWriteSearchResultIntoFile: Path: {0} does not exist.", OutPath);
                    Global.oDebugLog.MessageBox(OutTxt); 
                    return false;
                }

                string UsePathFileName = Path.Combine(OutPath, OutFileName);
                return Global.DoCmdSearchResults.WriteResultTextFile(UsePathFileName);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return false;
        }

        public bool DoCmdWriteSearchResultIntoFileAsHtml(string OutPath, string OutFileName)
        {
            try
            {
                string FullPath = "";
                string OutTxt = "";

                Global.oDebugLog.WriteUserInfoTitle("- Do command WriteSearchResultIntoFileAsHtml");

                OutTxt = "DoCmdWriteSearchResultIntoFileAsHtml Path: " + OutPath + " File:" + OutFileName;
                try
                {
                    FullPath = Path.GetFullPath(OutPath);
                }
                catch
                {
                    FullPath = "Not detectable";
                }
                OutTxt = "DoCommandsFromFile Path: " + OutPath
                    + " File:" + OutFileName
                    + " FullPath:" + FullPath;
                Global.oDebugLog.WriteLine(OutTxt);

                if (OutFileName.Length == 0)
                {
                    OutTxt = string.Format("Error in DoCmdWriteSearchResultIntoFileAsHtml: FileName is not given.");
                    Global.oDebugLog.MessageBox(OutTxt);
                    return false;
                }

                // Does given filename include path, then use it
                string TestOutPath = Path.GetDirectoryName(OutFileName);
                if (TestOutPath.Length > 0)
                {
                    OutPath = TestOutPath;
                    OutFileName = Path.GetFileName(OutFileName);
                }

                if (OutPath.Length > 0 && !Directory.Exists(OutPath))
                {
                    OutTxt = string.Format("Error in DoCmdWriteSearchResultIntoFileAsHtml: Path: {0} does not exist.", OutPath);
                    Global.oDebugLog.MessageBox(OutTxt);
                    return false;
                }

                string UsePathFileName = Path.Combine(OutPath, OutFileName);
                clsSearchResultTokenLinesAsHtml SearchResultTokenLinesAsHtml =
                    new clsSearchResultTokenLinesAsHtml(//Global.DoCmdSearchResults.SearchResultInfo,
                    Global.DoCmdSearchResults.Files2LineResults); //, Global.DoCmdSearchResults.SearchString);

                // ToDo: write file list as html file write a merge of both as file
                return SearchResultTokenLinesAsHtml.WriteFileFoundFilesWithTokenLinesHtmlDocument(UsePathFileName);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return false;
        }
        
        
        public void DoCmdCreateResultFileListAsHtml()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command CreateResultFileListAsHtml");

                SorryCmdNotImplementedYet("CreateResultFileListAsHtml");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        
        
        public void DoCmdCreateResultTokenLinesAsHtml()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command CreateResultTokenLinesAsHtml");
                SorryCmdNotImplementedYet("CreateResultTokenLinesAsHtml");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        
        
        public void DoCmdCreateResultAsHtml()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command CreateResultAsHtml");
                SorryCmdNotImplementedYet("CreateResultAsHtml");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }


        public void DoCmdWriteSearchResultFileListIntoFileAsHtml(string OutPath, string OutFileName)
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command WriteSearchResultFileListIntoFileAsHtml");
                SorryCmdNotImplementedYet("WriteSearchResultFileListIntoFileAsHtml");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void DoCmdWriteSearchResultTokenLinesIntoFileAsHtml(string OutPath, string OutFileName)
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle("- Do command WriteSearchResultTokenLinesIntoFileAsHtml");
                SorryCmdNotImplementedYet("WriteSearchResultTokenLinesIntoFileAsHtml");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */

        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */

        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */

        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */

       public void SorryCmdNotImplementedYet(string FunctionName)
        {
            try
            {
                string OutTxt = "";
                OutTxt = "Sorry function " + FunctionName + " is not implemented";
                Global.oDebugLog.MessageBox(OutTxt);
                
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

     } // End class
} // End namespace

