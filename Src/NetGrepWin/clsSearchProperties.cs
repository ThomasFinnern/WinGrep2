using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using ConfigBase;
using ErrorCapture;
using LibStringFunctions;

namespace NetGrep
{
    [Serializable]
    public class clsSearchProperties : clsConfigSpezialBase<clsSearchProperties>, IComparable 
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        // ToDo: ***:: ToString with only active elements and commands from Lists
        // ToDo: **:: Update tostring function
        // ToDo: **:: Update comparing function

        // protected string mCfgVersion;

        // --- Search string options -------------------------------------

        protected string mSearchString;
        protected List<string> mSearchFileTypes = new List<string>();
        protected List<string> mSearchFolders = new List<string>();
        protected Dictionary<string, string> mDictSearchFolders = new Dictionary<string, string>();
        protected bool mbUseRegularExpression;
        protected bool mbWholeWordsOnly;
        protected bool mbMatchCase;
        protected bool mbLinesWithNoMatch;
        protected bool mbStopAfterFirstMatch;
        protected bool mbFilesWithNoMatch;
        protected bool mbSearchInFoundFiles;
        protected string mReplaceString;
        protected bool mbNeedsCompleteLine;
        protected bool mbUseDelimitedList;
        protected bool mbUseFixedWidthList;

        protected string mDelimitedSeperationChar;
        protected string mDelimitedSearchFieldNbr;
        protected string mFixedWidthBeginPosition;
        protected string mFixedWidthSize;

        // --- File type options -----------------------------------

        public bool bUseFileRegularExpression;
        public bool bRegExFileMatchCase;
        public bool bSearchInsideZipFiles;
        // public bool bSkipBinaryFiles;
        public bool bSkipFileTypes;
        public string SkipFileTypesString;


        // --- Folder options -------------------------------------#

        public bool bUseFolderRegularExpression;
        public bool bRegExFolderMatchCase;
        public bool bDoRecourseFolders;
        public bool bRegExPathLastPart;
        public string RegExPathLastPartText;

        // --- Replace options ------------------------------------
        protected bool mbReplaceInSelectedFiles;
        protected bool mbConfirmEachReplace;
        protected bool mbCreateBackup;
        protected bool mbReplaceOriginalFile;
        protected bool mbUseBackupFolder;
        protected string mBackupFolder;


        public clsSearchViewProperties ViewSetting = new clsSearchViewProperties();
        public clsSearchViewProperties ShowViewSelection = new clsSearchViewProperties();

        #endregion class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        public string SearchString
        {
            get { return mSearchString; }
            set { mSearchString = value; }
        }

        public string ReplaceString
        {
            get { return mReplaceString; }
            set { mReplaceString = value; }
        }

        public List<string> SearchFileTypes
        {
            get { return mSearchFileTypes; }
        }

        public string SearchFileTypesAsString
        {
            //get { return mFileSpecification; }
            //set { mFileSpecification = value; }
            get
            {
                return String.Join(" ", mSearchFileTypes.ToArray());

            }
            set
            {
                mSearchFileTypes.Clear();
                // ToDo: use sophiticTED DIVIDER FOR "TEXT "Text in brackets" ... -> token of cpomander ?
                foreach (string InFileType in value.Split(' '))
                {
                    string Trimmed = InFileType.Trim();
                    if (Trimmed.Length > 0)
                        mSearchFileTypes.Add(Trimmed);
                }
            }
        }
        
        // ToDo: Needs own class as items have to seperatized by "" or '' ...
        public List<string> SearchFolders
        {
            get { return mSearchFolders; }
        }

