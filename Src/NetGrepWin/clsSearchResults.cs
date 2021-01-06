using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.IO;
using System.Windows.Forms;
using MainGlobal;
using ErrorCapture;
using HtmlFromToken;

namespace NetGrep
{
    [Serializable]
    public abstract class clsSearchResults
    {
        // IEnumerable<string> ieFiles = null;
        protected clsSearchFilesInFoldersIEnumerator SearchFilesInFoldersIEnumerator = 
            new clsSearchFilesInFoldersIEnumerator();

        // Dictionary<string, clsFileResults> Files2LineResult;
        public List<clsFileResults> Files2LineResults = new List<clsFileResults> ();
        public long MatchedNbr
        {
            get
            {
                long ActMatchNbr = 0;
                foreach (clsFileResults FileResults in Files2LineResults)
                {
                    ActMatchNbr += FileResults.MatchedNbr;
                }
                return ActMatchNbr;
            }
        }

        protected string SearchString;
        public clsSearchResultInfo SearchResultInfo = null;

        public abstract void ExecuteSearch(clsSearchProperties GrepProperties);
        public abstract void ExecuteReplace(clsSearchProperties GrepProperties);

        public event EventHandler<clsEventArgsWithOneMessage> OnSetTitle;
        public event EventHandler<clsEventArgsWithOneMessage> OnSetInfo;
        public event EventHandler<clsEventArgsWithOneMessage> OnUpdateFolderCount;
        public event EventHandler<clsEventArgsWithOneMessage> OnUpdateFileCount;
        public event EventHandler<clsEventArgsWithOneMessage> OnUpdateTime;

        //public event EventHandler<clsEventArgsWithOneMessage> OnSetMaxFileNumber;
        //public event EventHandler<clsEventArgsWithOneMessage> OnSetActFileNumber;

        //--------------------------------------------------------------------------------------
        // Collect all files defined by request (folder and file specification)
        //--------------------------------------------------------------------------------------

        protected void AssignFolderAndFilesFromRequest(clsSearchProperties GrepProperties)
        {
            if (!GrepProperties.bSearchInFoundFiles || Files2LineResults.Count < 1)
            {
                //--------------------------------------------------------------------------------------
                // Collect all possible files
                //--------------------------------------------------------------------------------------

                SearchFilesInFoldersIEnumerator.FileTypes = GrepProperties.FileSpecificationAsList();
                SearchFilesInFoldersIEnumerator.SearchFolders = GrepProperties.SearchFolders;
                SearchFilesInFoldersIEnumerator.bDoRecourseFolders = GrepProperties.bDoRecourseFolders;
            }
            else
            {
                //--------------------------------------------------------------------------------------
                // Search in found Files from last search
                //--------------------------------------------------------------------------------------
                List<string> UseFoundFiles = new List<string>();
                foreach (clsFileResults Files2LineResult in Files2LineResults)
                {
                    UseFoundFiles.Add (Files2LineResult.FileName);
                }
                SearchFilesInFoldersIEnumerator.UseFileList = UseFoundFiles;
                SearchFilesInFoldersIEnumerator.bDoRecourseFolders = GrepProperties.bDoRecourseFolders;

                Files2LineResults = new List<clsFileResults>();
            }
        }

        public bool WriteResultTextFile(string FileName)
        {
            if (File.Exists(FileName))
            {
                Global.oDebugLog.DPrint("File will be overwritten");
                //string OutTxt = string.Format("Error in DoCmdReadNcsFile: File: {0} does not exist.", UsePathFileName);
                //Global.oDebugLog.MessageBox(OutTxt); 
                //return;
            }

            //----------------------------------------------------------------------------
            // Write
            //----------------------------------------------------------------------------

            FileStream OutHtmlFile = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            if ((OutHtmlFile != null))
            {
                string OutTxt = this.ToStringLines();
                StreamWriter TxtWriter = new StreamWriter(OutHtmlFile, System.Text.Encoding.Default);

                TxtWriter.Write(OutTxt);
                TxtWriter.Flush();   // Puffer => Disk
                TxtWriter.Close();

                OutHtmlFile.Close();
            }

            return true;
        }

