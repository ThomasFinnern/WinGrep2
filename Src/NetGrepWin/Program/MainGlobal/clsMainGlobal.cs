using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;

using DebugLog;
using ErrorCapture;
using LibStdFileDateTime;
using LibStringFunctions;
using CmdLine2005;
using NetGrep;
using AppPaths;
using LibConfig;
//using LogInputKeys;

namespace MainGlobal
{
    //class clsMainGlobal
    class Global
    {
        private static clsAppPaths AppPaths = new clsAppPaths(
                clsAppPaths.eCreateFolders.AllUsersCfgPathName |
                clsAppPaths.eCreateFolders.ProgramCfgPathName |
                clsAppPaths.eCreateFolders.UserCfgPathName);

        private static clsDebugLog moDebugLog = new clsDebugLog ();
        public static clsDebugLog oDebugLog 
        {
            get 
            {
                return moDebugLog;
            }
            set {moDebugLog = value;}
        }

        private static clsLogErrors moLogError = new clsLogErrors();
        public static clsLogErrors oLogError
        {
            get { return moLogError; }
            set { moLogError = value; }
        }

        private static clsSearchProperties mDoCmdGrepProperties = null;
        public static clsSearchProperties DoCmdGrepProperties
        {
            get { return mDoCmdGrepProperties; } // ?? erzeugen wenn nicht vorhanden ?
            set { mDoCmdGrepProperties = value; }
        }

        private static clsSearchExecute mDoCmdSearchResults = null;
        public static clsSearchExecute DoCmdSearchResults
        {
            get { return mDoCmdSearchResults; } // ?? erzeugen wenn nicht vorhanden ?
            set { mDoCmdSearchResults = value; }
        }

        private static clsConfigNetGrep mConfig = clsConfigNetGrep.LoadClassOrCreateUserFile();
        public static clsConfigNetGrep Config
        {
            get { return mConfig; }
            set { mConfig = value; }
        }

        private static clsCmdLineConfig mCmdLineConfig =  new clsCmdLineConfig(); 
        public static clsCmdLineConfig CmdLineConfig
        {
            get { return mCmdLineConfig; }
            set { mCmdLineConfig = value; }
        }

        private static clsSearchStringToken mSearchStringTokens = null; // new clsSearchStringToken ().LoadClassOrCreateUserFile();
        public static clsSearchStringToken SearchStringTokens
        {
            get { return mSearchStringTokens; }
            set { mSearchStringTokens = value; }
        }

        private static clsReplaceStringToken mReplaceStringTokens = null; // new clsSearchStringToken ().LoadClassOrCreateUserFile();
        public static clsReplaceStringToken ReplaceStringTokens
        {
            get { return mReplaceStringTokens; }
            set { mReplaceStringTokens = value; }
        }

        private static clsFileSpecificationToken mFileSpecificationToken = null; // clsFileSpecificationToken.LoadClassOrCreateUserFile();
        public static clsFileSpecificationToken FileSpecificationToken
        {
            get { return mFileSpecificationToken; }
            set { mFileSpecificationToken = value; }
        }

        private static clsBackupFoldersToken mBackupFoldersToken = null; // clsBackupFoldersToken.LoadClassOrCreateUserFile();
        public static clsBackupFoldersToken BackupFoldersToken
        {
            get { return mBackupFoldersToken; }
            set { mBackupFoldersToken = value; }
        }

        private static clsSearchFoldersToken mSearchFoldersToken = null; // clsSearchFoldersToken.LoadClassOrCreateUserFile();
        public static clsSearchFoldersToken SearchFoldersToken
        {
            get { return mSearchFoldersToken; }
            set { mSearchFoldersToken = value; }
        }

        private static clsLastUsedSearchQueries mLastUsedSearchQueries = null; // new clsSearchStringToken ().LoadClassOrCreateUserFile();
        public static clsLastUsedSearchQueries LastUsedSearchQueries
        {
            get { return mLastUsedSearchQueries; }
            set { mLastUsedSearchQueries = value; }
        }

        private static clsLastOpenedFiles mUserLastOpenedFilesList = null; // clsLastOpenedFiles.LoadClassOrCreateUserFile();
        public static clsLastOpenedFiles UserLastOpenedFilesList
        {
            get { return mUserLastOpenedFilesList; }
            set { mUserLastOpenedFilesList = value; }
        }

        /**
        private static clsLogInputKeys mLogInputKeys = new clsLogInputKeys(); // clsLastOpenedFiles.LoadClassOrCreateUserFile();
        public static clsLogInputKeys LogInputKeys
        {
            get { return mLogInputKeys; }
            set { mLogInputKeys = value; }
        }
        /**/

        /// <summary>
        /// Initializes all globel neede object of this application
        /// </summary>
        public static void InitGlobalObjects()
        {
            Global.oDebugLog.LogFileName = Global.oDebugLog.StdLogPathFileName;
            Global.oDebugLog.bWrite2FileLog = true;
            Global.oDebugLog.WriteLog("Logfile " + Application.ProductName + ": " + clsStdFileDateTime.StdFileDateTimeFormatString() + "\r\n", true); // Resets file
            Global.oDebugLog.WriteLog(System.Text.Encoding.Default.ToString() + "\r\n");
            Global.oDebugLog.DPrint("- Standard initialisation ");

            clsSearchStringToken.AssignStandardFileName();
            Global.SearchStringTokens = clsSearchStringToken.LoadClassOrCreateUserFile();

            clsReplaceStringToken.AssignStandardFileName();
            Global.ReplaceStringTokens = clsReplaceStringToken.LoadClassOrCreateUserFile();

            clsFileSpecificationToken.AssignStandardFileName();
            Global.FileSpecificationToken = clsFileSpecificationToken.LoadClassOrCreateUserFile();

            clsBackupFoldersToken.AssignStandardFileName();
            Global.BackupFoldersToken = clsBackupFoldersToken.LoadClassOrCreateUserFile();

            clsSearchFoldersToken.AssignStandardFileName();
            Global.SearchFoldersToken = clsSearchFoldersToken.LoadClassOrCreateUserFile();

            clsLastOpenedFiles.AssignStandardFileName();
            Global.UserLastOpenedFilesList = clsLastOpenedFiles.LoadClassOrCreateUserFile();

            clsLastUsedSearchQueries.AssignStandardFileName();
            Global.LastUsedSearchQueries = clsLastUsedSearchQueries.LoadClassOrCreateUserFile();

            clsUserConfigFiles UserConfigFiles = new clsUserConfigFiles();

            UserConfigFiles.CfgFileList.Add("FileList.css");
            UserConfigFiles.CfgFileList.Add("TokenList.css");
            UserConfigFiles.Check4ExistingFilesOrCopy ();

            // Init with standard user values
            DoCmdGrepProperties = clsSearchProperties.LoadClassOrCreateUserFile(); // new clsSearchProperties ();
            DoCmdGrepProperties.ViewSetting = Global.Config.ViewSetting.Clone();
            DoCmdGrepProperties.ShowViewSelection = Global.Config.ShowViewSelection.Clone();

            // LogInputKeys = new clsLogInputKeys();
        }

        public static void AssignLastSearchQuery(clsSearchProperties LastUsedSearchQuery)
        {
            Global.LastUsedSearchQueries.AddUsedToken(LastUsedSearchQuery);
            Global.LastUsedSearchQueries.SaveClass2UserFile();
        }

    }
}
