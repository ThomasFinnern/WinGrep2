using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MainGlobal;
using ErrorCapture;
using HtmlFromToken;

namespace NetGrep
{
    [Serializable]
    public class clsSearchExecute : clsSearchResults
    {

        //public clsSearchExecute()
        //{ 
        //}


        public override void ExecuteSearch(clsSearchProperties GrepProperties)
        {
            try
            {
                //--------------------------------------------------------------------------------------
                // Collect all files defined by request (folder and file specification)
                //--------------------------------------------------------------------------------------

                SetTitle("Collect files from request");
                AssignFolderAndFilesFromRequest(GrepProperties);

                //------------------------------------------------------------------------
                SearchResultInfo = new clsSearchResultInfo(GrepProperties);

                //--------------------------------------------------------------------------------------
                // Prepare regular expression search string
                //--------------------------------------------------------------------------------------

                Regex regExSearch = clsSearchRegularExpression.CreateSearchRegEx(GrepProperties);

                if (regExSearch == null)
                    return;

                //--------------------------------------------------------------------------------------
                // Go through every file
                //--------------------------------------------------------------------------------------

                SetTitle("Search for and inside files");

                // Count time for searching 
                SetTime("-%-");

                Stopwatch ExecTime = new Stopwatch();
                ExecTime.Start();

                // 
                foreach (string FileName in SearchFilesInFoldersIEnumerator.CollectFiles())
                {
                    if (bCancelSearch)
                        break;

                    SetInfo(FileName);

                    UpdateFolderCount(SearchFilesInFoldersIEnumerator.FolderNbr);
                    UpdateFileCount(SearchFilesInFoldersIEnumerator.FileNbr);

                    SearchResultInfo.FileSearchedNbr += 1;

                    clsFileResults FileResult = null;

                    //--------------------------------------------------------------------------------------
                    // Go through every line
                    //--------------------------------------------------------------------------------------

                    // Todo: check for encoding 

                    //using System.Globalization;
                    //CultureInfo current  = CultureInfo.CurrentCulture;
                    //CultureInfo germany = new CultureInfo("de-DE");
                    //CultureInfo russian = new CultureInfo("ru-RU");

                    bool bMatchFound = clsSearchInLines.DoSearchInLines(
                        FileName,
                        regExSearch, GrepProperties,
                        FileName, ref FileResult);

                    if (GrepProperties.bFilesWithNoMatch) // && !bMatchFound)
                    {
                        if (!bMatchFound)
                        FileResult = new clsFileResults(FileName);
                        else
                            FileResult = null;
                    }

                    if (FileResult != null)
                        Files2LineResults.Add(FileResult);
                }

                ExecTime.Stop();
                string TimeTxt = "";
                if (ExecTime.Elapsed.Hours > 0)
                {
                    TimeTxt = string.Format("h{0}:{1}.{2:2}.{3:000}",
                        //Math.Floor(ExecTime.Elapsed.TotalHours),
                        ExecTime.Elapsed.TotalHours,
                        ExecTime.Elapsed.Minutes,
                        ExecTime.Elapsed.Seconds,
                        ExecTime.Elapsed.Milliseconds);
                }
                else
                {
                    if (ExecTime.Elapsed.Hours > 0)
                    {
                        TimeTxt = string.Format("m{0}.{1:2}.{2:000}",
                            Math.Floor(ExecTime.Elapsed.TotalMinutes),
                            ExecTime.Elapsed.Seconds,
                            ExecTime.Elapsed.Milliseconds);
                    }
                    else
                    {
                        TimeTxt = string.Format("s{0}.{1:000}",
                            ExecTime.Elapsed.Seconds,
                            ExecTime.Elapsed.Milliseconds);
                    }
                }
                SetTime(TimeTxt);

                // SetTime(ExecTime.Elapsed.ToString("mm\\:ss\\.ff"));

                UpdateFolderCount(SearchFilesInFoldersIEnumerator.FolderNbr);
                UpdateFileCount(SearchFilesInFoldersIEnumerator.FileNbr);

                SetTitle("Searching done");

                SearchResultInfo.TokenMatchedNbr = this.MatchedNbr;
                SearchResultInfo.FilesMatchedNbr = Files2LineResults.Count;
                SearchResultInfo.FilesSkippedNbr = 0;
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void DoCancelSearch()
        {
            SearchFilesInFoldersIEnumerator.bCancelSearch = true;        
        }


        public override void ExecuteReplace(clsSearchProperties GrepProperties)
        {
            try
            {
                clsReplaceInFiles ReplaceInFiles = new clsReplaceInFiles();
                ReplaceInFiles.DoReplaceInFiles(GrepProperties, Files2LineResults);
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
    }
}