        /// <summary>
        /// Does enclose strings containing blanks/spaces with ""
        /// </summary>
        public string SearchFoldersAsString
        { 
            get 
            {
                string FolderNames = "";
                try
                {
                    /*
                    foreach (string FolderName in mSearchFolders)
                    {
                        if (FolderNames.Length > 1)
                            FolderNames += " ";
                        FolderNames += LibStringFileFolderNames.ExtractFolderListWithApostrophes(FolderName);
                    }
                     */
                    return LibStringFileFolderNames.CreateSpaceSeparatedFolderNamesString(mSearchFolders);
                }
                catch (Exception Ex)
                {
                    clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                    ErrCapture.ShowExeption();
                }

                return FolderNames;             
            }
            set 
            {
                try
                {
                    mSearchFolders.Clear();
                    // From line to single strings
                    mSearchFolders.AddRange(LibStringFileFolderNames.ExtractFolderListWithApostrophes(value));
                }
                catch (Exception Ex)
                {
                    clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                    ErrCapture.ShowExeption();
                }
            }
        }

        public bool bWholeWordsOnly
        {
            get { return mbWholeWordsOnly; }
            set { mbWholeWordsOnly = value; }
        }

        public bool bMatchCase
        {
            get { return mbMatchCase; }
            set { mbMatchCase = value; }
        }

        public bool bLinesWithNoMatch
        {
            get { return mbLinesWithNoMatch; }
            set { mbLinesWithNoMatch = value; }
        }

        public bool bStopAfterFirstMatch
        {
            get { return mbStopAfterFirstMatch; }
            set { mbStopAfterFirstMatch = value; }
        }

        public bool bUseRegularExpression
        {
            get { return mbUseRegularExpression; }
            set { mbUseRegularExpression = value; }
        }

        public bool bFilesWithNoMatch
        {
            get { return mbFilesWithNoMatch; }
            set { mbFilesWithNoMatch = value; }
        }

        public bool bSearchInFoundFiles
        {
            get { return mbSearchInFoundFiles; }
            set { mbSearchInFoundFiles = value; }
        }


        public bool bUseDelimitedList
        {
            get { return mbUseDelimitedList; }
            set { mbUseDelimitedList = value; }
        }

       public bool bUseFixedWidthList
        {
            get { return mbUseFixedWidthList; }
            set { mbUseFixedWidthList = value; }
        }

         public bool bNeedsCompleteLine
        {
            get { return mbNeedsCompleteLine; }
            set { mbNeedsCompleteLine = value; }
        }

        public string DelimitedSeperationChar
        {
            get { return mDelimitedSeperationChar; }
            set { mDelimitedSeperationChar = value; }
        }

        public string DelimitedSearchFieldNbr
        {
            get { return mDelimitedSearchFieldNbr; }
            set { mDelimitedSearchFieldNbr = value; }
        }

        public string FixedWidthBeginPosition
        {
            get { return mFixedWidthBeginPosition; }
            set { mFixedWidthBeginPosition = value; }
        }

        public string FixedWidthSize
        {
            get { return mFixedWidthSize; }
            set { mFixedWidthSize = value; }
        }

        public bool bReplaceInSelectedFiles
        {
            get { return mbReplaceInSelectedFiles; }
            set { mbReplaceInSelectedFiles = value; }
        }
        public bool bConfirmEachReplace
        {
            get { return mbConfirmEachReplace; }
            set { mbConfirmEachReplace = value; }
        }
        public bool bCreateBackup
        {
            get { return mbCreateBackup; }
            set { mbCreateBackup = value; }
        }
        public bool bReplaceOriginalFile
        {
            get { return mbReplaceOriginalFile; }
            set { mbReplaceOriginalFile = value; }
        }

        public bool bUseBackupFolder
        {
            get { return mbUseBackupFolder; }
            set { mbUseBackupFolder = value; }
        }

        public string BackupFolder
        {
            get { return mBackupFolder; }
            set { mBackupFolder = value; }
        }