        public string ToStringLines()
        {
            string OutTxt = "";

            if (Files2LineResults.Count < 1)
            {
                OutTxt = OutTxt + "Found no matches for '" + SearchString + "'\r\n";
            }
            else
            {
                OutTxt = OutTxt + ToStringFileList ();

                OutTxt = OutTxt + ToStringFileListWithLines();
                OutTxt = OutTxt + "==============================================================" + "\r\n";
                OutTxt = OutTxt + "Filecontents (B) :" + "\r\n";
                foreach (clsFileResults Files2LineResult in Files2LineResults)
                {
                    OutTxt = OutTxt + "------------------------------------------------------------------" + "\r\n";
                    OutTxt = OutTxt + Files2LineResult.ToStringLines () + "\r\n";
                }

                OutTxt = OutTxt + "==============================================================" + "\r\n";

            }
            return (OutTxt);
        }

        /// <summary>
        /// Finds next filename in List
        /// </summary>
        /// <param name="ActFile"></param>
        /// <returns>Next filename. Started with last item it returns "".
        /// Started with "" it returns the first item. Therefore a Round Robin is possible. 
        /// Just use returned value for next start and display an error as content when "" is returned</returns>
        public string GetNextFile(string ActFile)
        {
            string NextFile = "";
            int Idx;
            bool bIsFound = false;
            for (Idx = 0; Idx < Files2LineResults.Count; Idx++)
            {
                if (Files2LineResults[Idx].FileName == ActFile)
                {
                    Idx++;
                    bIsFound = true;
                    if (Idx < Files2LineResults.Count)
                        NextFile = Files2LineResults[Idx].FileName;
                    break;
                }
            }

            // start with item 0 again
            if (!bIsFound)
            {
                Idx = 0;
                if (Idx < Files2LineResults.Count)
                    NextFile = Files2LineResults[Idx].FileName;
            }

            return NextFile;
        }

        public clsFileResults GetFileResultsFromFileName(string ActPathFileName)
        {
            clsFileResults FileResults = new clsFileResults(""); // NameNotfound");

            // bool bIsFound = false;
            //for (Idx = 0; Idx < Files2LineResults.Count; Idx++)
            foreach (clsFileResults LocalFileResult in Files2LineResults)
            {
                if (LocalFileResult.FileName == ActPathFileName)
                {
                    FileResults = LocalFileResult;
                    break;
                }
            }

            return FileResults;
        }
        
            
            
        /// <summary>
        /// Finds previous filename in List
        /// 
        /// </summary>
        /// <param name="ActFile"></param>
        /// <returns>Previous filename. Started with first item it returns "".
        /// Started with "" it returns the last item. Therefore a round robin is possible. 
        /// Just use returned value for next start and display an error as content when "" is returned</returns>
        public string GetPreviousFile(string ActFile)
        {
            string PreviousFile = "";
            int Idx;
            bool bIsFound = false;
            for (Idx = 0; Idx < Files2LineResults.Count; Idx++)
            {
                if (Files2LineResults[Idx].FileName == ActFile)
                {
                    Idx--;
                    bIsFound = true;
                    if (-1 < Idx)
                        PreviousFile = Files2LineResults[Idx].FileName;
                    break;
                }
            }

            // start with item 0 again
            if (!bIsFound)
            {
                Idx = Files2LineResults.Count-1;
                if (-1 < Idx)
                    PreviousFile = Files2LineResults[Idx].FileName;
            }

            return PreviousFile;
        }

        public string ToStringFileList()
        {
            string OutTxt = "";

            OutTxt = OutTxt + "==============================================================" + "\r\n";
            OutTxt = OutTxt + "Found files with search token" + "\r\n";
            OutTxt = OutTxt + "Results for searched string: '"
                + SearchResultInfo.SearchProperties.SearchString
                + "' in following files : " + "\r\n";

            foreach (clsFileResults Files2LineResult in Files2LineResults)
            {
                OutTxt = OutTxt + Files2LineResult.FileName + "\r\n";
            }

            return (OutTxt);
        }

