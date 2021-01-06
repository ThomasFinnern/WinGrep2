using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;

using DebugLog;
using LibStdFileDateTime;
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

        public void DoCmdFind() // string InPath, string InFileName)
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command Find: ");
                //Global.DoCmdSearchResults = new clsSearchExecute();
                //Global.DoCmdSearchResults.ExecuteSearch(Global.DoCmdGrepProperties);                
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

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

        public void DoCmdShowResult() // string NewAddition)
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command ShowResult");
                
                Application.DoEvents();

                Form MdiForm = null;
                foreach (Form OpenForm in Application.OpenForms)
                {
                    //if (OpenForm.IsMdiContainer)
                    {
                        MdiForm = OpenForm;
                        // frmCommandSearchResult.MdiParent = OpenForm;
                        // frmCommandSearchResult.Parent = OpenForm.MdiParent;
                        break;
                    }
                }

                ////frmSearchResultView frmCommandSearchResult = new frmSearchResultView((frmNetGrepWinProgram ) MdiForm,
                ////    Global.DoCmdGrepProperties, Global.DoCmdSearchResults);
                ////frmCommandSearchResult.WindowState = FormWindowState.Maximized;
                //frmCommandSearchResult.Owner = MdiForm.Owner;
                //frmCommandSearchResult.MdiParent = MdiForm.Owner;

                // frmCommandSearchResult.LocalSearchProperties = Global.DoCmdGrepProperties;
                // frmCommandSearchResult.LocalSearchResults = Global.DoCmdSearchResults;
                //frmCommandSearchResult.ShowResults ();

                //frmCommandSearchResult.Show();

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

        //public bool DoCmdWriteResultIntoFile(string OutPath, string OutFileName)
        //{
        //    try
        //    {
        //        Global.oDebugLog.WriteUserInfoTitle ("- Do command WriteResultIntoFile");

        //        if (OutFileName.Length == 0)
        //        {
        //            string OutTxt = string.Format("Error in DoCmdWriteResultIntoFile: FileName is not given.");
        //            Global.oDebugLog.MessageBox(OutTxt); 
        //            return false;
        //        }

        //        // Does given filename include path, then use it
        //        string TestOutPath = Path.GetDirectoryName(OutFileName);
        //        if (TestOutPath.Length > 0)
        //        {
        //            OutPath = TestOutPath;
        //            OutFileName = Path.GetFileName(OutFileName);
        //        }

        //        if (OutPath.Length > 0 && !Directory.Exists(OutPath))
        //        {
        //            string OutTxt = string.Format("Error in DoCmdWriteResultIntoFile: Path: {0} does not exist.", OutPath);
        //            Global.oDebugLog.MessageBox(OutTxt); 
        //            return false;
        //        }

        //        string UsePathFileName = Path.Combine(OutPath, OutFileName);
        //        return Global.DoCmdSearchResults.WriteResultTextFile(UsePathFileName);
        //    }
        //    catch (Exception Ex)
        //    {
        //        clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
        //        ErrCapture.ShowExeption();
        //    }

        //    return false;
        //}

        //public bool DoCmdWriteResultIntoFileAsHtml(string OutPath, string OutFileName)
        //{
        //    try
        //    {
        //        Global.oDebugLog.WriteUserInfoTitle ("- Do command WriteResultIntoFileAsHtml");

        //        if (OutFileName.Length == 0)
        //        {
        //            string OutTxt = string.Format("Error in DoCmdWriteResultIntoFile: FileName is not given.");
        //            Global.oDebugLog.MessageBox(OutTxt);
        //            return false;
        //        }

        //        // Does given filename include path, then use it
        //        string TestOutPath = Path.GetDirectoryName(OutFileName);
        //        if (TestOutPath.Length > 0)
        //        {
        //            OutPath = TestOutPath;
        //            OutFileName = Path.GetFileName(OutFileName);
        //        }

        //        if (OutPath.Length > 0 && !Directory.Exists(OutPath))
        //        {
        //            string OutTxt = string.Format("Error in DoCmdWriteResultIntoFile: Path: {0} does not exist.", OutPath);
        //            Global.oDebugLog.MessageBox(OutTxt);
        //            return false;
        //        }

        //        string UsePathFileName = Path.Combine(OutPath, OutFileName);
        //        clsSearchResultTokenLinesAsHtml SearchResultTokenLinesAsHtml =
        //            new clsSearchResultTokenLinesAsHtml(//Global.DoCmdSearchResults.SearchResultInfo,
        //            Global.DoCmdSearchResults.Files2LineResults); //, Global.DoCmdSearchResults.SearchString);

        //        // ToDo: write file list as html file write a merge of both as file
        //        return SearchResultTokenLinesAsHtml.WriteFileFoundFilesWithTokenLinesHtmlDocument(UsePathFileName);
        //    }
        //    catch (Exception Ex)
        //    {
        //        clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
        //        ErrCapture.ShowExeption();
        //    }

        //    return false;
        //}
        
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

