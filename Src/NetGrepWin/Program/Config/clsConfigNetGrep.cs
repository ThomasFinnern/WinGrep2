using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using ErrorCapture;
using ConfigBase;

namespace NetGrep
{
    [Serializable]
    /// <summary>
    /// Keeps the main config data for the using programm
    /// The main config of the program is saved either next to the application exe or in the 
    /// users programm folder 
    /// Examples : 
    ///    Standard Exe: "c:\Programme\ApplicationName\Config.ApplicationName.Ini"
    ///    User "c:\Dokumente und Einstellungen\thomas.finnern\Anwendungsdaten\ApplicationName\Config.ApplicationName.Ini"
    /// </summary>
    public class clsConfigNetGrep : clsConfigBase<clsConfigNetGrep>
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        protected string mCfgVersion;

        public clsSearchViewProperties ViewSetting = new clsSearchViewProperties ();
        public clsSearchViewProperties ShowViewSelection = new clsSearchViewProperties ();

        //protected bool mbCmdLineUseLastSearchProperties;

        protected string mLastUsedFileName;
        protected string mLastUsedSearchPropertyFileName;
        protected string mLastUsedSearchResultFileName;
        protected string mLastUsedSearchResultHtmlFileName;

        // Action on startup of program
        public bool bDoPopUpSearchOnStart;
        public bool bDoRepeatLastSearchOnStart;
        public bool bDoLoadLastOpenSearchesOnStart;
        public bool bDoViewLastUsedSearchResultOnStart; // one last search 

        // View while searching
        public bool bViewFileNamesOnSearch;
        public bool bCountFoldersOnSearch;
        public bool bCountFilesOnSearch;




        #endregion class properties

        // local settings of config

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        public string CfgVersion
        {
            get { return mCfgVersion; }
            set { mCfgVersion = value; }
        }

        //public int PrepareLineNbrPreviousToMatch
        //{
        //    get { return mPrepareLineNbrPreviousToMatch; }
        //    set { mPrepareLineNbrPreviousToMatch = value; }
        //}

        //public int PrepareLineNbrFollowingMatch
        //{
        //    get { return mPrepareLineNbrFollowingMatch; }
        //    set { mPrepareLineNbrFollowingMatch = value; }
        //}


        //public int ShowLineNbrPreviousToMatch
        //{
        //    get { return mShowLineNbrPreviousToMatch; }
        //    set { mShowLineNbrPreviousToMatch = value; }
        //}

        //public int ShowLineNbrFollowingMatch
        //{
        //    get { return mShowLineNbrFollowingMatch; }
        //    set { mShowLineNbrFollowingMatch = value; }
        //}

        public string LastUsedSearchPropertyFileName
        {
            get 
            {
                // Return at least one openend path if possible
                if (mLastUsedSearchPropertyFileName.Length > 0)
                    return mLastUsedSearchPropertyFileName;
                else
                    return mLastUsedFileName;
            }
            set 
            { 
                mLastUsedSearchPropertyFileName = value; 
                mLastUsedFileName = value;
            }
        }

        public string LastUsedSearchResultFileName
        {
            get 
            { 
                // Return at least one openend path if possible
                if (mLastUsedSearchResultFileName.Length > 0)
                    return mLastUsedSearchResultFileName;
                else
                    return mLastUsedFileName;
               }
            set 
            { 
                mLastUsedSearchResultFileName = value; 
                mLastUsedFileName = value;
            }
        }

        public string LastUsedSearchResultHtmlFileName
        {
            get 
            { 
                // Return at least one openend path if possible
                if (mLastUsedSearchResultHtmlFileName.Length > 0)
                    return mLastUsedSearchResultHtmlFileName;
                else
                    return mLastUsedFileName;
            }
            set 
            { 
                mLastUsedSearchResultHtmlFileName = value; 
                mLastUsedFileName = value;
            }
        }




        //public int NbrKeepSearchToken
        //{
        //    get { return mNbrKeepSearchToken; }
        //    set { mNbrKeepSearchToken = value; }
        //}

        //public bool bCmdLineUseLastSearchProperties
        //{
        //    get { return mbCmdLineUseLastSearchProperties; }
        //    set { mbCmdLineUseLastSearchProperties = value; }
        //}

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public override void AssignStandardValues()
        {
            mCfgVersion = "0.001";

            ViewSetting.AssignStandardValues();
            ShowViewSelection.AssignStandardValues();
            
            // mbCmdLineUseLastSearchProperties = true;
            bDoPopUpSearchOnStart = false;

            mLastUsedFileName = "";
            mLastUsedSearchPropertyFileName = "";
            mLastUsedSearchResultFileName = "";
            mLastUsedSearchResultHtmlFileName = "";
        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsConfigNetGrep()
        {
            AssignStandardValues();
        }

    }
}
