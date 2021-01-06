using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using ErrorCapture;
using ConfigBase;

namespace TestClsHtml
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
    public class clsConfigTestClsHtmlGrep : clsConfigBase<clsConfigTestClsHtmlGrep>
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        #region Class properties

        protected string mCfgVersion;

        //public clsSearchViewProperties ViewSetting = new clsSearchViewProperties ();
        //public clsSearchViewProperties ShowViewSelection = new clsSearchViewProperties ();

        ////protected bool mbCmdLineUseLastSearchProperties;

        //protected string mLastUsedFileName;
        //protected string mLastUsedSearchPropertyFileName;
        //protected string mLastUsedSearchResultFileName;
        //protected string mLastUsedSearchResultHtmlFileName;

        //// Action on startup of program
        //public bool bDoPopUpSearchOnStart;
        //public bool bDoRepeatLastSearchOnStart;
        //public bool bDoLoadLastOpenSearchesOnStart;
        //public bool bDoViewLastUsedSearchResultOnStart; // one last search 

        //// View while searching
        //public bool bViewFileNamesOnSearch;
        //public bool bCountFoldersOnSearch;
        //public bool bCountFilesOnSearch;




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

        }

        //---------------------------------------------------------------------------------------------
        // Config class construction
        //---------------------------------------------------------------------------------------------

        public clsConfigTestClsHtmlGrep()
        {
            AssignStandardValues();
        }
    }
}
