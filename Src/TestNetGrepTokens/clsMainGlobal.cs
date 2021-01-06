using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;

using DebugLog;
using ErrorCapture;
using LibStdFileDateTime;

using CmdLine2005;
using NetGrep;

namespace MainGlobal
{
    //class clsMainGlobal
    class Global
    {
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

        //private static clsSearchParameter mDoCmdGrepProperties = null;
        //public static clsSearchParameter DoCmdGrepProperties
        //{
        //    get { return mDoCmdGrepProperties; } // ?? erzeugen wenn nicht vorhanden ?
        //    set { mDoCmdGrepProperties = value; }
        //}

        //private static clsSearchResults mDoCmdSearchResults = null;
        //public static clsSearchResults DoCmdSearchResults
        //{
        //    get { return mDoCmdSearchResults; } // ?? erzeugen wenn nicht vorhanden ?
        //    set { mDoCmdSearchResults = value; }
        //}

        //private static clsConfigNetGrep mConfig = clsConfigNetGrep.LoadClassOrCreateUserFile();
        //public static clsConfigNetGrep Config
        //{
        //    get { return mConfig; }
        //    set { mConfig = value; }
        //}

        //private static clsSearchStringToken mSearchStringTokens = null; // new clsSearchStringToken ().LoadClassOrCreateUserFile();
        //public static clsSearchStringToken SearchStringTokens
        //{
        //    get { return mSearchStringTokens; }
        //    set { mSearchStringTokens = value; }
        //}

        //private static clsFileSpecificationToken mFileSpecificationToken = null; // clsFileSpecificationToken.LoadClassOrCreateUserFile();
        //public static clsFileSpecificationToken FileSpecificationToken
        //{
        //    get { return mFileSpecificationToken; }
        //    set { mFileSpecificationToken = value; }
        //}

        //private static clsSearchFoldersToken mSearchFoldersToken = null; // clsSearchFoldersToken.LoadClassOrCreateUserFile();
        //public static clsSearchFoldersToken SearchFoldersToken
        //{
        //    get { return mSearchFoldersToken; }
        //    set { mSearchFoldersToken = value; }
        //}

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

            //clsSearchStringToken.AssignStandardFileName();
            ////Global.SearchStringTokens = new clsSearchStringToken ();            
            //Global.SearchStringTokens = clsSearchStringToken.LoadClassOrCreateUserFile();

            //clsFileSpecificationToken.AssignStandardFileName();
            ////Global.FileSpecificationToken = new clsFileSpecificationToken (); 
            //Global.FileSpecificationToken = clsFileSpecificationToken.LoadClassOrCreateUserFile();

            //clsSearchFoldersToken.AssignStandardFileName();
            ////Global.SearchFoldersToken = new clsSearchFoldersToken(); 
            //Global.SearchFoldersToken = clsSearchFoldersToken.LoadClassOrCreateUserFile();
            
            //DoCmdGrepProperties = new clsSearchParameter ();
        }

        public static bool bNoAutoExit = false;
        public static bool bCloseAfterCommandsDone = false;
        public static bool bDoCheckClasses = false;
    }
}