   /*

   - SoundEx                     =
   - SkipTextFiles               =
   - SkipBinaryFiles             =
   - LookInZips                  =
   - RecourseFolders             ="true/false". Search in sub folders (default -> yes)
   - CountFilesFirst             =
   - Skip_vti                    =
   - DelimitedList               ="true/false"   
   - DelimitedListSeperator      ="Char or string" which is used to destinguish between columns
   - DelimitedListColumnNumber   ="Column number" in which to search
   - FixedWithList               ="true/false"   
   - FixedWithStart              =" " . Character column where to start search in line
   - FixedWithSize               ="  " Width of the fied where to search for in line
   - MatchAbove                  ="lines". 0 shows no line above the found line
   - MatchBelow                  ="lines". 0 shows no line below the found line
   - ShowSearchDialogOnStartup   ="true/false"   
   - EditorCommandLine           =

        protected bool m;
        public bool 
        {
            get { return m; }
            set { m = value; }
        }
*/

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public override void AssignStandardValues()
        {
            mCfgVersion = "0.001";
            //AutoFilenameAfterRandomCmd = true;

            mSearchString = "";
            mSearchFileTypes.Add ("*.*");
            mSearchFolders.Add (@"c:\");
            // Dictionary<string, string> mDictSearchFolders = new Dictionary<string, string>();
            mbUseRegularExpression = false;
            mbWholeWordsOnly = false;
            mbMatchCase = false;
            mbLinesWithNoMatch = false;
            mbStopAfterFirstMatch = false;

            mReplaceString = "";
            mBackupFolder = "";

            mDelimitedSeperationChar = "";
            mDelimitedSearchFieldNbr = "";
            mFixedWidthBeginPosition = "";
            mFixedWidthSize = "";

            SkipFileTypesString = "";

            bDoRecourseFolders = true;
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsSearchProperties()
        {
            CfgFileName = "SearchProperties.cfg";
            AssignStandardValues();
        }

        //---------------------------------------------------------------------------------------------
        // Accessor functions
        //---------------------------------------------------------------------------------------------

        public void AddSearchFolder(string Folder)
        {
            if (!mDictSearchFolders.ContainsKey(Folder))
            {
                mDictSearchFolders.Add(Folder, "");
                mSearchFolders.Add(Folder);
            }
        }

        // ToDo: Keep mFileSpecification as List <string>. Then the transfer is only once
        public List<string> FileSpecificationAsList()
        {

            //string[] namesArray = "Tom,Scott,Bob".Split(',');
            //List<string> namesList = new List<string>(namesArray.Length);
            //namesList.AddRange(namesArray);
            //namesList.Reverse();

            //List<string> FileTypes = FileSpecification.Split(' ').ToList<string>();
            // works VC# 2008 /2010 return FileSpecification.Split(' ').ToList<string>();
            
            List<string> FileSpecificationList = new List<string> ();

            foreach (string sFileSpecification in SearchFileTypesAsString.Split(' '))
            {
                FileSpecificationList.Add (sFileSpecification);
            }
            return FileSpecificationList;
        }

        //public string[] FileSpecificationAsList()
        //{
        //    return FileSpecification.Split(' ');
        //}

        ///// <summary>
        ///// Makes it identificable to compare it 
        ///// </summary>
        ///// <returns></returns>
        //public string IdSearchProp()
        //{
        //    return FileSpecification.Split(' ');
        //}

        public override bool Equals(object obj)
        {
            bool IsEqual = true;
            try
            {
                // Compared does not exist
                if (obj == null)
                    return false;

                // Compared has wrong type
                if (!(obj is clsSearchProperties))
                    return false;
                
                clsSearchProperties Compared = (clsSearchProperties) obj;

                if (SearchString != Compared.SearchString)
                    IsEqual = false;
               
                if (SearchFileTypesAsString != Compared.SearchFileTypesAsString)
                    IsEqual = false;

                if (SearchFoldersAsString != Compared.SearchFoldersAsString)
                    IsEqual = false;

                if (bUseRegularExpression != Compared.bUseRegularExpression)
                    IsEqual = false;

                if (mbWholeWordsOnly != Compared.mbWholeWordsOnly)
                    IsEqual = false;

                if (bMatchCase != Compared.bMatchCase)
                    IsEqual = false;

                if (bLinesWithNoMatch != Compared.bLinesWithNoMatch)
                    IsEqual = false;

                if (bStopAfterFirstMatch != Compared.bStopAfterFirstMatch)
                    IsEqual = false;

                if (bFilesWithNoMatch != Compared.bFilesWithNoMatch)
                    IsEqual = false;

                if (bSearchInFoundFiles != Compared.bSearchInFoundFiles)
                    IsEqual = false;

                /**/
                if (bUseDelimitedList != Compared.bUseDelimitedList)
                    IsEqual = false;

                if (bUseFixedWidthList != Compared.bUseFixedWidthList)
                    IsEqual = false;

                if (bNeedsCompleteLine != Compared.bNeedsCompleteLine)
                    IsEqual = false;

                if (DelimitedSeperationChar != Compared.DelimitedSeperationChar)
                    IsEqual = false;

                if (DelimitedSearchFieldNbr != Compared.DelimitedSearchFieldNbr)
                    IsEqual = false;

                if (FixedWidthBeginPosition != Compared.FixedWidthBeginPosition)
                    IsEqual = false;

                if (FixedWidthSize != Compared.FixedWidthSize)
                    IsEqual = false;

                if (bReplaceInSelectedFiles != Compared.bReplaceInSelectedFiles)
                    IsEqual = false;

                if (bConfirmEachReplace != Compared.bConfirmEachReplace)
                    IsEqual = false;

                if (bCreateBackup != Compared.bCreateBackup)
                    IsEqual = false;

                if (bReplaceOriginalFile != Compared.bReplaceOriginalFile)
                    IsEqual = false;
            }
            catch (Exception Ex)
            {
                IsEqual = false;
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return IsEqual;
        }


        /// <summary>
        /// Makes it identificable for the user to distinguish betwen views (loaded forms)
        /// </summary>
        /// <returns></returns>
        public string IdSearchQueryDistinguishView()
        {
            string IdView = "";
            try
            {
                IdView += SearchString + "::";
                IdView += SearchFileTypesAsString + "::";

                string IdViewOpts = "";
                if (mbWholeWordsOnly)
                    IdViewOpts += "Ww";
                if (bMatchCase)
                    IdViewOpts += "Mc";
                if (bLinesWithNoMatch)
                    IdViewOpts += "L!m";
                if (bStopAfterFirstMatch)
                    IdViewOpts += "Sf";
                if (bFilesWithNoMatch)
                    IdViewOpts += "F!m";
                if (bSearchInFoundFiles)
                    IdViewOpts += "Sff";
                if (bUseDelimitedList)
                    IdViewOpts += "Dl";
                if (bUseFixedWidthList)
                    IdViewOpts += "Fwl";
                if (bNeedsCompleteLine)
                    IdViewOpts += "Ncl";
                //if (DelimitedSeperationChar)
                //    IdViewOpts += "";
                //if (DelimitedSearchFieldNbr)
                //    IdViewOpts += "";
                //if (FixedWidthBeginPosition)
                //    IdViewOpts += "";
                //if (FixedWidthSize)
                //    IdViewOpts += "";
                if (bReplaceInSelectedFiles)
                    IdViewOpts += "Rpsl";
                if (bConfirmEachReplace)
                    IdViewOpts += "Rpcf";
                if (bCreateBackup)
                    IdViewOpts += "Bk!";
                if (bReplaceOriginalFile)
                    IdViewOpts += "Prof";

                if (IdViewOpts.Length > 0)
                    IdView += IdViewOpts + "::";

                int LengthPreFolder = IdView.Length;

                // Todo: give max lenght folder in config ? Type a) List of last folder names or last part of first ... 

                if (SearchFolders.Count == 1)
                {
                    int LengthFolderName = SearchFolders[0].Length;
                    if (LengthFolderName < 33)
                    {
                        IdView += SearchFolders[0]; // +"::";
                    }
                    else
                    {
                        IdView += "..." + SearchFolders[0].Substring(LengthFolderName - 30); // +"::";
                    }
                }
                else
                {
                    if (SearchFolders.Count > 1)
                    {
                        int LengthFolderName = SearchFolders[0].Length;
                        if (LengthFolderName < 20)
                        {
                            IdView += SearchFolders[0]; // +"::";
                        }
                        else
                        {
                            IdView += "..." + SearchFolders[0].Substring(LengthFolderName - 20); // +"::";
                        }

                        for (int Idx = 1; Idx < SearchFolders.Count; Idx++)
                        {
                            LengthFolderName = SearchFolders[Idx].Length;
                            if (LengthFolderName < 20)
                            {
                                IdView += ";" + SearchFolders[Idx]; // +;
                            }
                            else
                            {
                                //string ActFolderName = Path.
                                //string ActFolderName = Directory.GetCurrentDirectory 
                                string ActFolderName = Path.GetFileName(Path.GetDirectoryName(SearchFolders[Idx]));
                                LengthFolderName = ActFolderName.Length;
                                if (LengthFolderName < 20)
                                {
                                    IdView += ";" + ActFolderName; // +"::";
                                }
                                else
                                {
                                    IdView += ";..." + ActFolderName.Substring(LengthFolderName - 17); // +"::";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return IdView;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Implement IComparable CompareTo method - provide default sort order.
        int IComparable.CompareTo(object obj)
        {
            clsSearchProperties c = (clsSearchProperties)obj;
            return String.Compare(this.IdSearchQueryDistinguishView (), c.IdSearchQueryDistinguishView ());

        }
        public override string ToString()
        {
            string OutTxt = "";

            OutTxt = OutTxt + "GrepProperties:" + "\r\n";

            OutTxt = OutTxt + "SearchString: " + SearchString + "\r\n";
            OutTxt = OutTxt + "FileSpecification: " + SearchFileTypesAsString + "\r\n";
            OutTxt = OutTxt + "SearchFolders: " + "\r\n";
            foreach (string SearchFolder in SearchFolders)
            {
                OutTxt = OutTxt + "\t- " + SearchFolder + "\r\n";
            }

            if (bUseRegularExpression)
                OutTxt = OutTxt + "bUseRegularExpression: " + bUseRegularExpression + "\r\n";
            if (mbWholeWordsOnly)
                OutTxt = OutTxt + "mbWholeWordsOnly: " +  bWholeWordsOnly + "\r\n";
            if (bMatchCase)
                OutTxt = OutTxt + "bMatchCase: " + bMatchCase + "\r\n";
            if (bLinesWithNoMatch)
                OutTxt = OutTxt + "bLinesWithNoMatch: " + bLinesWithNoMatch + "\r\n";
            if (bStopAfterFirstMatch)
                OutTxt = OutTxt + "bStopAfterFirstMatch: " + bStopAfterFirstMatch + "\r\n";
            if (bFilesWithNoMatch)
                OutTxt = OutTxt + "bFilesWithNoMatch: " + mbFilesWithNoMatch + "\r\n";
            if (bSearchInFoundFiles)
                OutTxt = OutTxt + "bSearchInFoundFiles: " + bSearchInFoundFiles + "\r\n";

            
            /*            if ()
                OutTxt = OutTxt + ": " + + "\r\n";
            if ()
                OutTxt = OutTxt + ": " + + "\r\n";
            if ()
                OutTxt = OutTxt + ": " + + "\r\n";
            if ()
                OutTxt = OutTxt + ": " + + "\r\n";
            if ()
                OutTxt = OutTxt + ": " + + "\r\n";
            OutTxt = OutTxt + ": " + + "\r\n";
            OutTxt = OutTxt + ": " + + "\r\n";
            OutTxt = OutTxt + ": " + + "\r\n";
            OutTxt = OutTxt + ": " + + "\r\n";
            OutTxt = OutTxt + ": " + + "\r\n";
*/
            return OutTxt;
        }
    }
}
