using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Xml;

using System.Windows.Forms;
using MainGlobal;
using ErrorCapture;
using ConfigBase;

using AppPaths;

namespace LibStringFunctions
{
    [Serializable]
    /// <summary>
    /// Keeps lists "token" 
    /// New entries are placed in front
    /// Too old entries will be deleted
    /// </summary>
    public abstract class clsObjectListFixedLength<O, T>
        where T : clsObjectListFixedLength<O, T>, new ()
        where O : IComparable
    {
        //---------------------------------------------------------------------------------------------
        // Config variables 
        //---------------------------------------------------------------------------------------------

        //--- Name and paths of config files ---------------------------------------------
        public static string CfgFileName;

        #region Class properties

        protected string mCfgVersion;

        /// <summary>
        /// Standad token (may include some fixed ones). The last used one will be put to the head . 
        /// The oldest token will fall out if the list grows too long
        /// </summary>
        protected List<O> mTokenList = new List<O>();

        /// <summary>
        /// The token list keeps not more than these number of items
        /// </summary>
        protected int mMaxTokenNumber;
        /// <summary>
        /// The fixed token list keeps not more than these number of items
        /// </summary>

        #endregion Class properties

        //---------------------------------------------------------------------------------------------
        // Config getter and setter
        //---------------------------------------------------------------------------------------------

        public string CfgVersion
        {
            get { return mCfgVersion; }
            set { mCfgVersion = value; }
        }

        // ToDo: only readable see older version
        public List<O> TokenList
        {
            get { return mTokenList; }
            set { mTokenList = value; }
        }

        /// <summary>
        /// Maximal number of items saved as standard tokens
        /// </summary>
        public int MaxTokenNumber
        {
            get { return mMaxTokenNumber; }
            set { mMaxTokenNumber = value; }
        }

        public static string ProgramCfgPathName
        {
            get { return clsAppPaths.ProgramCfgPathName.PathName; }
        }

        public static string ProgramCfgPathFileName
        {
            get { return Path.Combine(ProgramCfgPathName, CfgFileName); }
        }

        public static string UserCfgPathName
        {
            get { return clsAppPaths.UserCfgPathName.PathName; }
        }

        public static string UserCfgPathFileName
        {
            get { return Path.Combine(UserCfgPathName, CfgFileName); }
        }

         public static string AllUsersCfgPathName
        {
            get { return clsAppPaths.AllUsersCfgPathName.PathName; }
        }

        public static string AllUsersCfgPathFileName
        {
            get { return Path.Combine(AllUsersCfgPathName, CfgFileName); }
        }

        //---------------------------------------------------------------------------------------------
        // Standard values
        //---------------------------------------------------------------------------------------------

        public virtual void AssignStandardValues()
        {
            mCfgVersion = "0.001";
            //AutoFilenameAfterRandomCmd = true;

            Clear(); // token lists

            mMaxTokenNumber = 25;
        }

        // public void ClearTokenLists()
        public void Clear()
        {
            mTokenList = new List<O>();
        }

        public static void AssignFileName(string FileName)
        {
            CfgFileName = FileName;
        }

//        //---------------------------------------------------------------------------------------------
//        // Config class construction
//        //---------------------------------------------------------------------------------------------
//
//        public clsGrepTokenListBase()
//        {
//            //CfgFileName = "SearchProperties.cfg";
//            AssignStandardValues();
//        }

        //---------------------------------------------------------------------------------------------
        // Accessor functions
        //---------------------------------------------------------------------------------------------

        private void FillTokenList (ref List<O> OutTokens, int MaxOutIdx, List<O> InTokens, 
            ref int InIdx)
        {
            while (InIdx < InTokens.Count && OutTokens.Count -1 < MaxOutIdx)
            {
                // Use only once
                if (!OutTokens.Contains(InTokens[InIdx]))
                {
                    OutTokens.Add(InTokens[InIdx]);
                }
                InIdx++;
            }
        }

        /// <summary>
        /// Assigns a new token if not existing as first element. 
        /// If the elements already exists it is moved to the first place
        /// </summary>
        /// <param name="NewToken"></param>
        public void AddUsedToken(O NewToken)
        {
            if (TokenList.Count > 0)
            {
                // New token already in first place ?
                if (mTokenList[0].CompareTo(NewToken) == 0)
                    return;

                if (mTokenList.Contains(NewToken))
                {
                    mTokenList.Remove(NewToken);
                }
            }

            mTokenList.Insert(0, NewToken);

            if (mMaxTokenNumber > 1)
            {
                while (mTokenList.Count > mMaxTokenNumber)
                    mTokenList.RemoveAt(mTokenList.Count-1);
            }
        }

        /// <summary>
        /// Add on end of list
        /// </summary>
        /// <param name="NewToken"></param>
        public void AddFreeToken2List(O NewToken)
        {
            if (!TokenList.Contains(NewToken))
            {
                if (mTokenList.Count < mMaxTokenNumber)
                    mTokenList.Add(NewToken);
            }
        }

        //---------------------------------------------------------------------------------------------
        // Save and Read config files 
        //---------------------------------------------------------------------------------------------

        public short SaveClass2File(string FilePathName)
        {
            short ErrFound = -1;
            try
            {
                //FilePathName = @"D:\test.ini";

                XmlSerializer ser = new XmlSerializer(typeof(T));
                XmlTextWriter xml = new XmlTextWriter(FilePathName, Encoding.UTF8);

                xml.Formatting = Formatting.Indented;
                xml.Indentation = 4;
                xml.IndentChar = (char)32;

                ser.Serialize(xml, this);
                xml.Close();

                ErrFound = 0;
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return ErrFound;
        }

        /// <summary>
        /// Load a complete configuration from file 
        /// </summary>
        /// <returns></returns>
        /// <param name="FilePathName">Define file with path where to load from</param>
        /// <returns></returns>
        public static T LoadClassFromFile(string FilePathName)
        {
            T ConfigRenamePiwmContainer = default(T);

            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                //if (!rdr.Value.Equals (""))
                if (File.Exists(FilePathName))
                {
                    XmlTextReader rdr = new XmlTextReader(FilePathName);
                    if (ser.CanDeserialize(rdr))
                    {
                        ConfigRenamePiwmContainer = (T)ser.Deserialize(rdr);
                        rdr.Close();
                    }
                    else
                    {
                        rdr.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return ConfigRenamePiwmContainer;
        }

        ///// <summary>
        ///// Loads class from standard file in exe folder
        ///// </summary>
        ///// <param name="FilePathName"></param>
        ///// <returns></returns>
        //public static T LoadClassFromProgramFile()
        //{
        //    if (File.Exists(ProgramCfgPathFileName))
        //        return LoadClassFromFile(ProgramCfgPathFileName);
        //    else
        //        return default(T);
        //}

        //public static T LoadClassOrCreateProgramFile()
        //{
        //    //T PrgConfig = LoadClassFromProgramFile();
        //    //if (PrgConfig == null)
        //    //{
        //    //    PrgConfig = new T();
        //
        //    T PrgConfig = new T();
        //        PrgConfig.SaveClass2ProgramFile();
        //    //}
        //            
        //    return PrgConfig;
        //}

        /// <summary>
        /// Save class to standard file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public int SaveClass2ProgramFile()
        {
            return SaveClass2File(ProgramCfgPathFileName);
        }

        /// <summary>
        /// Loads class from standard file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public static T LoadClassFromAllUsersFile()
        {
            if (File.Exists(AllUsersCfgPathFileName))
                return LoadClassFromFile(AllUsersCfgPathFileName);
            else
                return default(T);
        }

        /// <summary>
        /// Save class to standard file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public int SaveClass2AllUsersFile()
        {
            return SaveClass2File(AllUsersCfgPathFileName);
        }

        public static T LoadClassOrCreateAllUsersFile()
        {
            T AllUsersConfig = LoadClassFromAllUsersFile();
            if (AllUsersConfig == null)
            {
                //AllUsersConfig = LoadClassFromProgramFile();
                //if (AllUsersConfig == null)
                //{
                    AllUsersConfig = new T();
                //}

                AllUsersConfig.SaveClass2AllUsersFile();
            }

            return AllUsersConfig;
        }

        ///// <summary>
        ///// Save class to standard file in exe folder
        ///// </summary>
        ///// <param name="FilePathName"></param>
        ///// <returns></returns>
        //public int SaveClass2AllUsersFile()
        //{
        //    return SaveClass2File(ProgramCfgPathFileName);
        //}

        /// <summary>
        /// Loads class from user file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public static T LoadClassFromUserFile()
        {
            try
            {
                // Destination path exists ?
                if (!Directory.Exists(UserCfgPathName))
                {
                    // Try to create
                    Directory.CreateDirectory(UserCfgPathName);
                }

                // Load file if directory exists
                if (Directory.Exists(UserCfgPathName))
                {
                    if (File.Exists(UserCfgPathFileName))
                    {
                        return LoadClassFromFile(UserCfgPathFileName);
                    }
                }
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }

            return default(T);
        }

        /// <summary>
        /// Save class to user file in exe folder
        /// </summary>
        /// <param name="FilePathName"></param>
        /// <returns></returns>
        public int SaveClass2UserFile()
        {
            // Destination path exists ?
            if (!Directory.Exists(UserCfgPathName))
            {
                Directory.CreateDirectory(UserCfgPathName);
            }

            // if path exists create file
            if (Directory.Exists(UserCfgPathName))
            {
                return SaveClass2File(UserCfgPathFileName);
            }

            return -1;
        }


        public int SaveClass2UserFileBackup()
        {
            // Destination path exists ?
            if (!Directory.Exists(UserCfgPathName))
            {
                Directory.CreateDirectory(UserCfgPathName);
            }

            // if path exists create file
            if (Directory.Exists(UserCfgPathName))
            {
                return SaveClass2File("Backup." + UserCfgPathFileName);
            }

            return -1;
        }



        public static T LoadClassOrCreateUserFile()
        {
            T UsrConfig = LoadClassFromUserFile();
            if (UsrConfig == null)
            {
                UsrConfig = LoadClassOrCreateAllUsersFile ();
                UsrConfig.SaveClass2UserFile();
            }

            return UsrConfig;
        }

        public override string ToString()
        {
            string OutTxt = "";

            if (TokenList.Count > 0)
            {
                OutTxt += "Token:" + "\r\n";
                foreach (O Token in mTokenList)
                {
                    OutTxt += "   " + Token.ToString () + "\r\n";
                }
            }

            return OutTxt;
        }
    }
}