        public List<string> FileNamesAsStringList()
        {
            List<string> FileNameList = new List<string> ();
            try
            {
                foreach (clsFileResults Files2LineResult in Files2LineResults)
                {
                    FileNameList.Add(Files2LineResult.FileName);
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return (FileNameList);
        }

        public string ToStringFileListWithLines()
        {
            string OutTxt = "" + "\r\n";

            OutTxt = OutTxt + "==============================================================" + "\r\n";
            // OutTxt = OutTxt + "Found files with lines containing token";
            OutTxt = OutTxt + "Token found inside files :" + "\r\n";
            foreach (clsFileResults Files2LineResult in Files2LineResults)
            {
                OutTxt = OutTxt + "------------------------------------------------------------------" + "\r\n";
                OutTxt = OutTxt + Files2LineResult.ToStringLines() + "\r\n";
            }

            OutTxt = OutTxt + "==============================================================" + "\r\n";

            return (OutTxt);
        }


        public List<clsHtmlElement> FileListAsHtmlDoc()
        {

            List<clsHtmlElement> dummy = new List<clsHtmlElement> ();
            return dummy;
        }


        public override string ToString()
        {
            string OutTxt = "";

            if (Files2LineResults.Count < 1)
            {
                OutTxt = OutTxt + "Found no matches for '" + SearchString + "'\r\n";
            }
            else
            {
                OutTxt = OutTxt + "==============================================================" + "\r\n";
             
                // 'token' in *.cs: 130 matches in 2 files. 30 files searched. 0 files skipped.                
                
                OutTxt = OutTxt + "Found matches for '" + SearchString + "' in following files : " + "\r\n";

                foreach (clsFileResults Files2LineResult in Files2LineResults)
                {
                    OutTxt = OutTxt + Files2LineResult.FileName + "\r\n";
                }

                OutTxt = OutTxt + "==============================================================" + "\r\n";
                OutTxt = OutTxt + "Filecontents (E) :" + "\r\n";
                foreach (clsFileResults Files2LineResult in Files2LineResults)
                {
                    OutTxt = OutTxt + "------------------------------------------------------------------" + "\r\n";
                    OutTxt = OutTxt + Files2LineResult + "\r\n";
                }

                OutTxt = OutTxt  + "------------------------------------------------------------------" + "\r\n";

            }
            return (OutTxt);
        }

        protected void SetTitle(string NewTitle)
        {
            if (OnSetTitle != null)
            {
                clsEventArgsWithOneMessage args = new clsEventArgsWithOneMessage(NewTitle);
                OnSetTitle(this, args);
            }


        }

        protected void SetInfo(string NewInfo)
        {
            if (OnSetInfo != null)
            {
                clsEventArgsWithOneMessage args = new clsEventArgsWithOneMessage(NewInfo);
                OnSetInfo(this, args);
            }
        }

        protected void SetTime(string NewTime)
        {
            if (OnUpdateTime != null)
            {
                clsEventArgsWithOneMessage args = new clsEventArgsWithOneMessage(NewTime);
                OnUpdateTime(this, args);
            }
        }

        protected void UpdateFolderCount(int FolderCount)
        {
            if (OnSetInfo != null)
            {
                clsEventArgsWithOneMessage args = new clsEventArgsWithOneMessage(FolderCount.ToString());
                OnUpdateFolderCount(this, args);
            }
        }

        protected void UpdateFileCount(int FileCount)
        {
            if (OnSetInfo != null)
            {
                clsEventArgsWithOneMessage args = new clsEventArgsWithOneMessage(FileCount.ToString ());
                OnUpdateFileCount(this, args);
            }
        }

        //protected void SetMaxFileNumber(string NewInfo)
        //{
        //    if (OnSetInfo != null)
        //    {
        //        clsEventArgsWithOneMessage args = new clsEventArgsWithOneMessage(NewInfo);
        //        OnSetMaxFileNumber(this, args);
        //    }
        //}

        //protected void SetActFileNumber(string NewInfo)
        //{
        //    if (OnSetInfo != null)
        //    {
        //        clsEventArgsWithOneMessage args = new clsEventArgsWithOneMessage(NewInfo);
        //        OnSetActFileNumber(this, args);
        //    }
        //}

    }
}
